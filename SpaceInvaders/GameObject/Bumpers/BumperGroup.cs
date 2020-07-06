using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperGroup : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public BumperGroup(GameObject.Name gameName, GameSprite.Name spriteName, float px, float py)
            : base(gameName, spriteName)
        {
            this.x = px;
            this.y = py;
            this.poCollObj.pCollSprite.SetLineColor(1.0f, 1.0f, 1.0f);
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
        // Visitor - Methods  (with the Ship and ShipRoot)
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            // Important : at this point we are in Ship
            
            other.VisitBumperGroup(this);
        }

    }
}
