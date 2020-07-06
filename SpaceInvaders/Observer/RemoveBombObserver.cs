using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveBombObserver : CollObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private GameObject pBomb;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public RemoveBombObserver()
        {
            this.pBomb = null;
        }

        public RemoveBombObserver(RemoveBombObserver bm)
        {
            this.pBomb = bm.pBomb;
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Notify()
        {
            // Delete bomb
            //Debug.WriteLine("RemoveBombObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);


            this.pBomb = (Bomb)this.pSubject.pObjA;
            Debug.Assert(this.pBomb != null);


            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                //   Delay
                RemoveBombObserver pObserver = new RemoveBombObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
            else
            {
                pBomb.bMarkForDeath = true;
            }
        }

        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.pBomb.Remove();
        }


    }
}
