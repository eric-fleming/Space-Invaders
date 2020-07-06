using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Sound : DLink
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static IrrKlang.ISoundEngine engine = new IrrKlang.ISoundEngine();

        private Sound.Name name;
        private IrrKlang.ISoundSource source;
        private float pRepeat;


        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Explosion,
            Fastinvader1,
            Fastinvader2,
            Fastinvader3,
            Fastinvader4,
            InvaderKilled,
            Shoot,
            UFO_HighPitch,
            UFO_LowPitch,

            NullObject,
            Uninitialized

        }


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Sound(Sound.Name soundName, string fileName, float repeatTimeInterval) : base()
        {
            this.name = soundName;
            this.source = engine.AddSoundSourceFromFile(fileName);
            this.pRepeat = repeatTimeInterval;

        }

        public Sound() : base()
        {
            this.name = Sound.Name.Uninitialized;
            this.source = null;
            this.pRepeat = 0.0f;
        }


        //----------------------------------------------------------------------------------
        // Basic Methods
        //----------------------------------------------------------------------------------
        public Sound.Name GetName()
        {
            return this.name;
        }

        public float GetRepeatInterval()
        {
            return this.pRepeat;
        }


        public void Set(Sound.Name soundName, string fileName, float repeatTimeInterval)
        {
            this.name = soundName;
            this.source = engine.AddSoundSourceFromFile(fileName);
            this.pRepeat = repeatTimeInterval;
        }

        public void SetName(Sound.Name soundName)
        {
            this.name = soundName;
        }

        public void SetRepeatInterval(float sx)
        {
            Debug.Assert(sx >= 0.0f);
            this.pRepeat = sx;
        }

        public void Wash()
        {
            this.name = Sound.Name.Uninitialized;
            this.source = null;
            this.pRepeat = 0.0f;
        }

        public void Print()
        {
            Debug.WriteLine("SoundFile : {0}.wav   Repeat : {1} sec", this.name, this.pRepeat);
        }



        //----------------------------------------------------------------------------------
        // Play It
        //----------------------------------------------------------------------------------
        public void Play(float volInput = 0.2f)
        {
            IrrKlang.ISound music = engine.Play2D(this.source, false, false, false);
            if (music != null)
            {
                music.Volume = volInput;
            }
        }


    }
}
