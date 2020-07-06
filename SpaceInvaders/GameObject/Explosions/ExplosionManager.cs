using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ExplosionManager : Manager
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        //private static ExplosionManager pInstance = null;
        private readonly Explosion poNodeCompare;
        private readonly ExplosionFactory pParentFactory;
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionManager(ExplosionFactory pFactory, int initReserve = 3, int growthRate = 1)
        : base(initReserve, growthRate)
        {
            // most of the work is carried out by base class
            //this.baseInitialize();
            this.pParentFactory = pFactory;
            this.poNodeCompare = new Explosion();
        }




        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------

        //public static void Create(ExplosionFactory pFactory ,int initReserve = 3, int growthRate = 1)
        //{
        //    // pre-conditions
        //    Debug.Assert(initReserve > 0);
        //    Debug.Assert(growthRate > 0);

        //    // init
        //    Debug.Assert(pInstance == null);
        //    if (pInstance == null)
        //    {
        //        ExplosionManager.pInstance = new ExplosionManager(pFactory,initReserve, growthRate);
        //    }


        //}

        public static void Destroy()
        {
            // unimplemented
        }

        public Explosion Add(GameObject.Name gameName, GameSprite.Name spriteName, float px = 0.0f, float py = 0.0f)
        {
            //ExplosionManager pManager = ExplosionManager.privGetInstance();
            //Debug.Assert(pManager != null);

            // Grab an blank Explosion node
            Explosion pNode = (Explosion)this.baseAdd();
            Debug.Assert(pNode != null);

            //configure the image node
            pNode.Set(gameName, spriteName, px, py);

            return pNode;

        }

        public void Remove(GameObject pNode)
        {
            //ExplosionManager pManager = ExplosionManager.privGetInstance();
            //Debug.Assert(pManager != null);

            //Debug.Assert(pManager != null);
            Debug.Assert(pNode != null);

            this.baseRemove(pNode);
        }

        public Explosion Find(GameObject.Name theName)
        {
            //ExplosionManager pManager = ExplosionManager.privGetInstance();
            //Debug.Assert(pManager != null);

            // set the static compare object for use
            this.poNodeCompare.SetName(theName);

            Explosion pNode = (Explosion)this.baseFind(this.poNodeCompare);
            return pNode;

        }

        public void Print()
        {
            //ExplosionManager pManager = ExplosionManager.privGetInstance();
            //Debug.Assert(pManager != null);

            this.basePrint();
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Explosion();
            Debug.Assert(pNode != null);

            return pNode;

        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            Explosion pGameObjA = (Explosion)pLinkA;
            Explosion pGameObjB = (Explosion)pLinkB;

            // result of comparison, expression results a bool
            return (pGameObjA.GetName() == pGameObjB.GetName());
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Explosion pNode = (Explosion)pLink;
            pNode.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Explosion pNode = (Explosion)pLink;
            pNode.Print();
        }

        //----------------------------------------------------------------------------------
        // Private Singleton Methods
        //----------------------------------------------------------------------------------

        //private static ExplosionManager privGetInstance()
        //{
        //    Debug.Assert(pInstance != null);
        //    return ExplosionManager.pInstance;
        //}
    }
}
