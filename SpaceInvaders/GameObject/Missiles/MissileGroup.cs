using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileGroup : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------

        public MissileGroup(GameObject.Name gameName, GameSprite.Name spriteName, float px, float py)
            : base(gameName, spriteName)
        {
            this.x = px;
            this.y = py;
            this.poCollObj.pCollSprite.SetLineColor(1.0f, 1.0f, 0.0f);
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
        // Methods
        //----------------------------------------------------------------------------------
        public void MoveOffScreen()
        {
            //Missile calls this method when it is being removed
            //Move group off screen
            this.x = -20.0f;
            this.y = -20.0f;
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods - Visitor
        //----------------------------------------------------------------------------------

        public override void Accept(CollVisitor other)
        {
            //We are in the Missile Group class
            //Call the the collsion reaction in the other GameObject/ CollVisitor
            other.VisitMissileGroup(this);
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


    }
}
