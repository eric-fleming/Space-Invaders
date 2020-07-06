using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionSpriteFactory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly SpriteNodeBatch pSpriteBatch;
        private DLink pHead = null;

        private int ExplosionSpriteCreationCount;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionSpriteFactory(SpriteNodeBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteNodeBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            // Loading the list for recycling
            this.Create(GameSprite.Name.AlienExplosion);
            this.Create(GameSprite.Name.MissileExplosion);
            this.Create(GameSprite.Name.BombExplosion);
            this.ExplosionSpriteCreationCount = 3;
        }

        ~ExplosionSpriteFactory()
        {
            Debug.WriteLine("break");
            
        }


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionSprite Create(GameSprite.Name theName, float posx = 0.0f, float posy = 0.0f)
        {
            ExplosionSprite pSprite = null;

            switch (theName)
            {

                case GameSprite.Name.AlienExplosion:
                    pSprite = this.Grab(theName);
                    // If not there then create.
                    if (pSprite == null)
                    {
                        pSprite = new ExplosionSprite(GameSprite.Name.AlienExplosion, posx, posy);
                        DLink.AddToFront(ref this.pHead, pSprite);
                        ExplosionSpriteCreationCount++;
                    }
                    break;

                case GameSprite.Name.MissileExplosion:
                    pSprite = this.Grab(theName);
                    // If not there then create.
                    if (pSprite == null)
                    {
                        pSprite = new ExplosionSprite(GameSprite.Name.MissileExplosion, posx, posy);
                        DLink.AddToFront(ref this.pHead, pSprite);
                        ExplosionSpriteCreationCount++;
                    }
                    break;

                case GameSprite.Name.BombExplosion:
                    pSprite = this.Grab(theName);
                    // If not there then create.
                    if (pSprite == null)
                    {
                        pSprite = new ExplosionSprite(GameSprite.Name.BombExplosion, posx, posy);
                        DLink.AddToFront(ref this.pHead, pSprite);
                        ExplosionSpriteCreationCount++;
                    }
                    break;

                case GameSprite.Name.SaucerExplosion:
                    pSprite = this.Grab(theName);
                    // If not there then create.
                    if (pSprite == null)
                    {
                        pSprite = new ExplosionSprite(GameSprite.Name.SaucerExplosion, posx, posy);
                        DLink.AddToFront(ref this.pHead, pSprite);
                        ExplosionSpriteCreationCount++;
                    }
                    break;

                case GameSprite.Name.ShipExplosionA:
                    pSprite = this.Grab(theName);
                    // If not there then create.
                    if (pSprite == null)
                    {
                        pSprite = new ExplosionSprite(GameSprite.Name.ShipExplosionA, posx, posy);
                        DLink.AddToFront(ref this.pHead, pSprite);
                        ExplosionSpriteCreationCount++;
                    }
                    break;

                case GameSprite.Name.ShipExplosionB:
                    pSprite = this.Grab(theName);
                    // If not there then create.
                    if (pSprite == null)
                    {
                        pSprite = new ExplosionSprite(GameSprite.Name.ShipExplosionB, posx, posy);
                        DLink.AddToFront(ref this.pHead, pSprite);
                        ExplosionSpriteCreationCount++;
                    }
                    break;

                default:
                    Debug.WriteLine("Choose the Explosion you want by name.");
                    Debug.Assert(false);
                    break;
            }

            pSprite.AddExplosion();

            Debug.Assert(pSprite != null);
            return pSprite;
        }

        //----------------------------------------------------------------------------------
        // Manager Methods
        //----------------------------------------------------------------------------------

        public ExplosionSprite Grab(GameSprite.Name spriteName)
        {
            //Debug.Assert(this.pHead != null);
            DLink pCurrent = this.pHead;

            while (pCurrent != null)
            {
                GameSprite.Name currentName = ((ExplosionSprite)pCurrent).pProxySprite.pSprite.GetName();
                if (currentName == spriteName)
                {
                    return (ExplosionSprite)pCurrent;
                }
                pCurrent = pCurrent.pNext;

            }

            return null;
        }


        //----------------------------------------------------------------------------------
        // Factory Methods
        //----------------------------------------------------------------------------------

    }
}
