using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldGrid : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ShieldGrid(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.poCollObj.pCollSprite.SetLineColor(1.0f, 0.0f, 1.0f);
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods - Visitor
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an ShieldGrid
            // Call the appropriate collision reaction            
            other.VisitShieldGrid(this);
        }

        public override void VisitAlien(AlienGO a)
        {
            // Alien vs Shield-Grid
            CollPair.Collide(a, (GameObject)Iterator.GetChild(this));
        }

        public override void VisitBomb(Bomb b)
        {
            // Missile vs ShieldRoot
            CollPair.Collide(b, (GameObject)Iterator.GetChild(this));
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldGrid
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(m, pGameObj);
        }

    }
}
