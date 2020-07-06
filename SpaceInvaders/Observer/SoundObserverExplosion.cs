using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundObserverExplosion : CollObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SoundObserverExplosion() : base()
        {

        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public override void Notify()
        {
            //Always play sound once
            //Debug.WriteLine("Brick Snd_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            Sound pSound = SoundManager.Find(Sound.Name.Explosion);
            pSound.Play();
        }
    }
}
