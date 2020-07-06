using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ProxySpriteManager_MLink : Manager
    {
        public ProxySprite_Base poActive;
        public ProxySprite_Base poReserve;
    }

    class ProxySpriteManager : ProxySpriteManager_MLink
    {

        //----------------------------------------------------------------------------------
        //    Data
        //----------------------------------------------------------------------------------
        private static ProxySpriteManager pInstance = null;
        private ProxySprite poNodeCompare;

        //----------------------------------------------------------------------------------
        //    Constructor
        //----------------------------------------------------------------------------------
        private ProxySpriteManager(int initReserve = 3, int growthRate = 1) : base()
        {
            this.baseInitialize(initReserve, growthRate);
            this.poNodeCompare = new ProxySprite();
        }

        ~ProxySpriteManager()
        {
            // what does this do??
        }

        //----------------------------------------------------------------------------------
        //    Static Methods
        //----------------------------------------------------------------------------------
        public static void Create(int initReserve = 3, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            Debug.Assert(ProxySpriteManager.pInstance == null);

            // create the one an only instance.
            if (ProxySpriteManager.pInstance == null)
            {
                ProxySpriteManager.pInstance = new ProxySpriteManager(initReserve, growthRate);
            }
        }

        public static void Destroy()
        {
            //un-implemented at the moment.
        }


        public static ProxySprite Add(GameSprite.Name theName)
        {
            ProxySpriteManager pManager = ProxySpriteManager.privGetInstance();
            Debug.Assert(pManager != null);

            //grab a DLink
            ProxySprite pSprite = (ProxySprite)pManager.baseAdd();
            Debug.Assert(pSprite != null);

            //initialize
            pSprite.Set(theName);

            return pSprite;

        }

        public static void Remove(ProxySprite pSprite)
        {
            ProxySpriteManager pManager = ProxySpriteManager.privGetInstance();
            
            Debug.Assert(pManager != null);
            Debug.Assert(pSprite != null);

            // delegate to abstract manager who deals with the DLinks
            pManager.baseRemove(pSprite);

        }

        public static ProxySprite Find(ProxySprite.Name theName)
        {
            ProxySpriteManager pSpriteManager = ProxySpriteManager.privGetInstance();
            Debug.Assert(pSpriteManager != null);

            // set common compare node, static object ref
            pSpriteManager.poNodeCompare.SetName(theName);

            //find and return ref
            ProxySprite pSprite = (ProxySprite)pSpriteManager.baseFind(pSpriteManager.poNodeCompare);
            return pSprite;
        }

        public static void Print()
        {
            ProxySpriteManager pManager = ProxySpriteManager.privGetInstance();
            pManager.basePrint();
        } 
        



        //----------------------------------------------------------------------------------
        //    Abstract Methods
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pSprite = new ProxySprite();
            Debug.Assert(pSprite != null);

            return pSprite;

        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            ProxySprite pProxSA = (ProxySprite)pLinkA;
            ProxySprite pProxSB = (ProxySprite)pLinkB;

            // result of comparison, expression results a bool
            return (pProxSA.GetName() == pProxSB.GetName());
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ProxySprite pSprite = (ProxySprite)pLink;
            pSprite.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ProxySprite pSprite = (ProxySprite)pLink;
            pSprite.Print();
        }

        //----------------------------------------------------------------------------------
        //    private Methods
        //----------------------------------------------------------------------------------
        private static ProxySpriteManager privGetInstance()
        {
            Debug.Assert(pInstance != null);
            return ProxySpriteManager.pInstance;
        }
    }
}
