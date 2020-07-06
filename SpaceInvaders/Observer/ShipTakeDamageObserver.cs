using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipTakeDamageObserver : CollObserver
    {
        private GameObject pBomb;
        private GameObject pShip;

        public ShipTakeDamageObserver()
        {
            this.pBomb = null;
            this.pShip = null;
        }

        public ShipTakeDamageObserver(ShipTakeDamageObserver pObserver)
        {
            this.pBomb = pObserver.pBomb;
            this.pShip = pObserver.pShip;
        }


        public override void Notify()
        {
            //Debug.WriteLine("RemoveBombObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.pBomb = (Bomb)this.pSubject.pObjA;
            this.pShip = (Ship)this.pSubject.pObjB;
            Debug.Assert(this.pBomb != null);
            Debug.Assert(this.pShip != null);


            if (pShip.bMarkForDeath == false)
            {
                pShip.bMarkForDeath = true;
                //   Delay
                ShipTakeDamageObserver pObserver = new ShipTakeDamageObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
            else
            {
                pShip.bMarkForDeath = true;
            }
        }




        public override void Execute()
        {
            // What should happen?

            // Lives should go down
            Lives.LoseLife();
            Lives.Refresh();
            Debug.WriteLine("Lives Left : {0}", Lives.GetLives());
            this.pShip.bMarkForDeath = false;

            if (Lives.GetLives() == 0)
            {
                SpaceInvaders.pSceneContext.SetState(SceneContext.Scene.GameOver);
            }

        }



    }
}
