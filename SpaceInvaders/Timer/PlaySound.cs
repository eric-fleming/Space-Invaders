using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlaySound : Command
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private DLink pCurrentSound;
        private DLink poFirstSound;
        private AlienGrid pAlienGrid;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public PlaySound(AlienGrid ag)
        {

            this.poFirstSound = null;
            this.pCurrentSound = null;
            this.pAlienGrid = ag;

        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void Attach(Sound.Name soundName)
        {
            // Perhaps make a sound Manager??
            Sound pSound = SoundManager.Find(soundName);
            Debug.Assert(pSound != null);

            SoundHolder pSoundHold = new SoundHolder(pSound);
            Debug.Assert(pSoundHold != null);

            DLink.AddToEnd(ref this.poFirstSound, pSoundHold);

            this.pCurrentSound = pSoundHold;
        }


        public override void Execute(float deltaTime)
        {
            Debug.Assert(deltaTime > 0);

            SoundHolder pSoundHold = (SoundHolder)this.pCurrentSound.pNext;

            // if you reached the end go back to the start
            if (pSoundHold == null)
            {
                pSoundHold = (SoundHolder)this.poFirstSound;
            }

            //set to next sound
            this.pCurrentSound = pSoundHold;

            pSoundHold.pSound.Play(0.4f);
            TimerManager.Add(TimeEvent.Name.PlaySound, this, this.pAlienGrid.movementTimeInterval);
        }

    }
}
