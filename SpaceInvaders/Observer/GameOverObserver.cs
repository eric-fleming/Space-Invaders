using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameOverObserver : CollObserver
    {
        

        public GameOverObserver()
        {
            
        }

        public GameOverObserver(GameOverObserver pOver)
        {
            
        }

        public override void Notify()
        {
            GameOverObserver pObserver = new GameOverObserver(this);
            DelayedObjectManager.Attach(pObserver);
        }

        public override void Execute()
        {
            SpaceInvaders.pSceneContext.SetState(SceneContext.Scene.GameOver);
        }
    }
}
