using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldColumn : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ShieldColumn(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            // Column outline color
            this.poCollObj.pCollSprite.SetLineColor(0.0f, 1.0f, 1.0f);
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldColumn(this);
        }

        public override void VisitAlien(AlienGO a)
        {
            // Alien vs Shield-Column
            CollPair.Collide(a, (GameObject)Iterator.GetChild(this));
        }

        public override void VisitBomb(Bomb b)
        {
            // Missile vs ShieldRoot
            CollPair.Collide(b, (GameObject)Iterator.GetChild(this));
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldColumn
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(m, pGameObj);
        }


        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
