using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SpriteBase : DLink
    {
        //----------------------------------------------------------------------------------
        // Data - Helpful for deleting sprites.  A pointer to the SpriteNode who manages it
        //----------------------------------------------------------------------------------
        private SpriteNode pBackSpriteNode;
        

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SpriteBase() : base()
        {
            this.pBackSpriteNode = null;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        abstract public void Update();
        abstract public void Render();

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public SpriteNode GetSpriteNode()
        {
            Debug.Assert(this.pBackSpriteNode != null);
            return this.pBackSpriteNode;
        }
        public void SetSpriteNode(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSpriteNode = pSpriteBatchNode;
        }


        //----------------------------------------------------------------------------------
        // Methods for ExplosionSprites
        //----------------------------------------------------------------------------------
        public SpriteNode GetBackSpriteNode()
        {
            Debug.Assert(this.pBackSpriteNode != null);
            return this.pBackSpriteNode;
        }
        public void SetBackSpriteNode(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSpriteNode = pSpriteBatchNode;
        }





    }
}
