using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ExplosionRoot : Composite
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollObj.pCollSprite.SetLineColor(1.0f, 1.0f, 1.0f);
        }


        //----------------------------------------------------------------------------------
        // Visitor Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
