using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileSpawnEvent : Command
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        GameObject pMissileRoot;
        SpriteNodeBatch pSB_Invaders;
        SpriteNodeBatch pSB_Boxes;
        Random pRandom;
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public MissileSpawnEvent(Random pRandom)
        {
            this.pMissileRoot = GameObjectManager.Find(GameObject.Name.MissileGroup);
            Debug.Assert(this.pMissileRoot != null);

            this.pSB_Invaders = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.TheSwarm);
            Debug.Assert(this.pSB_Invaders != null);

            this.pSB_Boxes = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.pRandom = pRandom;
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {
            //Debug.WriteLine("event: {0}", deltaTime);

            // Create missile
            float xVal = this.pRandom.Next(100, 700);
            // Hack: Also if I spawn too low it happens
            float yVal = 0.0f;

            Missile pMissile = new Missile(GameObject.Name.Missile, GameSprite.Name.Missile, xVal, yVal);
            //     Debug.WriteLine("----x:{0}", value);

            pMissile.ActivateCollisionSprite(pSB_Boxes);
            pMissile.ActivateGameSprite(pSB_Invaders);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectManager.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pMissile);

        }

    }
}
