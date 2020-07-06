using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveGridOffWall : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly AlienGrid pAlienGrid;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public MoveGridOffWall(AlienGrid ag)
        {
            Debug.Assert(ag != null);
            this.pAlienGrid = ag;

        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
                this.pAlienGrid.MoveGrid();
                //Debug.WriteLine("   ------ Moved Off Wall");
                this.pAlienGrid.SetIsOnWall(false);

                // Restart the movement process
                TimerManager.Add(TimeEvent.Name.MoveGrid, new MoveGrid(this.pAlienGrid), this.pAlienGrid.movementTimeInterval);
                
        }
    }
}
