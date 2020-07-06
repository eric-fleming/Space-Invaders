using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ExplosionSprite
    {
        public ProxySprite pProxySprite;
        // pProxy has a back pointer

        //public SpriteNodeManager pBackPointer_SpriteNodeManager;



        public ExplosionSprite(GameSprite.Name spriteName)
        {
            // finds the ProxySprite and returns a reference to it.
            this.pProxySprite = ProxySpriteManager.Add(spriteName);
        }



        public void AddExplosion()
        {
            // Find the correct Batch
            SpriteNodeBatch pBatch = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Explosions);

            //Delegate to batches attach which calls its own SpriteNodeManager's Attach
            // Inside the SpriteNodeManager's Attach is where the back pointer is set.
            pBatch.Attach(this.pProxySprite);

        }

        public void RemoveExplosion()
        {
            SpriteNodeBatch pBatch = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Explosions);
            pBatch.Detach(this.pProxySprite);

            // If I have the back pointer I don't need to search for it.
            

        }


    }
}
