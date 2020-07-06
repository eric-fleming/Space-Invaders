using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipRoot: Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ShipRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollObj.pCollSprite.SetLineColor(0, 0, 1);
        }

        ~ShipRoot()
        {
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        //----------------------------------------------------------------------------------
        // Visitor Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShipRoot(this);
        }

        // Visit Bombs
        //----------------------------------------------------------------------------------
        public override void VisitBombRoot(BombRoot br)
        {
            // BombRoot vs Ship-Root
            CollPair.Collide((GameObject)Iterator.GetChild(br), this);
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb vs Ship-Root
            CollPair.Collide(b, (GameObject)Iterator.GetChild(this));
        }



        // Visit Bumpers
        //----------------------------------------------------------------------------------
        public override void VisitBumperGroup(BumperGroup bg)
        {
            // Bumper-Group vs Ship-Root
            GameObject pGameObj = (GameObject)Iterator.GetChild(bg);
            CollPair.Collide(pGameObj, this);
        }

        public override void VisitBumperLeft(BumperLeft b)
        {
            // Bumper-Left vs Ship-Root
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(b, pGameObj);
        }

        public override void VisitBumperRight(BumperRight b)
        {
            // Bumper-Right vs Ship-Root
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(b, pGameObj);
        }

    }
}
