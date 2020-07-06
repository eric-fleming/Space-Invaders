using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GridObserver : CollObserver
    {
        public GridObserver()
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
                    pGrid.SetDelta(-1.0f);
                    // Only add the drop command once
                    TimerManager.Add(TimeEvent.Name.DropGrid, new DropGrid(pGrid), pGrid.movementTimeInterval);
                    // Move off the wall
                    pGrid.MoveGrid();
                }



            }
            else if (pWall.GetCategoryType() == WallCategory.Type.Left)
            {
                // Was set true in the collision
                
                if (pGrid.GetIsOnWall())
                {
                    pGrid.SetDelta(1.0f);
                    // Only add the drop command once
                    TimerManager.Add(TimeEvent.Name.DropGrid, new DropGrid(pGrid), pGrid.movementTimeInterval);
                    // Move off the wall
                    pGrid.MoveGrid();
                }

            }

            else
            {
                Debug.Assert(false);
            }

        }
    }
}
