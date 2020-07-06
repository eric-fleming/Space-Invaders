using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldRoot : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ShieldRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            // grid outline color
            this.poCollObj.pCollSprite.SetLineColor(1.0f, 0.0f, 1.0f);

        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldRoot(this);
        }

        public override void VisitAlienGrid(AlienGrid ag)
        {
            // AlienGrid vs ShieldRoot
            CollPair.Collide((GameObject)Iterator.GetChild(ag), this);
        }

        public override void VisitColumn(AlienColumn ac)
        {
            // Alien Column vs ShieldRoot
            CollPair.Collide((GameObject)Iterator.GetChild(ac), this);
        }

        public override void VisitAlien(AlienGO a)
        {
            // Alien vs ShieldRoot
            CollPair.Collide(a, (GameObject)Iterator.GetChild(this));
        }

        public override void VisitBombRoot(BombRoot br)
        {
            // BombRoot vs ShieldRoot
            CollPair.Collide((GameObject)Iterator.GetChild(br), this);
        }

        public override void VisitBomb(Bomb b)
        {
            // Missile vs ShieldRoot
            CollPair.Collide(b, (GameObject)Iterator.GetChild(this));
        }


        public override void VisitMissileGroup(MissileGroup mg)
        {
            // MissileRoot vs Shield-Root
            GameObject pGameObj = (GameObject)Iterator.GetChild(mg);
            CollPair.Collide(pGameObj, this);
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs Shield-Root
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(m, pGameObj);
        }


        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

    }
}
