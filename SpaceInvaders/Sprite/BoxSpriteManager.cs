using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BoxSpriteManager_MLink : Manager
    {
        public BoxSprite_Base poActive;
        public BoxSprite_Base poReserve;
    }
    class BoxSpriteManager : BoxSpriteManager_MLink
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static BoxSpriteManager pInstance = null;

        private readonly BoxSprite poNodeCompare;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private BoxSpriteManager(int initReserve = 3, int growthRate = 1) : base()
        {
            // initializes the base class
            this.baseInitialize(initReserve, growthRate);

            // initializes the derived class
            this.poNodeCompare = new BoxSprite();
        }


        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static void Create(int initReserve = 3, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            Debug.Assert(BoxSpriteManager.pInstance == null);

            // create the one an only instance.
            if (BoxSpriteManager.pInstance == null)
            {
                BoxSpriteManager.pInstance = new BoxSpriteManager(initReserve, growthRate);
            }
        }

        public static void Destroy()
        {
            // Unimplemented
        }

        public static BoxSprite Add(BoxSprite.Name theName, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            BoxSpriteManager pBoxMan = BoxSpriteManager.privGetInstance();
            Debug.Assert(pBoxMan != null);

            BoxSprite pNode = (BoxSprite)pBoxMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(theName,x,y,width,height,pColor);
            return pNode;
        }

        public static BoxSprite Find(BoxSprite.Name theName)
        {
            BoxSpriteManager pBoxMan = BoxSpriteManager.privGetInstance();
            Debug.Assert(pBoxMan != null);

            pBoxMan.poNodeCompare.SetName(theName);

            BoxSprite pBoxSprite = (BoxSprite)pBoxMan.baseFind(pBoxMan.poNodeCompare);
            return pBoxSprite;
        }

        public static void Remove(BoxSprite pBoxSprite)
        {
            BoxSpriteManager pBoxMan = BoxSpriteManager.privGetInstance();
            Debug.Assert(pBoxMan != null);

            Debug.Assert(pBoxSprite != null);
            pBoxMan.baseRemove(pBoxSprite);
        }

        public static void Print()
        {
            BoxSpriteManager pBoxMan = BoxSpriteManager.privGetInstance();
            Debug.Assert(pBoxMan != null);
            pBoxMan.basePrint();
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        

        protected override DLink derivedCreateNode()
        {
            DLink pBoxSprite = new BoxSprite();
            Debug.Assert(pBoxSprite != null);

            return pBoxSprite;
            
        }

        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            BoxSprite pBSA = (BoxSprite)pLinkA;
            BoxSprite pBSB = (BoxSprite)pLinkB;

            // result of comparison, expression results a bool
            return (pBSA.GetName() == pBSB.GetName());
        }

        

        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            BoxSprite pBoxSprite = (BoxSprite)pLink;
            pBoxSprite.Wash();
        }

        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            BoxSprite pBoxSprite = (BoxSprite)pLink;
            pBoxSprite.Print();
        }

        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------

        private static BoxSpriteManager privGetInstance()
        {
            Debug.Assert(pInstance != null);

            return BoxSpriteManager.pInstance;
        }

        
    }
}
