using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionFactory : Factory
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly SpriteNodeBatch pSpriteBatch;
        private readonly SpriteNodeBatch pCollisionSpriteBatch;
        private readonly ExplosionManager pManager;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionFactory(SpriteNodeBatch.Name spriteBatchName, SpriteNodeBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteNodeBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteNodeBatchManager.Find(boxSpriteBatchName);
            Debug.Assert(this.pCollisionSpriteBatch != null);


            // For managing / recycling the created Explosions
            this.pManager = new ExplosionManager(this, 3, 1);


            // Create at least on of each Explosion type
            // Should be in active
            this.Create(GameObject.Name.AlienExplosion, -100.0f, -100.0f);
            this.Create(GameObject.Name.MissileExplosion, -100.0f, -100.0f);
            this.Create(GameObject.Name.BombExplosion, -100.0f, -100.0f);

        }

        ~ExplosionFactory()
        {
            Debug.WriteLine("break");
            //
        }


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public GameObject Create(GameObject.Name theName, float posx = 0.0f, float posy = 0.0f)
        {
            GameObject pGameObj = null;

            switch (theName)
            {
                case GameObject.Name.ExplosionRoot:
                    pGameObj = new ExplosionRoot(GameObject.Name.ExplosionRoot, GameSprite.Name.NullObject, posx, posy);
                    break;

                case GameObject.Name.AlienExplosion:
                    pGameObj = this.pManager.Add(GameObject.Name.AlienExplosion, GameSprite.Name.AlienExplosion, posx, posy);
                    break;

                case GameObject.Name.MissileExplosion:
                    pGameObj = this.pManager.Add(GameObject.Name.MissileExplosion, GameSprite.Name.MissileExplosion, posx, posy);
                    break;

                case GameObject.Name.BombExplosion:
                    pGameObj = this.pManager.Add(GameObject.Name.BombExplosion, GameSprite.Name.BombExplosion, posx, posy);
                    break;

                default:
                    Debug.WriteLine("Choose the Explosion you want by name.");
                    Debug.Assert(false);
                    break;
            }

            Debug.Assert(pGameObj != null);

            // attach to the group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatch);
            return pGameObj;
        }

        //----------------------------------------------------------------------------------
        // Manager Methods
        //----------------------------------------------------------------------------------
        
        public Explosion Grab(GameObject.Name gameName)
        {
            Explosion pExplosion = this.pManager.Find(gameName);
            return pExplosion;
        }


        //----------------------------------------------------------------------------------
        // Factory Methods
        //----------------------------------------------------------------------------------
        public override GameObject Build(GameObject.Name theName, float x = 0.0f, float y= 0.0f)
        {
            ExplosionRoot pExplosionRoot = (ExplosionRoot)this.Create(theName, x, y);
            pExplosionRoot.ActivateGameSprite(this.pSpriteBatch);
            pExplosionRoot.ActivateCollisionSprite(this.pCollisionSpriteBatch);
            GameObjectManager.Attach(pExplosionRoot);

            Debug.WriteLine("Finished : Creating the Explosion Root Composite");

            return pExplosionRoot;
        }



        
    }
}
