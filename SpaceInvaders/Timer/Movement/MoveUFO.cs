using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveUFO : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly AlienGrid pAlienGrid;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public MoveUFO(AlienGrid ag)
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
                //Debug.WriteLine("   ------ Moved UFO");
                TimerManager.Add(TimeEvent.Name.MoveUFO, this, 0.3f * this.pAlienGrid.movementTimeInterval);

            }

            if (!this.pAlienGrid.bMarkForDeath)
            {
                Sound pSound = SoundManager.Find(Sound.Name.UFO_HighPitch);
                pSound.Play(0.1f);
                //pSound = SoundManager.Find(Sound.Name.UFO_LowPitch);
                //pSound.Play(0.1f);
            }

        }
    }
}
