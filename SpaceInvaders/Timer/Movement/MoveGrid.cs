using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveGrid : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly AlienGrid pAlienGrid;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public MoveGrid(AlienGrid ag)
        {
            Debug.Assert(ag != null);
            this.pAlienGrid = ag;

        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            // Only move if you are not on the wall
            if (!this.pAlienGrid.GetIsOnWall())
            {
                this.pAlienGrid.MoveGrid();
                //Debug.WriteLine("   ------ Moved");

                TimerManager.Add(TimeEvent.Name.MoveGrid, this, this.pAlienGrid.movementTimeInterval);
            }

        }
    }
}
