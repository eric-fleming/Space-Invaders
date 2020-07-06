using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionSprite : DLink
    {
        public float x;
        public float y;

        public ProxySprite pProxySprite;
        private SpriteNodeBatch pExplosionBatch;
        //SpriteNode pBackPointer;

        public ExplosionSprite(GameSprite.Name spriteName, float px, float py) : base()
        {
            // finds the ProxySprite and returns a reference to it.
            // the sprite base of the proxy sprite has a back pointer to its spritenode
            this.pProxySprite = ProxySpriteManager.Add(spriteName);

            this.pProxySprite.SetCoordinates(px, py);
            this.pProxySprite.Update();

            this.pExplosionBatch = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Explosions);

        }

        public void SetPosition(float px, float py)
        {
            this.x = px;
            this.y = py;
            this.pProxySprite.SetCoordinates(px,py);
            this.pProxySprite.Update();
        }

        public void AddExplosion()
        {

            //Delegate to batches attach which calls its own SpriteNodeManager's Attach
            // Inside the SpriteNodeManager's Attach is where the back pointer is set.
            this.pExplosionBatch.Attach(this.pProxySprite);
            Debug.Assert(this.pProxySprite.GetSpriteNode() != null);

        }

        public void RemoveExplosion()
        {
            // Move off the page and refresh
            this.SetPosition(-30.0f, -30.0f);


            // Get my SpriteNode
            //SpriteNode pMySpriteNode = this.pProxySprite.GetSpriteNode();
            //SpriteNodeBatchManager.Remove(pMySpriteNode);


        }


    }
}
