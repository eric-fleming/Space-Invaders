using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class FontMan_MLink : Manager
    {
        public Font_DLink poActive;
        public Font_DLink poReserve;
    }
    public class FontManager : FontMan_MLink
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static FontManager pInstance = null;
        private Font pRefNode;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private FontManager(int initReserve = 3, int growthRate = 1)
            : base()
        {
            this.baseInitialize(initReserve, growthRate);
            this.pRefNode = (Font)this.derivedCreateNode();
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
                pInstance = new FontManager(initReserve, growthRate);
            }
        }

        public static void Destroy()
        {

        }

        public static void AddXML(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            GlyphManager.AddXml(glyphName, assetName, textName);
        }

        public static Font Add(Font.Name fontName, SpriteNodeBatch.Name SpriteBatch_Name, String pMessage, Glyph.Name glyphName, float px, float py)
        {
            FontManager pManager = FontManager.privGetInstance();

            Font pNode = (Font)pManager.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(fontName, pMessage, glyphName, px, py);

            // Add to sprite batch
            SpriteNodeBatch pSriteBatch = SpriteNodeBatchManager.Find(SpriteBatch_Name);
            Debug.Assert(pSriteBatch != null);
            Debug.Assert(pNode.pFontSprite != null);
            pSriteBatch.Attach(pNode.pFontSprite);

            return pNode;
        }

        public static void Remove(Font pNode)
        {
            Debug.Assert(pNode != null);
            FontManager pManager = FontManager.privGetInstance();
            pManager.baseRemove(pNode);
        }

        public static Font Find(Font.Name fontName)
        {
            FontManager pManager = FontManager.privGetInstance();

            // Compare functions only compares two Nodes
            pManager.pRefNode.name = fontName;

            Font pData = (Font)pManager.baseFind(pManager.pRefNode);
            return pData;
        }

        public static void Print()
        {
            FontManager pManager = FontManager.privGetInstance();
            Debug.Assert(pManager != null);

            Debug.WriteLine("------ Font Manager ------");
            pManager.basePrint();
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Font();
            Debug.Assert(pNode != null);

            return pNode;

        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            Font pDataA = (Font)pLinkA;
            Font pDataB = (Font)pLinkB;

            // result of comparison, expression results a bool
            return (pDataA.name == pDataB.name);

        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Font pNode = (Font)pLink;
            pNode.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Font pNode = (Font)pLink;
            pNode.Print();
        }

        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private static FontManager privGetInstance()
        {
            // Must Call Create first
            Debug.Assert(pInstance != null);
            return pInstance;
        }
    }
}
