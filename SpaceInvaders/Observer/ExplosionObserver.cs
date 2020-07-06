using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ExplosionObserver : CollObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static ExplosionFactory EF = new ExplosionFactory(SpriteNodeBatch.Name.Explosions, SpriteNodeBatch.Name.Boxes);


        public GameObject pTargetObj;
        public GameObject pExplosion;
        public GameObject.Name name;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionObserver(GameObject.Name gameName)
        {

            this.pTargetObj = null;
            this.pExplosion = null;
            this.name = gameName;
        }

        public ExplosionObserver(ExplosionObserver pObserver)
        {
            this.pTargetObj = pObserver.pTargetObj;
            this.pExplosion = pObserver.pExplosion;
            this.name = pObserver.name;
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
                case GameObject.Name.AlienExplosion:
                    this.pTargetObj = this.pSubject.pObjB;
                    break;

                case GameObject.Name.MissileExplosion:
                    this.pTargetObj = this.pSubject.pObjA;
                    break;

                case GameObject.Name.BombExplosion:
                    this.pTargetObj = this.pSubject.pObjA;
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
            this.pExplosion = EF.Create(this.name, px, py);
            
            // Attach the missile to the missile root
            GameObject pExplosionRoot = GameObjectManager.Find(GameObject.Name.ExplosionRoot);
            Debug.Assert(pExplosionRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pExplosionRoot.Add(this.pExplosion);

            //   Delay
            ExplosionObserver pObserver = new ExplosionObserver(this);
            DelayedObjectManager.Attach(pObserver);

        }


        public override void Execute()
        {
            // Remove it from the screen later
            //Debug.WriteLine("EXECUTING... REMOVE EXPLOSION");
            TimerManager.Add(TimeEvent.Name.ExplodeAndRemove, new ExplosionEvent(this.pExplosion), 0.3f);

        }

    }
}
