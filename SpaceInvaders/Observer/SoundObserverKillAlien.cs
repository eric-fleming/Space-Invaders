using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundObserverKillAlien : SoundObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SoundObserverKillAlien() : base()
        {
            
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public override void Notify()
        {
            //Always play sound once
            //Debug.WriteLine(" Snd_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            Sound pSound = SoundManager.Find(Sound.Name.InvaderKilled);
            pSound.Play();
        }
    }
}
