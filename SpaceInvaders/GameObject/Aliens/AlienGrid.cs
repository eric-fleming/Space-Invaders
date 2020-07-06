using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGrid : Composite
    {


        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------

        private float delta;
        private float dropLength;
        private bool bIsTouchingWall;
        public float movementTimeInterval;
        public float movementJump;

        private bool bCanDropBombs;
        private Random pBombProb;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public AlienGrid(GameObject.Name gameObjName, GameSprite.Name gameSpriteName, float posX, float posY)
            : base(gameObjName, gameSpriteName)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 1.0f;
            this.dropLength = 40.0f;
            this.movementTimeInterval = 0.80f;
            this.movementJump = 15.0f;
            this.bIsTouchingWall = false;

            this.pBombProb = new Random();

            // Need to set this in the factory
            this.bCanDropBombs = false;

            // grid outline color
            this.poCollObj.pCollSprite.SetLineColor(1.0f, 0.0f, 1.0f);

            // For Sounds
            //this.InitializeSound();
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        
        public void IncreaseMovementSpeed()
        {
            // Change the time loop
            this.movementJump += 10.0f;
            if(this.movementJump > 50.0f)
            {
                this.movementJump = 50.0f;
            }

        }
        
        public void MoveGrid()
        {
            // Everybody MOVE!
            ForwardIterator pForward = new ForwardIterator(this);
            Component pNode = pForward.First();

            while (!pForward.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += this.movementJump * this.delta;

                // go to next
                pNode = pForward.Next();
            }

            // Bombs Away?!
            if (bCanDropBombs == true)
            {
                this.DropBomb();
            }

        }

        public void DropGrid()
        {
            ForwardIterator pForward = new ForwardIterator(this);

            Component pNode = pForward.First();
            while (!pForward.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.y -= this.dropLength;

                // go to next
                pNode = pForward.Next();
            }


        }

        public void SetCanDropBombs(bool b)
        {
            this.bCanDropBombs = b;
        }

        public bool GetCanDropBombs()
        {
            return this.bCanDropBombs;
        }

        public void SetIsOnWall(bool b)
        {
            this.bIsTouchingWall = b;
        }

        public bool GetIsOnWall()
        {
            return this.bIsTouchingWall;
        }


        public void SetDelta(float d)
        {
            // static variable in the Component Class
            this.delta = d;
        }

        public void SetPosition(float px, float py)
        {
            this.x = px;
            this.y = py;
        }

        public float GetDelta()
        {
            return this.delta;
        }
        public float GetX()
        {
            return this.x;
        }
        public float GetY()
        {
            return this.y;
        }

        public void SetMovementTimeInterval(float time)
        {
            this.movementTimeInterval = time;
        }

        public float GetMovementTimeInterval()
        {
            return this.movementTimeInterval;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
            
        }

        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private void DropBomb()
        {
            // Assumes all the columns are there
            int columns = this.CountChildren();

            // Generate random # to access bomb dropping frequency
            float bombFrequency =  ((float)this.pBombProb.Next(1, 1000000)) / 1000000.0f;
            float bombThreshold = ((float)columns) * 0.090909f;


            Debug.WriteLine("{0} : {1} < {2}", bombFrequency <= bombThreshold, bombFrequency, bombThreshold);
            // Only drop a bomb if we have an active column in the grid
            // Only fire if your random number is within the bomb threshold
            // corrects problem of dropping too many bombs with fewer columns
            
            if (columns > 0 && bombFrequency <= bombThreshold) { 
                int columnSelected = this.pBombProb.Next(1, columns+1);
                //Debug.WriteLine("column {0} of {1} was selected...", columnSelected, columns);

                Component pColumn = this.GetNthChild(columnSelected);

                float xMin = (float)((GameObject)pColumn).x;
                float yMin = ((GameObject)pColumn).y - 0.5f * ((GameObject)pColumn).poCollObj.poColRect.height;
                //Debug.WriteLine("({0}, {1})", xMin, yMin);

                TimerManager.Add(TimeEvent.Name.DropBomb, new DropBomb(xMin, yMin), 0.5f * this.movementTimeInterval);
            }

        }


        //----------------------------------------------------------------------------------
        // Abstract Methods - For Collision / Visitor Pattern
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            //We are in the AlienGrid class
            //Call the the collsion reaction in the other GameObject/ CollVisitor
            other.VisitAlienGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup mg)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", mg.GetName(), this.GetName());

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(mg, pGameObj);
        }

        public override void VisitWallGroup(WallGroup wg)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", wg.GetName(), this.GetName());

            // WallGroup vs AlienGrid
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(wg, pGameObj);
        }

    }
}
