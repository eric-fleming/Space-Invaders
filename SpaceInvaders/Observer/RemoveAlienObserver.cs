using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RemoveAlienObserver : CollObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private GameObject pAlien;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public RemoveAlienObserver()
        {
            this.pAlien = null;
        }

        public RemoveAlienObserver(RemoveAlienObserver a)
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
                RemoveAlienObserver pObserver = new RemoveAlienObserver(this);
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
            Level.KilledAlien();

            //  if this brick removed the last child in the column, then remove column
            // Debug.WriteLine(" alien {0}  parent {1}", this.pAlien, this.pAlien.pParent);
            GameObject pA = (GameObject)this.pAlien;
            GameObject pB = (GameObject)Iterator.GetParent(pA);

            pA.Remove();

            // TODO: Need a better way... 
            if (privCheckParent(pB) == true)
            {
                GameObject pC = (GameObject)Iterator.GetParent(pB);
                pB.Remove();

                if (privCheckParent(pC) == true)
                {
                    //pC.Remove();
                }

            }
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
