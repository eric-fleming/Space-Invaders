using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GridObserverUFO : CollObserver
    {
        public GridObserverUFO()
        {

        }

        public override void Notify()
        {
            //Debug.WriteLine("Grid_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            // OK do some alphabetic magic
            AlienGrid pGrid = (AlienGrid)this.pSubject.pObjA;
            WallCategory pWall = (WallCategory)this.pSubject.pObjB;


            if (pWall.GetCategoryType() == WallCategory.Type.Right)
            {
                // Was set true in the collision
                
                if (pGrid.GetIsOnWall())
                {
                    Debug.WriteLine("---- Hiding : Wall Hit");
                    TimerManager.Add(TimeEvent.Name.HideUFO, new HideUFO(pGrid), pGrid.movementTimeInterval);
                }



            }
            else if (pWall.GetCategoryType() == WallCategory.Type.Left)
            {
                // Was set true in the collision
                
                if (pGrid.GetIsOnWall())
                {
                    Debug.WriteLine("---- Hiding : Wall Hit");
                    TimerManager.Add(TimeEvent.Name.HideUFO, new HideUFO(pGrid), pGrid.movementTimeInterval);
                }

            }

            else
            {
                Debug.Assert(false);
            }


        }
    }
}
