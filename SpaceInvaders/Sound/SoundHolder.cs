using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundHolder : DLink
    {
        // Data
        public Sound pSound;


        public SoundHolder(Sound s) : base()
        {
            this.pSound = s;
        }
    }
}
