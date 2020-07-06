using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class GlyphMan_MLink : Manager
    {
        public Glyph_DLink poActive;
        public Glyph_DLink poReserve;
    }
    class GlyphManager : GlyphMan_MLink
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static GlyphManager pInstance = null;
        private Glyph pRefNode;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private GlyphManager(int initReserve = 36, int growthRate = 1)
            : base()
        {
            //A-Z and 0-9
            this.baseInitialize(initReserve, growthRate);
            this.pRefNode = (Glyph)this.derivedCreateNode();
        }

        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static void Create(int initReserve = 36, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            Debug.Assert(pInstance == null);

            // create the one an only instance.
            if (pInstance == null)
            {
                pInstance = new GlyphManager(initReserve, growthRate);
            }
        }

        public static void Destroy()
        {

        }

        public static Glyph Add(Glyph.Name glyphName, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphManager pManager = GlyphManager.privGetInstance();

            Glyph pNode = (Glyph)pManager.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(glyphName, key, textName,x,y,width,height);
            return pNode;
        }

        public static void AddXml(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            // I'm sure there is a better way to do this... but this works for now
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {
                            // have all the data... so now create a glyph
                            //Debug.WriteLine("key:{0} x:{1} y:{2} w:{3} h:{4}", key, x, y, width, height);
                            GlyphManager.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }

            Debug.Write("Loaded Glyphs : AddXML()  COMPLETE!\n");
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            GlyphManager pManager = GlyphManager.privGetInstance();
            pManager.baseRemove(pNode);
        }

        public static Glyph Find(Glyph.Name name, int key)
        {
            GlyphManager pManager = GlyphManager.privGetInstance();
            // Compare functions only compares two Nodes
            pManager.pRefNode.name = name;
            pManager.pRefNode.key = key;

            Glyph pData = (Glyph)pManager.baseFind(pManager.pRefNode);
            return pData;
        }

        public static void Print()
        {
            GlyphManager pManager = GlyphManager.privGetInstance();
            Debug.Assert(pManager != null);

            Debug.WriteLine("------ Glyph Manager ------");
            pManager.basePrint();
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Glyph();
            Debug.Assert(pNode != null);

            return pNode;

        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            Glyph pGlyphA = (Glyph)pLinkA;
            Glyph pGlyphB = (Glyph)pLinkB;

            // result of comparison, expression results a bool
            bool nameCompare = pGlyphA.GetName() == pGlyphB.GetName();
            bool keyCompare = pGlyphA.key == pGlyphB.key;

            return (nameCompare && keyCompare);
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Glyph pNode = (Glyph)pLink;
            pNode.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Glyph pNode = (Glyph)pLink;
            pNode.Print();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GlyphManager privGetInstance()
        {
            // Must call Create() before it can be used
            Debug.Assert(pInstance != null);
            return pInstance;
        }
    }
}
