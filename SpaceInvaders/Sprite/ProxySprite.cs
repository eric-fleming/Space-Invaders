using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ProxySprite_Base : SpriteBase
    {

    }

    public class ProxySprite : ProxySprite_Base
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private ProxySprite.Name name;
        public float x;
        public float y;
        public float sx;
        public float sy;
        public GameSprite pSprite;


        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Proxy,
            Uninitialized
        }


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ProxySprite() : base()
        {
            this.name = ProxySprite.Name.Uninitialized;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.pSprite = null;
        }

        ~ProxySprite()
        { 
            //what does this do?
        }

        public ProxySprite(GameSprite.Name theName) : base()
        {
            this.name = ProxySprite.Name.Proxy;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.pSprite = GameSpriteManager.Find(theName);
            Debug.Assert(this.pSprite != null);
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public Name GetName()
        {
            return this.name;
        }

        public void SetName(ProxySprite.Name theName)
        {
            this.name = theName;
        }

        public void SetCoordinates(float px, float py)
        {
            this.x = px;
            this.y = py;
        }

        public void Set(GameSprite.Name theName)
        {
            this.name = ProxySprite.Name.Proxy;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.pSprite = GameSpriteManager.Find(theName);
            Debug.Assert(this.pSprite != null);
        }

        public void Wash()
        {
            this.name = ProxySprite.Name.Uninitialized;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.pSprite = null;
        }

        public new void Clear()
        {
            base.Clear();
        }

        public void Print()
        {
            Debug.WriteLine("proxy sprite print");
            Debug.WriteLine("      name : {0} ({1})",this.name, this.GetHashCode());
            Debug.WriteLine("  prox - x : {0}", this.x);
            Debug.WriteLine("  prox - y : {0}", this.y);
            Debug.WriteLine("<< ------ Real Sprite ------ >>");
            this.pSprite.Print();
        }



        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private void privPushToReal()
        {
            Debug.Assert(this.pSprite != null);

            this.pSprite.x = this.x;
            this.pSprite.y = this.y;
            this.pSprite.sx = this.sx;
            this.pSprite.sy = this.sy;

        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Update()
        {
            // push the data from this proxy sprite to a real GameSprite
            this.privPushToReal();
            this.pSprite.Update();
        }

        public override void Render()
        {
            //carpet bombing push to real
            this.privPushToReal();

            this.pSprite.Update();
            this.pSprite.Render();
        }


        //----------------------------------------------------------------------------------
        // For Explosion Sprites
        //----------------------------------------------------------------------------------
        //public void Remove()
        //{
        //    // Find the SpriteNode
        //    SpriteNode pSpriteNode = this.GetSpriteNode();

        //    // Remove it from the manager
        //    Debug.Assert(pSpriteNode != null);
        //    SpriteNodeBatchManager.Remove(pSpriteNode);
        //}
    }
}
