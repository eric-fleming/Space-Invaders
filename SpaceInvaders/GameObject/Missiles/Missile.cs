using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Missile : MissileCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private float delta;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Missile(GameObject.Name gameObjName, GameSprite.Name spriteName, float px, float py, float delta = 12.0f)
            : base(gameObjName, spriteName, MissileCategory.Type.Missile)
        {
            this.x = px;
            this.y = py;
            this.delta = delta;
            
        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void SetDelta(float d)
        {
            this.delta = d;
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Update()
        {
            base.Update();
            this.y += this.delta;
        }

        

        public override void Remove()
        {
            // Keenan(delete.E)
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poCollObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();
            

            // Now remove it
            base.Remove();
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods - Visitor
        //----------------------------------------------------------------------------------

        public override void Accept(CollVisitor other)
        {
            //We are in the Missile class
            //Call the the collsion reaction in the other GameObject/ CollVisitor
            other.VisitMissile(this);
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            CollPair pColPair = CollPairManager.GetActiveCollPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }



    }
}
