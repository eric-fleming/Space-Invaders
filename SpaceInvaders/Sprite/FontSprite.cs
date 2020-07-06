using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontSprite : SpriteBase
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public Font.Name name;
        private Azul.Sprite pAzulSprite;
        private Azul.Rect pScreenRect;
        private Azul.Color pColor;   // this color is multplied by the texture

        private String pMessage;
        public Glyph.Name glyphName;

        public float x;
        public float y;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public FontSprite() : base()
        {
            // Make a dummy sprite.  Will be finished by Set() Method later.
            this.x = 0.0f;
            this.y = 0.0f;
            this.glyphName = Glyph.Name.Uninitialized;
            this.pMessage = null;

            this.pAzulSprite = new Azul.Sprite();
            this.pScreenRect = new Azul.Rect();
            this.pColor = new Azul.Color(1.0f, 1.0f, 1.0f);
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public Glyph.Name GetGlyphName()
        {
            return this.glyphName;
        }

        public void Set(Font.Name fontName, String pMessage, Glyph.Name glyphName, float px, float py)
        {
            Debug.Assert(pMessage != null);
            this.pMessage = pMessage;

            this.name = fontName;
            this.x = px;
            this.y = py;

            // TODO: for wash... this should be a nullGlyph
            this.glyphName = glyphName;

            // Default white font
            Debug.Assert(this.pColor != null);
            this.pColor.Set(1.0f, 1.0f, 1.0f);
        }


        public void SetColor(float r, float g, float b, float a = 1.0f)
        {
            // RED, GREEN, BLUE, ALPHA
            Debug.Assert(this.pColor != null);
            this.pColor.Set(r,g,b,a);
        }

        public void UpdateMessage(String pMessage)
        {
            Debug.Assert(this.pMessage != null);
            this.pMessage = pMessage;
        }

        public void Print()
        {
            // unimplemented
        }



        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Update()
        {
            Debug.Assert(this.pAzulSprite != null);
        }

        public override void Render()
        {
            Debug.Assert(this.pAzulSprite != null);
            Debug.Assert(this.pColor != null);
            Debug.Assert(this.pScreenRect != null);
            Debug.Assert(this.pMessage != null);
            Debug.Assert(this.pMessage.Length > 0);

            float xTmp = this.x;
            float yTmp = this.y;

            float xEnd = this.x;

            for (int i = 0; i < this.pMessage.Length; i++)
            {
                int key = Convert.ToByte(pMessage[i]);

                Glyph pGlyph = GlyphManager.Find(this.glyphName, key);
                Debug.Assert(pGlyph != null);

                xTmp = xEnd + pGlyph.GetAzulSubRect().width / 2;
                this.pScreenRect.Set(xTmp, yTmp, pGlyph.GetAzulSubRect().width, pGlyph.GetAzulSubRect().height);

                pAzulSprite.Swap(pGlyph.GetAzulTexture(), pGlyph.GetAzulSubRect(), this.pScreenRect, this.pColor);

                pAzulSprite.Update();
                pAzulSprite.Render();

                // move the starting to the next character
                xEnd = pGlyph.GetAzulSubRect().width / 2 + xTmp;
            }
        }
    }
}
