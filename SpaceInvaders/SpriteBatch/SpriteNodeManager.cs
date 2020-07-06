using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SpriteNodeManager_MLink : Manager
    {
        public SpriteNode_Link poActive = null;
        public SpriteNode_Link poReserve = null;
    }
    public class SpriteNodeManager : SpriteNodeManager_MLink
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------

        private SpriteNodeBatch.Name name;
        private readonly SpriteNode poNodeCompare;
        private SpriteNodeBatch pBackSpriteBatch;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------

        public SpriteNodeManager(int initReserve = 3, int growthRate = 1) : base()
        {
            // Delegates inital construction to the manager class, then does the following.

            //round 1 : unsure why this exists at the moment.  I thought : base() covered this territory.
            this.baseInitialize(initReserve,growthRate);

            //round 2 : a compare object attached to a class since there will be multiple batches
            this.poNodeCompare = new SpriteNode();
            this.pBackSpriteBatch = null;
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new SpriteNode();
            Debug.Assert(pNode != null);

            return pNode;
        }
        
        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            SpriteNode pSNA = (SpriteNode)pLinkA;
            SpriteNode pSNB = (SpriteNode)pLinkB;

            // result of comparison, expression results a bool
            // check pointer equality, if true, then the contents are the same
            return (pSNA == pSNB);
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SpriteNode pSpriteNode = (SpriteNode)pLink;
            pSpriteNode.Wash();
        }

        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SpriteNode pSpriteNode = (SpriteNode)pLink;
            Debug.WriteLine("Sprite-obj-ref : ({0})", pSpriteNode.GetHashCode());
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public SpriteNode Attach(SpriteBase pBase)
        {

            SpriteNode pSpriteNode = (SpriteNode)this.baseAdd();
            Debug.Assert(pSpriteNode != null);

            // Initialize SpriteBatchNode
            pSpriteNode.Set(pBase, this);

            return pSpriteNode;
        }

        public void Remove(SpriteNode pNode)
        {
            Debug.Assert(pNode != null);
            this.baseRemove(pNode);
        }

        public void Set(SpriteNodeBatch.Name myName, int initReserve, int growthRate)
        {
            this.name = myName;

            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            this.baseSetReserve(initReserve, growthRate);


        }

        public SpriteNodeBatch GetSpriteNodeBatch()
        {
            return this.pBackSpriteBatch;
        }

        public void SetSpriteBatch(SpriteNodeBatch pSpriteBatch)
        {
            this.pBackSpriteBatch = pSpriteBatch;
        }

        public void Draw()
        {
            //grab the active list head pointer
            SpriteNode pNode = (SpriteNode)this.baseGetActive();

            //while-loop through, render each, set pointer to next
            while (pNode != null)
            {
                // render
                pNode.GetSprite().Render();

                //move to next
                pNode = (SpriteNode)pNode.pNext;
            }

        }

        public void Print()
        {
            this.basePrint();
        }
    }

}
