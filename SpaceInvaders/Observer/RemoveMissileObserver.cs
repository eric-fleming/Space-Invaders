using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RemoveMissileObserver : CollObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private GameObject pMissile;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public RemoveMissileObserver()
        {
            this.pMissile = null;
        }

        public RemoveMissileObserver(RemoveMissileObserver m)
        {
            this.pMissile = m.pMissile;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveMissileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            if (this.pSubject.pObjA.GetName() == GameObject.Name.Missile)
            {
                this.pMissile = (Missile)this.pSubject.pObjA;
            }

            else if (this.pSubject.pObjB.GetName() == GameObject.Name.Missile)
            {
                this.pMissile = (Missile)this.pSubject.pObjB;
            }

            Debug.Assert(this.pMissile != null);


            if (pMissile.bMarkForDeath == false)
            {
                pMissile.bMarkForDeath = true;
                //   Delay
                RemoveMissileObserver pObserver = new RemoveMissileObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
            else
            {
                pMissile.bMarkForDeath = true;
            }
        }

        public override void Execute()
        {
            // Let the gameObject deal with this... 
            ((MissileGroup)(this.pMissile.pParent)).MoveOffScreen();
            this.pMissile.Remove();
        }

        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
    }
}
