using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Font_DLink : DLink
    {

    }
    public class Font : Font_DLink
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public Name name;
        public FontSprite pFontSprite;
        static private String pNullString = "null";

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Play,
            GameTitle,
            
            ScoreTable,
            Alien_Points,
            Octopus_Points,
            Squid_Points,
            UFO_Points,

            

            Score,
            HighScore_Title,
            Score1_Title,
            Score2_Title,
            HighScore,
            Score1,
            Score2,


            LifeCount,
            Credit,


            Demo,
            GameOver,


            TestMessage,
            TestOneOff,

            NullObject,
            Uninitialized
        };

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Font() : base()
        {
            this.name = Font.Name.Uninitialized;
            this.pFontSprite = new FontSprite();
            this.pFontSprite.SetColor(1.0f, 1.0f, 1.0f);
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public void Set(Font.Name fontName, String pMessage, Glyph.Name glyphName, float px, float py)
        {
            Debug.Assert(pMessage != null);

            this.name = fontName;
            //Delegate to inner FontSprite
            this.pFontSprite.Set(fontName,pMessage,glyphName,px,py);
        }

        public void SetColor(float red, float green, float blue)
        {
            this.pFontSprite.SetColor(red, green, blue);
        }

        public void UpdateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            Debug.Assert(this.pFontSprite != null);
            //Delegate to inner FontSprite
            this.pFontSprite.UpdateMessage(pMessage);
        }

        public void Wash()
        {
            this.name = Font.Name.Uninitialized;
            //Delegate to inner FontSprite
            this.pFontSprite.Set(Font.Name.NullObject, pNullString, Glyph.Name.NullObject, 0.0f, 0.0f);
        }

        public void Print()
        {
            Debug.WriteLine("Font Print ... Unimplemented");
        }
    }
}
