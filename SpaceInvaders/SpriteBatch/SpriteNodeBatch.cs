using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SpriteNodeBatch_Link : DLink
    {

    }
    public class SpriteNodeBatch : SpriteNodeBatch_Link
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private SpriteNodeBatch.Name name;
        private bool bDrawStatus;
        private readonly SpriteNodeManager poSpriteNodeManager;

        //----------------------------------------------------------------------------------
        // Enum - same as Texture Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Default,
            Boxes,
            Explosions,
            TheSwarm,
            Invaders,
            Players,
            Shields,
            Texts,
            Uninitialized,

        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SpriteNodeBatch() : base()
        {
            //delegates first to construct a DLink, then fills these fields
            this.name = SpriteNodeBatch.Name.Uninitialized;
            this.bDrawStatus = true;
            this.poSpriteNodeManager = new SpriteNodeManager();

            Debug.Assert(this.poSpriteNodeManager != null);
        }


        //----------------------------------------------------------------------------------
        // Set Methods
        //----------------------------------------------------------------------------------

        public void Set(SpriteNodeBatch.Name myName, int initReserve = 3, int growthRate = 1)
        {
            this.name = myName;
            this.bDrawStatus = true;
            this.poSpriteNodeManager.Set(myName, initReserve, growthRate);

        }

        public void SetName(SpriteNodeBatch.Name myName)
        {
            this.name = myName;
        }

        public void SetDrawStatus(bool b)
        {
            this.bDrawStatus = b;
        }

        

        //----------------------------------------------------------------------------------
        // Getter Methods
        //----------------------------------------------------------------------------------

        public SpriteNodeBatch.Name GetName()
        {
            return this.name;
        }

        public bool GetDrawStatus()
        {
            return this.bDrawStatus;
        }


        public SpriteNodeManager GetSpriteNodeManager()
        {
            return this.poSpriteNodeManager;
        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void Attach(SpriteBase pBase)
        {
            Debug.Assert(this.poSpriteNodeManager != null);
            Debug.Assert(pBase != null);

            SpriteNode pSBNode = (SpriteNode)this.poSpriteNodeManager.Attach(pBase);
            Debug.Assert(pSBNode != null);

            // Initialize SpriteBatchNode
            pSBNode.Set(pBase, this.poSpriteNodeManager);

            // Back pointer
            this.poSpriteNodeManager.SetSpriteBatch(this);
        }

        public void Detach(SpriteBase pBase)
        {
            SpriteNode pNode = pBase.GetBackSpriteNode();
            SpriteNodeManager pMySBNManager = this.GetSpriteNodeManager();
            pMySBNManager.Remove(pNode);
        }

        public void Draw()
        {
            // Check status
            if (this.bDrawStatus)
            {
                // Delegate to the SpriteNodeManager
                this.poSpriteNodeManager.Draw();
            }
        }

        public void Wash()
        {
            // Do batches get washed??


            //this.name = SpriteNodeBatch.Name.Default;
            //Debug.Assert(this.pSpriteNodeManager != null);

            // probably need to wash all the nodes on active DLink and move to reserve
            
        }

        public void Print()
        {
            //delegate to the Node Managers Print method.
            this.poSpriteNodeManager.Print();
        }
    }
}
