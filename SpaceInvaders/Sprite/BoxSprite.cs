using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BoxSprite_Base : SpriteBase
    {

    }

    public class BoxSprite : BoxSprite_Base
    {
        //----------------------------------------------------------------------------------
        // Static Data - for reuse by instances
        //----------------------------------------------------------------------------------

        private static Azul.Rect psTempRect = new Azul.Rect();
        private static Azul.Color psTempColor = new Azul.Color(1,1,1);

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------

        private Name name;
        private Azul.Color poLineColor;  //shouldn't be readonly?
        private Azul.SpriteBox poAzulBoxSprite;

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------

        public enum Name
        {
            Default,
            Box,
            Box1,
            Box2,

            Wall_Left,
            Wall_Right,
            Wall_Top,
            Wall_Bottom,

            Coll_Box_Alien,
            Coll_Box_Player,
            Coll_Box_Missile,
            Coll_Box_Bomb,

            Uninitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------

        public BoxSprite() : base()
        {
            // delegates to SpriteBase for x, y, sx, sy, angle

            //specific to this class
            this.name = BoxSprite.Name.Uninitialized;

            Debug.Assert(BoxSprite.psTempRect != null);
            Debug.Assert(BoxSprite.psTempColor != null);
            BoxSprite.psTempRect.Set(0,0,1,1);
            BoxSprite.psTempColor.Set(1,1,1);

            this.poAzulBoxSprite = new Azul.SpriteBox(psTempRect,psTempColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            this.poLineColor = new Azul.Color(1,1,1);
            Debug.Assert(this.poLineColor != null);

            this.x = this.poAzulBoxSprite.x;
            this.y = this.poAzulBoxSprite.y;
            this.sx = this.poAzulBoxSprite.sx;
            this.sy = this.poAzulBoxSprite.sy;
            this.angle = this.poAzulBoxSprite.angle;

        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        
        public BoxSprite.Name GetName()
        {
            return this.name;
        }

        public void SetName(BoxSprite.Name theName)
        {
            this.name = theName;
        }

        public void Set(BoxSprite.Name theName, float x, float y, float width, float height, Azul.Color pLineColor)
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            Debug.Assert(this.poLineColor != null);

            Debug.Assert(BoxSprite.psTempRect != null);
            BoxSprite.psTempRect.Set(x, y, width, height);

            this.name = theName;

            if(pLineColor == null)
            {
                this.poLineColor.Set(1,1,1);
            }
            else
            {
                this.poLineColor.Set(pLineColor);
            }

            this.poAzulBoxSprite.Swap(psTempRect,this.poLineColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            this.x = this.poAzulBoxSprite.x;
            this.y = this.poAzulBoxSprite.y;
            this.sx = this.poAzulBoxSprite.sx;
            this.sy = this.poAzulBoxSprite.sy;
            this.angle = this.poAzulBoxSprite.angle;
        }

        public void Set(BoxSprite.Name theName, float x, float y, float width, float height)
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            Debug.Assert(BoxSprite.psTempRect != null);
            BoxSprite.psTempRect.Set(x, y, width, height);

            this.name = theName;

            this.poAzulBoxSprite.Swap(psTempRect, this.poLineColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            this.x = this.poAzulBoxSprite.x;
            this.y = this.poAzulBoxSprite.y;
            this.sx = this.poAzulBoxSprite.sx;
            this.sy = this.poAzulBoxSprite.sy;
            this.angle = this.poAzulBoxSprite.angle;
        }

        public void SetLineColor(float r, float g, float b, float a = 1.0f)
        {
            //PIXEL : RED, GREEN, BLUE, ALPHA
            Debug.Assert(this.poLineColor != null);
            this.poLineColor.Set(r,g,b,a);
        }

        public void SetScreenRect(float x, float y, float width, float height)
        {
            this.Set(this.name, x, y, width, height);
        }

        public void SwapColor(Azul.Color pColor)
        {
            // Delegate to the AzulBoxSprite it contains
            Debug.Assert(pColor != null);
            this.poAzulBoxSprite.SwapColor(pColor);
        }


        public void Wash()
        {
            this.name = BoxSprite.Name.Uninitialized;
            this.poLineColor.Set(1,1,1);
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }

        public void Print()
        {
            Debug.WriteLine("Name : {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("     Color(r,g,b) : ({0},{1},{2})", this.poLineColor.red, this.poLineColor.green, this.poLineColor.blue);
            Debug.WriteLine("     AzulSprite : {0}", this.poAzulBoxSprite.GetHashCode());
            Debug.WriteLine("     (x , y) : ({0}, {1})", this.x, this.y);
            Debug.WriteLine("     (sx , sy) : ({0}, {1})", this.sx, this.sy);
            Debug.WriteLine("     (angle) : {0}", this.angle);
        }



        //----------------------------------------------------------------------------------
        // Overriden / Implemented Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Update()
        {
            //sync values
            this.poAzulBoxSprite.x = this.x;
            this.poAzulBoxSprite.y = this.y;
            this.poAzulBoxSprite.sx = this.sx;
            this.poAzulBoxSprite.sy = this.sy;
            this.poAzulBoxSprite.angle = this.angle;

            //push changes
            this.poAzulBoxSprite.Update();
        }

        public override void Render()
        {
            this.Update();
            this.poAzulBoxSprite.Render();
        }
    }
}
