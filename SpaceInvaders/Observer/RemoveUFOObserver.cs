using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveUFOObserver : CollObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private GameObject pAlien;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public RemoveUFOObserver()
        {
            this.pAlien = null;
        }

        public RemoveUFOObserver(RemoveUFOObserver a)
        {
            Debug.Assert(a != null);
            this.pAlien = a.pAlien;
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveBrickObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.pAlien = (AlienGO)this.pSubject.pObjB;


            Debug.Assert(this.pAlien != null);

            if (pAlien.bMarkForDeath == false)
            {
                //Award points
                int points = ((AlienGO)this.pAlien).GetPoints();
                Debug.WriteLine(" +{0} points!", points);
                Score.IncreaseScore(points);
                Score.Refresh();

                pAlien.bMarkForDeath = true;
                //   Delay
                RemoveUFOObserver pObserver = new RemoveUFOObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
            else
            {
                pAlien.bMarkForDeath = true;
            }
        }

        public override void Execute()
        {
            // Resiter the change with the Level
            Level.KilledUFO();

            //  if this brick removed the last child in the column, then remove column
            // Debug.WriteLine(" alien {0}  parent {1}", this.pAlien, this.pAlien.pParent);
            GameObject pA = (GameObject)this.pAlien;
            GameObject pB = (GameObject)Iterator.GetParent(pA);

            pB.bMarkForDeath = true;

            pA.Remove();
            Debug.WriteLine("---- Hiding : Missile Destroyed");
            TimerManager.Add(TimeEvent.Name.HideUFO, new HideUFO((AlienGrid)pB), ((AlienGrid)pB).movementTimeInterval);


        }
        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private bool privCheckParent(GameObject pObj)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(pObj);
            if (pGameObj == null)
            {
                return true;
            }

            return false;
        }
    }
}
