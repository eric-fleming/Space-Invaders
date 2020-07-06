using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Image : DLink
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private Name name;
        private Texture pTexture;
        private readonly Azul.Rect poRect;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            OctopusA,
            OctopusB,
            AlienA,
            AlienB,
            SquidA,
            SquidB,
            AlienExplosion,
            Saucer,
            SaucerExplosion,
            
            Player,
            Ship,
            ShipExplosionA,
            ShipExplosionB,
            Missile,
            MissileExplosion,

            BombStraight,
            BombZigZagA,
            BombZigZagB,
            BombZigZagC,
            BombZigZagD,
            BombDaggerA,
            BombDaggerB,
            BombDaggerC,
            BombDaggerD,
            BombRollingA,
            BombRollingB,
            BombRollingC,
            BombRollingD,
            BombExplosion,

            Wall,

            Brick,
            BrickLeft_Top0,
            BrickLeft_Top1,
            BrickLeft_Bottom,
            BrickRight_Top0,
            BrickRight_Top1,
            BrickRight_Bottom,

            Default,
            NullObject,
            Uninitialized
        }


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Image(Name myName, Texture pSrcTexture, Azul.Rect pSubRect)
        {
            Debug.Assert(pSrcTexture != null);
            Debug.Assert(pSubRect != null);

            this.name = myName;
            this.pTexture = pSrcTexture;
            this.poRect = new Azul.Rect(pSubRect);
        }


        public Image() : base()
        {
            // first calls the super class constructor.

            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.poRect = new Azul.Rect();
            Debug.Assert(this.poRect != null);
        }




        //----------------------------------------------------------------------------------
        // Get Methods
        //----------------------------------------------------------------------------------

        public Azul.Rect GetAzulRect()
        {
            Debug.Assert(this.poRect != null);
            return this.poRect;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.pTexture.GetAzulTexture();
        }

        public Image.Name GetName()
        {
            return this.name;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public void Set(Name name, Texture pTexture, float x, float y, float width, float height)
        {
            // Copy the data over
            this.name = name;

            Debug.Assert(pTexture != null);
            this.pTexture = pTexture;

            this.poRect.Set(x, y, width, height);
        }

        public void SetName(Image.Name theName)
        {
            this.name = theName;
        }



        public void Wash()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            // gave debug warning when I called the clear method on poRect
            this.poRect.Clear();
        }

        public void Print()
        {
            string loc = "[ "+this.poRect.x+","+this.poRect.y+" ] ";
            string w = "width == "+this.poRect.width;
            string h = "height == "+this.poRect.height;
            Debug.WriteLine(this.name + " : location == " + loc+w+h);
        }
    }
}
