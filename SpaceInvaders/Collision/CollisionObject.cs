using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionObj : CollisionObjBase
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        //public BoxSprite pCollSprite;
        //public CollRect poColRect;


        //----------------------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------------------
        public CollisionObj(ProxySprite pProxySprite)
        {
            Debug.Assert(pProxySprite != null);

            GameSprite pGameSprite = pProxySprite.pSprite;
            Debug.Assert(pGameSprite != null);


            // Origin is in the upper-right
            this.poColRect = new CollRect(pGameSprite.GetScreenRect());
            Debug.Assert(this.poColRect != null);


            // Create the Sprite
            this.pCollSprite = BoxSpriteManager.Add(BoxSprite.Name.Box, this.poColRect.x, this.poColRect.y, this.poColRect.width, this.poColRect.height);
            Debug.Assert(this.pCollSprite != null);
            this.pCollSprite.SetLineColor(1.0f, 1.0f, 1.0f);
        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public override void UpdatePos(float x, float y)
        {
            this.poColRect.x = x;
            this.poColRect.y = y;

            this.pCollSprite.x = this.poColRect.x;
            this.pCollSprite.y = this.poColRect.y;

            this.pCollSprite.SetScreenRect(this.poColRect.x, this.poColRect.y,this.poColRect.width,this.poColRect.height);
            this.pCollSprite.Update();
        }

    }
}
