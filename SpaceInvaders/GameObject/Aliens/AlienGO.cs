using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGO : Leaf
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private float delta;
        private int points;
        public ProxySprite pExplosion;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public AlienGO(GameObject.Name gameName, GameSprite.Name spriteName, int points, float x, float y)
            : base(gameName, spriteName)
        {
            this.x = x;
            this.y = y;
            this.delta = 1.0f;
            this.points = points;
            //this.pExplosion = null;

        }

        public AlienGO(GameObject.Name gameName, GameSprite.Name spriteName,GameSprite.Name expSpriteName, int points, float x, float y)
            : base(gameName, spriteName)
        {
            this.x = x;
            this.y = y;
            this.delta = 1.0f;
            this.points = points;
            this.pExplosion = ProxySpriteManager.Add(expSpriteName);

        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public int GetPoints()
        {
            int p = this.points;
            if (this.GetName() == GameObject.Name.Saucer)
            {
                // For the UFO
                this.points += 100;
            }
            return p;
        }
        //----------------------------------------------------------------------------------
        // Abstract Method
        //----------------------------------------------------------------------------------
        public override void Update()
        {
            base.Update();
        }


        public override void Accept(CollVisitor other)
        {
            //We are in the Alien class
            //Call the the collsion reaction in the other GameObject/ CollVisitor
            other.VisitAlien(this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Alien
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.GetName(), this.GetName());

            //Alien vs Missile
            Debug.WriteLine("----> Hit an {0}! <-----", this.GetName());

            CollPair pCollPair = CollPairManager.GetActiveCollPair();
            pCollPair.SetCollision(m, this);
            pCollPair.NotifyListeners();
    }

        public override void VisitMissileGroup(MissileGroup mg)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", mg.GetName(), this.GetName());

            // MissileGroup vs Alien
            GameObject pGameObj = (GameObject)Iterator.GetChild(mg);
            CollPair.Collide(pGameObj, this);
        }

        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------

        private void Move()
        {
            this.y -= delta;
            if (this.y < 0.0f)
            {
                this.y = 600.0f;
            }
        }

        private void Bounce()
        {
            this.y += this.delta;

            if (this.y > 500.0f || this.y < 100.0f)
            {
                this.delta *= -1.0f;
            }
        }

    }
}
