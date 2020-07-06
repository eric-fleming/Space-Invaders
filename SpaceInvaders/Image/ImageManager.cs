using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageManager : Manager
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static ImageManager pInstance = null;
        private readonly Image poNodeCompare;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private ImageManager(int initReserve = 3, int growthRate = 1)
        : base(initReserve, growthRate)
        {
            // most of the work is carried out by base class

            this.poNodeCompare = new Image();
        }


        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static void Create(int initReserve = 3, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            // init
            Debug.Assert(pInstance == null);
            if(pInstance == null)
            {
                ImageManager.pInstance = new ImageManager(initReserve, growthRate);
            }

            //Include a NullObject Image
            Image pImage = ImageManager.Add(Image.Name.NullObject,Texture.Name.NullObject,0,0,128,128);
            Debug.Assert(pImage != null);

            //Include a Default Image
            pImage = ImageManager.Add(Image.Name.Default, Texture.Name.Default, 0, 0, 128, 128);
            Debug.Assert(pImage != null);


        }

        public static void Destroy()
        {
            // unimplemented
        }

        public static Image Add(Image.Name imgName, Texture.Name textName, float x, float y, float width, float height)
        {
            ImageManager pImgManager = ImageManager.privGetInstance();
            Debug.Assert(pImgManager != null);

            // grab an blank imgage node
            Image pImgNode = (Image)pImgManager.baseAdd();
            Debug.Assert(pImgNode != null);

            // find the corresponding texture pointer
            Texture pTexture = TextureManager.Find(textName);
            Debug.Assert(pTexture != null);


            //configure the image node
            pImgNode.Set(imgName,pTexture,x,y,width,height);

            return pImgNode;

        }

        public static void Remove(Image pImgNode)
        {
            ImageManager pImageManager = ImageManager.privGetInstance();
            
            Debug.Assert(pImageManager != null);
            Debug.Assert(pImgNode != null);

            pImageManager.baseRemove(pImgNode);
        }

        public static Image Find(Image.Name theName)
        {
            ImageManager pManager = ImageManager.privGetInstance();
            Debug.Assert(pManager != null);

            // set the static compare object for use
            pManager.poNodeCompare.SetName(theName);

            Image pImg = (Image)pManager.baseFind(pManager.poNodeCompare);
            return pImg;

        }

        public static void Print()
        {
            ImageManager pImgManager = ImageManager.privGetInstance();
            Debug.Assert(pImgManager != null);

            pImgManager.basePrint();
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pImgNode = new Image();
            Debug.Assert(pImgNode != null);

            return pImgNode;
        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            Image pImgA = (Image)pLinkA;
            Image pImgB = (Image)pLinkB;

            // result of comparison, expression results a bool
            return (pImgA.GetName() == pImgB.GetName());
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Image pImgNode = (Image)pLink;
            pImgNode.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Image pImgNode = (Image)pLink;
            pImgNode.Print();
        }

        //----------------------------------------------------------------------------------
        // Private Singleton Methods
        //----------------------------------------------------------------------------------

        private static ImageManager privGetInstance()
        {
            Debug.Assert(pInstance != null);
            return ImageManager.pInstance;
        }
    }
}
