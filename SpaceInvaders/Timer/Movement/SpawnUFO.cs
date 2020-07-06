using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpawnUFO : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        //public static Random Appear = new Random();
        private AlienGrid pUfoGrid;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SpawnUFO(AlienGrid ag)
        {
            this.pUfoGrid = ag;
        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {
            this.pUfoGrid.SetDelta(1.0f);
            
            // Grab the UFO inside the Alien Grid
            AlienGO pUfo = ((AlienGO)this.pUfoGrid.GetFirstChild());
            pUfo.SetCoords(100.0f, 870.0f);
            pUfo.Update();
            Debug.WriteLine("UFO Appeared!!");

            // Set in Motion
            this.pUfoGrid.bMarkForDeath = false;
            this.pUfoGrid.MoveGrid();
            TimerManager.Add(TimeEvent.Name.MoveUFO, new MoveUFO(this.pUfoGrid), this.pUfoGrid.movementTimeInterval);


        }
    }
}
