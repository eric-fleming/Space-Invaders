using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class HideUFO : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public static Random Appear = new Random();
        private AlienGrid pUfoGrid;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public HideUFO(AlienGrid ag)
        {
            this.pUfoGrid = ag;
        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {

            if (this.pUfoGrid.GetIsOnWall())
            {
                // Teleport the UFO above the game
                AlienGO pUfo = ((AlienGO)this.pUfoGrid.GetFirstChild());
                pUfo.SetCoords(100.0f, 1200.0f);
                pUfo.Update();
                this.pUfoGrid.SetIsOnWall(false);
                Debug.WriteLine("... UFO Hidden");

                // Stop Moving??


                // Get a random
                float spawnAgain = (float)Appear.Next(25, 45);
                TimerManager.Add(TimeEvent.Name.SpawnUFO, new SpawnUFO(this.pUfoGrid), spawnAgain);
                
            }


        }
    }
}
