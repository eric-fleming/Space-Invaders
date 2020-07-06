using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class GameObjectMan_MLink : Manager
    {
        public GameObjectNode_Link poActive;
        public GameObjectNode_Link poReserve;
    }
    public class GameObjectManager : GameObjectMan_MLink
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static GameObjectManager pInstance = null;
        private static GameObjectManager pActiveManager = null;

        private readonly NullGameObject poNullGameObject;
        private GameObjectNode poNodeCompare;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public GameObjectManager(int initReserve = 3, int growthRate = 1) : base()
        {
            // abstract manager fields
            this.baseInitialize(initReserve, growthRate);

            //class fields
            this.poNullGameObject = new NullGameObject();
            this.poNodeCompare = new GameObjectNode();

            this.poNodeCompare.poGameObj = this.poNullGameObject;
        }
        
        private GameObjectManager() : base()
        {
            //class fields
            this.poNullGameObject = new NullGameObject();
            this.poNodeCompare = new GameObjectNode();

            this.poNodeCompare.poGameObj = this.poNullGameObject;

        }

        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        //public static void Create(int initReserve = 3, int growthRate = 1)
        //{
        //    // pre-conditions
        //    Debug.Assert(initReserve > 0);
        //    Debug.Assert(growthRate > 0);

        //    Debug.Assert(pInstance == null);

        //    // create the one an only instance.
        //    if (pInstance == null)
        //    {
        //        pInstance = new GameObjectManager(initReserve, growthRate);
        //    }
        //}

        public static void Create()
        {
            Debug.Assert(pInstance == null);

            // create the one an only instance.
            if (pInstance == null)
            {
                pInstance = new GameObjectManager();
            }
        }

        public static void Destroy()
        {
            //un-implemented at the moment.
        }

        public static void SetActive(GameObjectManager pGameMan)
        {
            GameObjectManager pManager = GameObjectManager.privGetInstance();
            Debug.Assert(pManager != null);

            Debug.Assert(pGameMan != null);
            GameObjectManager.pActiveManager = pGameMan;
        }


        public static GameObjectNode Attach(GameObject pGameOject)
        {
            GameObjectManager pMan = GameObjectManager.pActiveManager;
            Debug.Assert(pMan != null);

            //grab a DLink
            GameObjectNode pNode = (GameObjectNode)pMan.baseAdd();
            Debug.Assert(pNode != null);

            //initialize
            pNode.Set(pGameOject);
            return pNode;

        }

        public static void Remove(GameObjectNode pNode)
        {
            GameObjectManager pMan = GameObjectManager.pActiveManager;
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Remove(GameObject pNode)
        {
            // Keenan(delete.E)
            Debug.Assert(pNode != null);
            GameObjectManager pMan = GameObjectManager.pActiveManager;
            Debug.Assert(pMan != null);

            GameObject pSafetyNode = pNode;

            // OK so we have a linked list of trees (Remember that)

            // 1) find the tree root (we already know its the most parent)

            GameObject pTmp = pNode;
            GameObject pRoot = null;
            while (pTmp != null)
            {
                pRoot = pTmp;
                pTmp = (GameObject)Iterator.GetParent(pTmp);
            }

            // 2) pRoot is the tree we are looking for
            // now walk the active list looking for pRoot

            GameObjectNode pTree = (GameObjectNode)pMan.baseGetActive();

            while (pTree != null)
            {
                if (pTree.poGameObj == pRoot)
                {
                    // found it
                    break;
                }
                // Goto Next tree
                pTree = (GameObjectNode)pTree.pNext;
            }

            // 3) pTree is the tree that holds pNode
            //  Now remove the node from that tree

            Debug.Assert(pTree != null);
            Debug.Assert(pTree.poGameObj != null);

            // Is pTree.poGameObj same as the node we are trying to delete?
            // Answer: should be no... since we always have a group (that was a good idea)

            Debug.Assert(pTree.poGameObj != pNode);

            GameObject pParent = (GameObject)Iterator.GetParent(pNode);
            Debug.Assert(pParent != null);

            // Make sure there is no child before the delete
            GameObject pChild = (GameObject)Iterator.GetChild(pNode);
            Debug.Assert(pChild == null);

            // remove the node
            pParent.Remove(pNode);

            // FOUND the bug!!!!
            pParent.Update();

            // TODO - Recycle pNode

        }


        public static GameObject Find(GameObject.Name theName)
        {
            GameObjectManager pMan = GameObjectManager.pActiveManager;
            Debug.Assert(pMan != null);

            // set common compare node, static object ref
            pMan.poNodeCompare.poGameObj.SetName(theName);

            //find and return ref
            GameObjectNode pNode = (GameObjectNode)pMan.baseFind(pMan.poNodeCompare);
            Debug.Assert(pNode != null);
            return pNode.poGameObj;
        }

        public static void Update()
        {
            GameObjectManager pMan = GameObjectManager.pActiveManager;
            Debug.Assert(pMan != null);

            // Debug.WriteLine("---------------");

            GameObjectNode pGameObjectNode = (GameObjectNode)pMan.baseGetActive();

            while (pGameObjectNode != null)
            {
                // Debug.WriteLine("update: GameObjectTree {0} ({1})", pGameObjectNode.poGameObj, pGameObjectNode.poGameObj.GetHashCode());
                // Debug.WriteLine("   +++++");
                ReverseIterator pRev = new ReverseIterator(pGameObjectNode.poGameObj);

                Component pNode = pRev.First();
                while (!pRev.IsDone())
                {
                    GameObject pGameObj = (GameObject)pNode;

                    //   Debug.WriteLine("update: {0} ({1})", pGameObj, pGameObj.GetHashCode());
                    pGameObj.Update();

                    pNode = pRev.Next();
                }

                // Debug.WriteLine("   ------");
                pGameObjectNode = (GameObjectNode)pGameObjectNode.pNext;
            }

        }

        public static void Print()
        {
            GameObjectManager pMan = GameObjectManager.pActiveManager;
            Debug.Assert(pMan != null);
            pMan.basePrint();
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new GameObjectNode();
            Debug.Assert(pNode != null);

            return pNode;

        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            GameObjectNode pGameObjA = (GameObjectNode)pLinkA;
            GameObjectNode pGameObjB = (GameObjectNode)pLinkB;

            // result of comparison, expression results a bool
            return (pGameObjA.poGameObj.GetName() == pGameObjB.poGameObj.GetName());
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameObjectNode pNode = (GameObjectNode)pLink;
            pNode.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameObjectNode pNode = (GameObjectNode)pLink;
            pNode.Print();
        }


        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private static GameObjectManager privGetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }
    }
}
