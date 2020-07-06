using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SpriteNode_Link : DLink
    {

    }

    public class SpriteNode : SpriteNode_Link
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------

        private SpriteBase pSprite;
        private SpriteNodeManager pBackSpriteNodeMan;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------

        public SpriteNode() : base()
        {
            // delegates to DLink constructor first, then does the following
            this.pSprite = null;
            this.pBackSpriteNodeMan = null;

        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void Set(SpriteBase pBase, SpriteNodeManager pSpriteNodeManager)
        {
            Debug.Assert(pBase != null);
            this.pSprite = pBase;

            // Set the back pointer
            // Allows easier deletion in the future
            Debug.Assert(pSprite != null);
            this.pSprite.SetSpriteNode(this);

            Debug.Assert(pSpriteNodeManager != null);
            this.pBackSpriteNodeMan = pSpriteNodeManager;
        }

        public SpriteBase GetSprite()
        {
            return this.pSprite;
        }

        public SpriteNodeManager GetSBNodeMan()
        {
            Debug.Assert(this.pBackSpriteNodeMan != null);
            return this.pBackSpriteNodeMan;
        }
        public SpriteNodeBatch GetSpriteBatch()
        {
            Debug.Assert(this.pBackSpriteNodeMan != null);
            return this.pBackSpriteNodeMan.GetSpriteNodeBatch();
        }

        public void Wash()
        {
            this.pSprite = null;
        }
    }
}
