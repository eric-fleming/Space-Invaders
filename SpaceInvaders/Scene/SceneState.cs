using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SceneState
    {
        // Data
        public float TimeAtPause;



        // Constructor
        public SceneState()
        {
            this.TimeAtPause = TimerManager.GetCurrentTime();
        }



        // Common Methods that all scenes use.
        public abstract void Handle();
        public abstract void LoadContent();
        public abstract void Update(float systemTime);
        public abstract void Draw();
        public abstract void Entering();
        public abstract void Leaving();



        // public virtual onEnter onExit
        public virtual void CreateManagers() {
            Debug.WriteLine("Scene needs to implement its own CreateManagers() method.");
            Debug.Assert(false);
        }


    }
}
