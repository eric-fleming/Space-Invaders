using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ColPairMan_MLink : Manager
    {
        public CollPair_Link poActive;
        public CollPair_Link poReserve;
    }
    public class CollPairManager : ColPairMan_MLink
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static CollPairManager pInstance = null;
        private CollPair poNodeCompare;
        private CollPair pActiveCollPair;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private CollPairManager(int initReserve = 3, int growthRate = 1) : base()
        {
            this.baseInitialize(initReserve, growthRate);

            this.pActiveCollPair = null;

            this.poNodeCompare = new CollPair();
        }

        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static void Create(int initReserve = 3, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            Debug.Assert(pInstance == null);

            // create the one an only instance.
            if (pInstance == null)
            {
                pInstance = new CollPairManager(initReserve, growthRate);
            }
        }

        public static void Destroy()
        {
            //un-implemented at the moment.
        }

        public static CollPair GetActiveCollPair()
        {
            CollPairManager pManager = CollPairManager.privGetInstance();
            Debug.Assert(pManager != null);
            return pManager.pActiveCollPair;
        }

        public static void Process()
        {
            CollPairManager pManager = CollPairManager.privGetInstance();
            Debug.Assert(pManager != null);

            // Get ref to Active list
            CollPair pCollPair = (CollPair)pManager.baseGetActive();

            while(pCollPair != null)
            {
                //set to active
                pManager.pActiveCollPair = pCollPair;
                // Do it
                pCollPair.Process();
                // Go to next
                pCollPair = (CollPair)pCollPair.pNext;
            }
        }

        public static CollPair Add(CollPair.Name collpairName, GameObject treeRootA, GameObject treeRootB)
        {
            CollPairManager pManager = CollPairManager.privGetInstance();
            Debug.Assert(pManager != null);

            // Grab off the reserve
            CollPair pCollPair = (CollPair)pManager.baseAdd();
            Debug.Assert(pCollPair != null);

            pCollPair.Set(collpairName, treeRootA, treeRootB);

            return pCollPair;

        }

        public static void Remove(CollPair pNode)
        {
            CollPairManager pManager = CollPairManager.privGetInstance();
            Debug.Assert(pManager != null);
            Debug.Assert(pNode != null);

            // delegate to abstract manager who deals with the DLinks
            pManager.baseRemove(pNode);

        }

        public static CollPair Find(CollPair.Name theName)
        {
            CollPairManager pManager = CollPairManager.privGetInstance();
            Debug.Assert(pManager != null);

            // set common compare node, static object ref
            pManager.poNodeCompare.SetName(theName);

            //find and return ref
            CollPair pNode = (CollPair)pManager.baseFind(pManager.poNodeCompare);
            Debug.Assert(pNode != null);
            return pNode;
        }

        public static void Print()
        {
            CollPairManager pManager = CollPairManager.privGetInstance();
            Debug.Assert(pManager != null);
            pManager.basePrint();
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new CollPair();
            Debug.Assert(pNode != null);

            return pNode;

        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            CollPair pA = (CollPair)pLinkA;
            CollPair pB = (CollPair)pLinkB;

            // result of comparison, expression results a bool
            return (pA.GetName() == pB.GetName());
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            CollPair pNode = (CollPair)pLink;
            pNode.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            CollPair pNode = (CollPair)pLink;
            pNode.Print();
        }


        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private static CollPairManager privGetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }
    }
}
