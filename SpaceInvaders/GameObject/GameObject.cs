using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class GameObject : Component
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private GameObject.Name name;

        public float x;
        public float y;

        public bool bMarkForDeath;

        public ProxySprite pProxySprite;
        public CollisionObjBase poCollObj;


        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        
        public enum Name
        {
            Default,
            Null_GameObject,
            Uninitialized,

            Grid,
            Column_0,
            Column_1,
            Column_2,
            Column_3,
            Column_4,
            Column_5,
            Column_6,
            Column_7,
            Column_8,
            Column_9,
            Column_10,

            Ship,
            ShipRoot,

            BumperLeft,
            BumperRight,
            BumperGroup,

            Missile,
            MissileGroup,
            
            Bomb,
            BombRoot,
            

            ExplosionRoot,
            AlienExplosion,
            BombExplosion,
            MissileExplosion,

            WallGroup,
            WallGroupTopBottom,
            WallGroupLeftRight,
            WallTop,
            WallBottom,
            WallRight,
            WallLeft,

            Boss,
            BossGrid,
            UFO,
            UFOGrid,

            AlienGrid,
            Alien,
            Octopus,
            Squid,
            Saucer,
            SaucerExplosion,
            ClassicAlien,
            WhiteAlien,
            SwapAlien,

            ShieldGrid,
            ShieldRoot,
            ShieldColumn_0,
            ShieldColumn_1,
            ShieldColumn_2,
            ShieldColumn_3,
            ShieldColumn_4,
            ShieldColumn_5,
            ShieldColumn_6,
            ShieldBrick,


        }
       
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        
        public GameObject() : base()
        {
            this.name = GameObject.Name.Uninitialized;
            this.pProxySprite = null;
            this.x = 0.0f;
            this.y = 0.0f;
            this.bMarkForDeath = false;
        }

        public GameObject(GameObject.Name theName) : base()
        {
            this.name = theName;
            this.pProxySprite = null;
            this.x = 0.0f;
            this.y = 0.0f;
            this.bMarkForDeath = false;
            //Do I need this
            //this.poCollObj = new CollisionObj(this.pProxySprite);
            //Debug.Assert(this.poCollObj != null);
        }

        public GameObject(GameObject.Name gameName, GameSprite.Name spriteName) : base()
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;

            this.pProxySprite = ProxySpriteManager.Add(spriteName);
            this.poCollObj = new CollisionObj(this.pProxySprite);
            Debug.Assert(this.poCollObj != null);
            this.bMarkForDeath = false;
            
        }


        //----------------------------------------------------------------------------------
        // Set Methods
        //----------------------------------------------------------------------------------
        
        public void Set(GameObject.Name gameName, GameSprite.Name spriteName, float px = 0.0f, float py = 0.0f)
        {
            this.name = gameName;
            this.x = px;
            this.y = py;

            this.pProxySprite = ProxySpriteManager.Add(spriteName);
            this.poCollObj = new CollisionObj(this.pProxySprite);
            Debug.Assert(this.poCollObj != null);
            this.bMarkForDeath = false;
        }

        public void SetGameSprite(GameSprite.Name spriteName)
        {
            this.pProxySprite = ProxySpriteManager.Add(spriteName);
        }
        
        public void SetName(GameObject.Name theName)
        {
            this.name = theName;
        }
        
        public void SetCoords(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetCollisionColor(float red, float green, float blue)
        {
            Debug.Assert(this.poCollObj != null);
            Debug.Assert(this.poCollObj.pCollSprite != null);

            this.poCollObj.pCollSprite.SetLineColor(red, green, blue);
        }

        //----------------------------------------------------------------------------------
        // Virtual Methods
        //----------------------------------------------------------------------------------
        public virtual void Remove()
        {
            // Keenan(delete.A)
            // -----------------------------------------------------------------
            // Very difficult at first... if you are messy, you will pay here!
            // Given a game object....
            // -----------------------------------------------------------------

            //Debug.WriteLine("REMOVE: {0}", this);

            // Remove from SpriteBatch

            // Find the SpriteNode
            Debug.Assert(this.pProxySprite != null);
            SpriteNode pSpriteNode = this.pProxySprite.GetSpriteNode();

            // Remove it from the manager
            Debug.Assert(pSpriteNode != null);
            SpriteNodeBatchManager.Remove(pSpriteNode);

            // Remove collision sprite from spriteBatch

            Debug.Assert(this.poCollObj != null);
            Debug.Assert(this.poCollObj.pCollSprite != null);
            pSpriteNode = this.poCollObj.pCollSprite.GetSpriteNode();

            Debug.Assert(pSpriteNode != null);
            SpriteNodeBatchManager.Remove(pSpriteNode);

            // Remove from GameObjectMan

            GameObjectManager.Remove(this);

        }

        public virtual void Update()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;

            Debug.Assert(this.poCollObj != null);
            this.poCollObj.UpdatePos(this.x, this.y);

            Debug.Assert(this.poCollObj.pCollSprite != null);
            this.poCollObj.pCollSprite.Update();
        }

        protected void BaseUpdateBoundingBox(Component pStart)
        {
            GameObject pNode = (GameObject)pStart;

            // point to ColTotal
            CollRect ColTotal = this.poCollObj.poColRect;
            ColTotal.width = 0;
            ColTotal.height = 0;

            // Get the first child
            pNode = (GameObject)Iterator.GetChild(pNode);

            if (pNode != null)
            {
                // Initialized the union to the first block
                ColTotal.Set(pNode.poCollObj.poColRect);

                while (pNode != null)
                {
                    ColTotal.Union(pNode.poCollObj.poColRect);

                    //move onto next sibling
                    pNode = (GameObject)Iterator.GetSibling(pNode);
                }

                this.x = this.poCollObj.poColRect.x;
                this.y = this.poCollObj.poColRect.y;
            }
            
        }

        //----------------------------------------------------------------------------------
        // Activate Methods
        //----------------------------------------------------------------------------------
        public void ActivateCollisionSprite(SpriteNodeBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.poCollObj != null);

            pSpriteBatch.Attach(this.poCollObj.pCollSprite);
        }

        public void ActivateGameSprite(SpriteNodeBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            pSpriteBatch.Attach(this.pProxySprite);
        }

        //----------------------------------------------------------------------------------
        // Get Methods
        //----------------------------------------------------------------------------------
        
        public GameObject.Name GetName()
        {
            return this.name;
        }

        public CollisionObjBase GetCollObj()
        {
            Debug.Assert(this.poCollObj != null);
            return this.poCollObj;
        }

        public override void Print()
        {
            Debug.WriteLine("\t\t\t\t    name : {0} ({1})",this.name,this.GetHashCode());
            Debug.WriteLine("\t\t\t\t   (x,y) : ({0},{1})",this.x,this.y);
            if (this.pProxySprite != null)
            {
                Debug.WriteLine("\t\t    ProxySprite : {0}",this.pProxySprite.GetName());
                Debug.WriteLine("\t\t     RealSprite : {0}",this.pProxySprite.pSprite.GetName());
            }
            else
            {
                Debug.WriteLine("\t\t    ProxySprite : null");
                Debug.WriteLine("\t\t     RealSprite : null");
            }

        }

    }
}
