using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class GameSpriteManager_MLink : Manager
    {
        public GameSprite_Base poActive;
        public GameSprite_Base poReserve;
    }

    class GameSpriteManager : GameSpriteManager_MLink
    {
        //----------------------------------------------------------------------------------
        //    Data
        //----------------------------------------------------------------------------------
        private static GameSpriteManager pInstance = null;
        private readonly GameSprite poNodeCompare;

        //----------------------------------------------------------------------------------
        //    Constructors
        //----------------------------------------------------------------------------------
        private GameSpriteManager(int initReserve = 3, int growthRate = 1) : base()
        {
            // Mostly constructed by abstract manager
            this.baseInitialize(initReserve, growthRate);
            //specific to this manager
            this.poNodeCompare = new GameSprite();
        }

        //----------------------------------------------------------------------------------
        //    Static Methods
        //----------------------------------------------------------------------------------
        public static void Create(int initReserve = 3, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            Debug.Assert(GameSpriteManager.pInstance == null);

            // create the one an only instance.
            if(GameSpriteManager.pInstance == null)
            {
                GameSpriteManager.pInstance = new GameSpriteManager(initReserve, growthRate);
            }

            // Include a Null GameSprite Object
            GameSprite pGSprite = GameSpriteManager.Add(GameSprite.Name.NullObject,Image.Name.NullObject,0,0,0,0);
            Debug.Assert(pGSprite != null);
        }

        public static void Destroy()
        {
            //un-implemented at the moment.
        }

        public static GameSprite Add(GameSprite.Name spName, Image.Name imgName, float x, float y, float w, float h, Azul.Color pColor = null)
        {
            GameSpriteManager pManager = GameSpriteManager.privGetInstance();
            Debug.Assert(pManager != null);

            //grab a DLink
            GameSprite pSprite = (GameSprite)pManager.baseAdd();
            Debug.Assert(pSprite != null);

            //initialize
            Image pImage = ImageManager.Find(imgName);
            Debug.Assert(pImage != null);

            pSprite.Set(spName,pImage,x,y,w,h,pColor);

            return pSprite;

        }

        public static void Remove(GameSprite pSprite)
        {
            GameSpriteManager pManager = GameSpriteManager.privGetInstance();
            
            Debug.Assert(pManager != null);
            Debug.Assert(pSprite != null);

            // delegate to abstract manager who deals with the DLinks
            pManager.baseRemove(pSprite);

        }

        public static GameSprite Find(GameSprite.Name theName)
        {
            GameSpriteManager pSpriteManager = GameSpriteManager.privGetInstance();
            Debug.Assert(pSpriteManager != null);

            // set common compare node, static object ref
            pSpriteManager.poNodeCompare.SetName(theName);

            //find and return ref
            GameSprite pSprite = (GameSprite)pSpriteManager.baseFind(pSpriteManager.poNodeCompare);
            return pSprite;
        }

        public static void Print()
        {
            GameSpriteManager pManager = GameSpriteManager.privGetInstance();
            pManager.basePrint();
        }
        //----------------------------------------------------------------------------------
        //    Abstract Methods
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pSprite = new GameSprite();
            Debug.Assert(pSprite != null);

            return pSprite;
            
        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            GameSprite pGSA = (GameSprite)pLinkA;
            GameSprite pGSB = (GameSprite)pLinkB;

            // result of comparison, expression results a bool
            return (pGSA.GetName() == pGSB.GetName());
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameSprite pSprite = (GameSprite)pLink;
            pSprite.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameSprite pSprite = (GameSprite)pLink;
            pSprite.Print();
        }

        //----------------------------------------------------------------------------------
        //     Private Singleton Methods
        //----------------------------------------------------------------------------------

        private static GameSpriteManager privGetInstance()
        {
            Debug.Assert(pInstance != null);

            return GameSpriteManager.pInstance;
        }


    }
}
