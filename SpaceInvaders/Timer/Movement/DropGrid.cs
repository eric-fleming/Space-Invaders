using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DropGrid : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly AlienGrid pAlienGrid;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public DropGrid(AlienGrid ag)
        {
            Debug.Assert(ag != null);
            this.pAlienGrid = ag;

        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public override void Execute(float deltaTime)
        {
            
            this.pAlienGrid.DropGrid();
            //Debug.WriteLine("   ------ DROPPED");
            TimerManager.Add(TimeEvent.Name.MoveGridOffWall, new MoveGridOffWall(this.pAlienGrid), this.pAlienGrid.movementTimeInterval);
        }
    }
}
