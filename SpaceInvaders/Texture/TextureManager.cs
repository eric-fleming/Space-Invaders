using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TextureManager : Manager
    {


        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly Texture poNodeCompare;
        private static TextureManager pInstance = null;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private TextureManager(int initReserveNum = 1, int growthRate = 1)
            : base(initReserveNum, growthRate)
        {
            this.poNodeCompare = new Texture();
        }


        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------

        public static void Create(int initReserveNum = 1, int growthRate = 1)
        {
            // check valid input
            Debug.Assert(initReserveNum > 0);
            Debug.Assert(growthRate > 0);

            // this method should only be called once
            Debug.Assert(TextureManager.pInstance == null);

            // only create Texture Manager if it does not already exist.
            if(TextureManager.pInstance == null)
            {
                TextureManager.pInstance = new TextureManager(initReserveNum, growthRate);
            }

            // Include Null so it will serve weird images instead of crashing
            Texture pTexture = TextureManager.Add(Texture.Name.NullObject, "HotPink.tga");
            Debug.Assert(pTexture != null);

            // Include Default texture
            pTexture = TextureManager.Add(Texture.Name.Default, "HotPink.tga");
            Debug.Assert(pTexture != null);


        }

        public static void Destroy()
        {
            // Don't understand the motivation for wanting to destory a manager.
        }

        public static Texture Add(Texture.Name theName, string pTextureName)
        {
            // grab the manager
            TextureManager pTextMan = TextureManager.privGetInstance();

            // grab an washed DLink cast as a Texture.  It is already set in place.
            Texture pTextNode = (Texture)pTextMan.baseAdd();

            // fill with values
            Debug.Assert(pTextureName != null);
            pTextNode.Set(theName,pTextureName);

            return pTextNode;
        }

        public static void Remove(Texture pTextNode)
        {
            // grab the manager
            TextureManager pTextMan = TextureManager.privGetInstance();

            Debug.Assert(pTextMan != null);
            Debug.Assert(pTextNode != null);

            // delegate removal to the managers DLink static methods
            pTextMan.baseRemove(pTextNode);

        }

        public static Texture Find(Texture.Name targetName)
        {
            TextureManager pTextMan = TextureManager.privGetInstance();
            Debug.Assert(pTextMan != null);

            // set up the comparison node
            pTextMan.poNodeCompare.SetName(targetName);

            // delegate searching to base class
            Texture pText = (Texture)pTextMan.baseFind(pTextMan.poNodeCompare);
            return pText;
        }

        public static void Print()
        {
            TextureManager pTextMan = TextureManager.privGetInstance();
            Debug.Assert(pTextMan != null);

            pTextMan.basePrint();
        }



        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private static TextureManager privGetInstance()
        {
            // Will yell at you if you try to call this method before calling Create()
            Debug.Assert(pInstance != null);
            return pInstance;
        }


        //----------------------------------------------------------------------------------
        // Abstract Method Implementation
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pLink = new Texture();
            Debug.Assert(pLink != null);

            return pLink;
        }

        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            Texture pTA = (Texture)pLinkA;
            Texture pTB = (Texture)pLinkB;

            // result of comparison, expression results a bool
            return (pTA.GetName() == pTB.GetName());
        }

        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Texture pText = (Texture)pLink;
            pText.Print();
        }

        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Texture pText = (Texture)pLink;
            pText.Wash();
        }
    }
}
