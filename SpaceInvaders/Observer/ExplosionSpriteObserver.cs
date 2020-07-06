using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionSpriteObserver : CollObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static ExplosionSpriteFactory EF = new ExplosionSpriteFactory(SpriteNodeBatch.Name.Explosions);


        public GameObject pTargetObj;
        public ExplosionSprite pExplosionSprite;
        public GameSprite.Name name;
        public float timeDelay;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionSpriteObserver(GameSprite.Name spriteName, float delay = 0.2f)
        {

            this.pTargetObj = null;
            this.pExplosionSprite = null;
            this.name = spriteName;
            this.timeDelay = delay;
        }

        public ExplosionSpriteObserver(ExplosionSpriteObserver pObserver)
        {
            this.pTargetObj = pObserver.pTargetObj;
            this.pExplosionSprite = pObserver.pExplosionSprite;
            this.name = pObserver.name;
            this.timeDelay = pObserver.timeDelay;
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveBombObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);


            // Need to separate out collision-pairs since this class can handle multiple Explosion cases.
            switch (this.name)
            {
                case GameSprite.Name.AlienExplosion:
                    this.pTargetObj = this.pSubject.pObjB;
                    break;

                case GameSprite.Name.MissileExplosion:
                    this.pTargetObj = this.pSubject.pObjA;
                    break;

                case GameSprite.Name.BombExplosion:
                    this.pTargetObj = this.pSubject.pObjA;
                    break;

                case GameSprite.Name.SaucerExplosion:
                    this.pTargetObj = this.pSubject.pObjB;
                    break;

                case GameSprite.Name.ShipExplosionA:
                    this.pTargetObj = this.pSubject.pObjB;
                    break;

                case GameSprite.Name.ShipExplosionB:
                    this.pTargetObj = this.pSubject.pObjB;
                    break;

                default:
                    Debug.WriteLine("There is no Default explosion.  Make sure you enter the name you want.");
                    Debug.Assert(false);
                    break;
            }

            Debug.Assert(this.pTargetObj != null);


            float px = this.pTargetObj.x;
            float py = this.pTargetObj.y;

            // Factor attaches to the correct sprite batches
            // Could be an AlienExplosion, BombExplosion, MissileExplosion
            // Should be explosion sprites

            this.pExplosionSprite = EF.Create(this.name, px, py);
            this.pExplosionSprite.SetPosition(px, py);


            //   Delay
            ExplosionSpriteObserver pObserver = new ExplosionSpriteObserver(this);
            DelayedObjectManager.Attach(pObserver);

        }


        public override void Execute()
        {
            //Debug.WriteLine("EXECUTING... REMOVE EXPLOSION");
            //this.pExplosionSprite.pProxySprite.Update();
            TimerManager.Add(TimeEvent.Name.ExplosionSprite, new ExplosionSpriteEvent(this.pExplosionSprite), this.timeDelay);

        }
    }
}
