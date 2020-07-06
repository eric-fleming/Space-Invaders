using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperLeft : BumperCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public BumperLeft(GameObject.Name gameName, GameSprite.Name spriteName, float px, float py, float width, float height)
            : base(gameName, spriteName, BumperCategory.Type.LeftBumper)
        {
            this.x = px;
            this.y = py;
            this.poCollObj.pCollSprite.SetLineColor(0.0f, 0.7f, 1.0f);
            this.poCollObj.poColRect.Set(px, py, width, height);
        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public override void Update()
        {
            base.Update();
        }

        //----------------------------------------------------------------------------------
        // Visitor - Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            //Important : At this point we have an Bumper / BumperCategory
            other.VisitBumperLeft(this);
        }
    }
}
