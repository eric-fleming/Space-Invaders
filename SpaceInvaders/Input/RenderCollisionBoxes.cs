using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RenderCollisionBoxesObserver : InputObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private SpriteNodeBatch pBatchHolder;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public RenderCollisionBoxesObserver()
        {
            this.pBatchHolder = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Boxes);

        }


        public override void Notify()
        {
            //get the SpriteBatch
            bool drawState = pBatchHolder.GetDrawStatus();

            if (drawState)
            {
                //Turn off draw
                pBatchHolder.SetDrawStatus(false);
            }
            else
            {
                // turn on draw
                pBatchHolder.SetDrawStatus(true);
            }
            Debug.WriteLine("----> B key registered");
        }
    }
}
