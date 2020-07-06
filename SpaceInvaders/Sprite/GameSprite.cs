using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class GameSprite_Base : SpriteBase
    {

    }

    public class GameSprite : GameSprite_Base
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        
        private Name name;
        private Image pImage;

        private readonly Azul.Color poAzulColor;
        private Azul.Sprite poAzulSprite;
        private readonly Azul.Rect poScreenRect;

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        //----------------------------------------------------------------------------------
        // Static Data
        //----------------------------------------------------------------------------------
        private static Azul.Color psTempColor = new Azul.Color(1,1,1);

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
           
            Grid,
            Column,

            Alien,
            AlienExplosion,
            Octopus,
            Squid,
            Saucer,
            SaucerExplosion,

            Player,
            Ship,
            ShipExplosionA,
            ShipExplosionB,
            Missile,
            MissileExplosion,
            BombStraight,
            BombZigZag,
            BombDagger,
            BombRolling,
            BombExplosion,

            Wall,

            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,


            Defualt,
            NullObject,
            Uninitialized
        }

        //----------------------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------------------
        public GameSprite(GameSprite.Name myName, Image pImage, Azul.Rect pScreenRect) : base()
        {
            Debug.Assert(pImage != null);
            Debug.Assert(pScreenRect != null);

            this.name = myName;
            this.pImage = pImage;
            this.poAzulColor = new Azul.Color(1,1,1);
            this.poAzulSprite = new Azul.Sprite(pImage.GetAzulTexture(), pImage.GetAzulRect(),pScreenRect);

            Debug.Assert(poAzulSprite != null);

            //grab data from the Azul Sprite
            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        public GameSprite() : base()
        {
            // resets to default parameters
            this.Wash();

            // Use Default Values
            this.pImage = ImageManager.Find(Image.Name.Default);
            Debug.Assert(pImage != null);

            // Prep Rect
            this.poScreenRect = new Azul.Rect();
            Debug.Assert(this.poScreenRect != null);
            this.poScreenRect.Clear();

            // Prep Color
            this.poAzulColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poAzulColor != null);

            // Prep Sprite
            this.poAzulSprite = new Azul.Sprite(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, this.poAzulColor);
            Debug.Assert(this.poAzulSprite != null);

            //grab data from the Azul Sprite
            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void Wash()
        {
            this.name = GameSprite.Name.Uninitialized;
            this.pImage = null;

            // DO NOT NULL THE poAzulSprite.  Just write over it with the set()
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }

        public void Set(GameSprite.Name myName, Image pImage, float mx, float my, float w, float h, Azul.Color pColor)
        {
            Debug.Assert(pImage != null);
            Debug.Assert(this.poAzulColor != null);
            Debug.Assert(this.poAzulSprite != null);

            this.name = myName;
            this.pImage = pImage;
            this.poScreenRect.Set(mx,my,w,h);

            
            if (pColor == null)
            {
                Debug.Assert(psTempColor != null);
                GameSprite.psTempColor.Set(1,1,1);
                this.poAzulColor.Set(psTempColor);
            }
            else
            {
                this.poAzulColor.Set(pColor);
            }

            Debug.Assert(this.poAzulSprite != null);
            this.poAzulSprite.Swap(pImage.GetAzulTexture(),pImage.GetAzulRect(),this.poScreenRect, this.poAzulColor);

            //grab data from the Azul Sprite, then update/sync
            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;


        }

        public void SetName(GameSprite.Name theName)
        {
            this.name = theName;
        }

        public GameSprite.Name GetName()
        {
            return this.name;
        }

        public Azul.Rect GetScreenRect()
        {
            Debug.Assert(this.poScreenRect != null);
            return this.poScreenRect;
        }

        public void SwapColor(Azul.Color pColor)
        {
            Debug.Assert(pColor != null);
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(this.poAzulColor != null);

            this.poAzulColor.Set(pColor);
            this.poAzulSprite.SwapColor(pColor);
        }

        public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(this.poAzulColor != null);

            this.poAzulColor.Set(red, green, blue, alpha);
            this.poAzulSprite.SwapColor(this.poAzulColor);
        }

        public void SwapImage(Image pTheNewImage)
        {
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(pTheNewImage != null);

            this.pImage = pTheNewImage;
            this.poAzulSprite.SwapTexture(this.pImage.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(this.pImage.GetAzulRect());

        }

        public void Print()
        {
            Debug.WriteLine("Name : {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("     Image : {0} ({1})", this.pImage.GetName(), this.pImage.GetHashCode());
            Debug.WriteLine("     AzulSprite : {0}", this.poAzulSprite.GetHashCode());
            Debug.WriteLine("     (x , y) : ({0}, {1})", this.x, this.y);
            Debug.WriteLine("     (sx , sy) : ({0}, {1})", this.sx, this.sy);
            Debug.WriteLine("     (angle) : {0}", this.angle);
        }
        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Update()
        {
            
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;
            this.poAzulSprite.Update();
        }

        public override void Render()
        {
            this.Update();
            this.poAzulSprite.Render();
        }

        
    }
}
