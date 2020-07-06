﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Glyph_DLink : DLink
    {
    }

    public class Glyph : Glyph_DLink
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public Name name;
        public int key;
        private Azul.Rect pSubRect;
        private Texture pTexture;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Consolas36pt,
            NullObject,
            Uninitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Glyph() : base()
        {
            this.name = Glyph.Name.Uninitialized;
            this.pTexture = null;
            this.pSubRect = new Azul.Rect();
            this.key = 0;
        }

        //----------------------------------------------------------------------------------
        // Get Methods
        //----------------------------------------------------------------------------------
        public Glyph.Name GetName()
        {
            return this.name;
        }
        
        public Azul.Texture GetAzulTexture()
        {
            Debug.Assert(this.pTexture != null);
            return this.pTexture.GetAzulTexture();
        }

        public Azul.Rect GetAzulSubRect()
        {
            Debug.Assert(this.pSubRect != null);
            return this.pSubRect;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void Set(Glyph.Name theName, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            this.name = theName;
            this.pTexture = TextureManager.Find(textName);
            
            Debug.Assert(this.pTexture != null);
            Debug.Assert(this.pSubRect != null);

            this.pSubRect.Set(x,y,width,height);
            this.key = key;
        }


        public void Wash()
        {
            this.name = Glyph.Name.Uninitialized;
            this.pTexture = null;
            this.pSubRect.Set(0,0,1,1);
            this.key = 0;
        }


        public void Print()
        {
            // Data:
            Debug.WriteLine("\t\tname: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("\t\t\tkey: {0}", this.key);
            if (this.pTexture != null)
            {
                Debug.WriteLine("\t\t   pTexture: {0}", this.pTexture.GetName());
            }
            else
            {
                Debug.WriteLine("\t\t   pTexture: null");
            }
            Debug.WriteLine("\t\t      pRect: {0}, {1}, {2}, {3}", this.pSubRect.x, this.pSubRect.y, this.pSubRect.width, this.pSubRect.height);
        }
    }
}
