using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombSpawnEvent : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        GameObject pBombRoot;
        SpriteNodeBatch pSB_Invaders;
        SpriteNodeBatch pSB_Boxes;
        Random pRandom;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public BombSpawnEvent(Random pRandom)
        {
            this.pBombRoot = GameObjectManager.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

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

            // Create Bomb
            float bombType = pRandom.Next(0,3);
            float xVal = pRandom.Next(500, 700);

            // Hack : If yVal is too large it crashes??
            float yVal = 700.0f;
            Bomb pBomb;
            if (bombType < 1.0f)
            {
                pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombStraight, new FallStraightStrategy(), xVal, yVal);
                
            }
            else if (bombType < 2.0f)
            {
                pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombZigZag, new FallZigZagStrategy(), xVal, yVal);
            }
            else
            {
                pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombDagger, new FallDaggerStrategy(), xVal, yVal);
            }


            pBomb.ActivateCollisionSprite(this.pSB_Boxes);
            pBomb.ActivateGameSprite(this.pSB_Invaders);

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectManager.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pBombRoot.Add(pBomb);

        }
    }
}
