using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SpriteNodeBatchManager_MLink : Manager
    {
        public SpriteNodeBatch_Link poActive = null;
        public SpriteNodeBatch_Link poReserve = null;
    }

    public class SpriteNodeBatchManager : SpriteNodeBatchManager_MLink
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static SpriteNodeBatch poCompare;
        private static SpriteNodeBatchManager pInstance = null;
        private static SpriteNodeBatchManager pActiveSBManager = null;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteNodeBatchManager(int reserveNum = 3, int reserveGrow = 1)
        : base()
        {
            // At this point SpriteBatchMan is created, now initialize the reserve
            this.baseInitialize(reserveNum, reserveGrow);

            SpriteNodeBatchManager.pActiveSBManager = null;
            SpriteNodeBatchManager.poCompare = new SpriteNodeBatch();

        }

        private SpriteNodeBatchManager()
        : base()
        {
            SpriteNodeBatchManager.pActiveSBManager = null;
            SpriteNodeBatchManager.poCompare = new SpriteNodeBatch();
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        //public static void Create(int reserveNum = 3, int reserveGrow = 1)
        //{
        //    // make sure values are ressonable 
        //    Debug.Assert(reserveNum > 0);
        //    Debug.Assert(reserveGrow > 0);

        //    // initialize the singleton here
        //    Debug.Assert(pInstance == null);

        //    // Do the initialization
        //    if (pInstance == null)
        //    {
        //        pInstance = new SpriteNodeBatchManager(reserveNum, reserveGrow);
        //    }


        //}

        public static void Create()
        {
            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new SpriteNodeBatchManager();
            }


        }

        public static void Destroy()
        {
            SpriteNodeBatchManager pMan = SpriteNodeBatchManager.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton

        }

        public static void SetActive(SpriteNodeBatchManager pSBMan)
        {
            SpriteNodeBatchManager pMan = SpriteNodeBatchManager.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSBMan != null);
            SpriteNodeBatchManager.pActiveSBManager = pSBMan;
        }

        public static SpriteNodeBatch Add(SpriteNodeBatch.Name name, int reserveNum = 3, int reserveGrow = 1)
        {
            //SpriteNodeBatchManager pMan = SpriteNodeBatchManager.privGetInstance();
            SpriteNodeBatchManager pMan = SpriteNodeBatchManager.pActiveSBManager;
            Debug.Assert(pMan != null);

            SpriteNodeBatch pNode = (SpriteNodeBatch)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, reserveNum, reserveGrow);
            return pNode;
        }

        public static void Draw()
        {
            //SpriteNodeBatchManager pMan = SpriteNodeBatchManager.privGetInstance();
            SpriteNodeBatchManager pMan = SpriteNodeBatchManager.pActiveSBManager;
            Debug.Assert(pMan != null);

            // walk through the list and render
            SpriteNodeBatch pSpriteBatch = (SpriteNodeBatch)pMan.baseGetActive();

            while (pSpriteBatch != null)
            {
                // Delegate
                pSpriteBatch.Draw();

                // Iterate
                pSpriteBatch = (SpriteNodeBatch)pSpriteBatch.pNext;
            }

        }

        public static SpriteNodeBatch Find(SpriteNodeBatch.Name name)
        {
            //SpriteNodeBatchManager pMan = SpriteNodeBatchManager.privGetInstance();
            SpriteNodeBatchManager pMan = SpriteNodeBatchManager.pActiveSBManager;
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            SpriteNodeBatchManager.poCompare.SetName(name);

            SpriteNodeBatch pData = (SpriteNodeBatch)pMan.baseFind(SpriteNodeBatchManager.poCompare);
            return pData;
        }
        public static void Remove(SpriteNodeBatch pNode)
        {
            //SpriteNodeBatchManager pMan = SpriteNodeBatchManager.privGetInstance();
            SpriteNodeBatchManager pMan = SpriteNodeBatchManager.pActiveSBManager;
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Remove(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            SpriteNodeManager pSpriteNodeMan = pSpriteBatchNode.GetSBNodeMan();

            Debug.Assert(pSpriteNodeMan != null);
            pSpriteNodeMan.Remove(pSpriteBatchNode);
        }

        public static void Dump()
        {
            SpriteNodeBatchManager pMan = SpriteNodeBatchManager.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.basePrint();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new SpriteNodeBatch();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            SpriteNodeBatch pDataA = (SpriteNodeBatch)pLinkA;
            SpriteNodeBatch pDataB = (SpriteNodeBatch)pLinkB;

            Boolean status = false;

            if (pDataA.GetName() == pDataB.GetName())
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SpriteNodeBatch pNode = (SpriteNodeBatch)pLink;
            pNode.Wash();
        }
        override protected void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SpriteNodeBatch pData = (SpriteNodeBatch)pLink;
            pData.Print();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static SpriteNodeBatchManager privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }
    }
}
