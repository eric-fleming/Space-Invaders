using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Texture : DLink
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private Name name;
        private Azul.Texture poAzulTexture;


        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------

        public enum Name
        {
            SpaceInvaders,
            Invaders,
            Consolas36pt,
            Default,
            NullObject,
            Uninitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------

        public Texture(Name textureName, string pTextureName )
        {
            Debug.Assert(pTextureName != null);

            this.name = textureName;
            this.poAzulTexture = new Azul.Texture(pTextureName);
        }

        public Texture() :  base()
        {
            this.Wash();
        }


        //----------------------------------------------------------------------------------
        // Get Method
        //----------------------------------------------------------------------------------
        public Texture.Name GetName()
        {
            return this.name;
        }
        
        public Azul.Texture GetAzulTexture()
        {
            Debug.Assert(this.poAzulTexture != null);
            return this.poAzulTexture;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void Wash()
        {
            this.name = Name.Uninitialized;
            this.poAzulTexture = null;
        }

        public void SetName(Texture.Name theName)
        {
            this.name = theName;
        }
        public void Set(Name theName, string pTextureName)
        {
            Debug.Assert(pTextureName != null);

            this.name = theName;
            
            //Texture swap 

            if(System.IO.File.Exists(pTextureName))
            {
                //Replace old Texture with new one.
                this.poAzulTexture = new Azul.Texture(pTextureName,Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            }

            Debug.Assert(this.poAzulTexture != null);

        }

        public void Print()
        {
            Debug.WriteLine("Texture: " + this.name);
        }




    }
}
