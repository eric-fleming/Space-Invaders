using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DropBomb : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        GameObject pBombRoot;
        SpriteNodeBatch pSB_Invaders;
        SpriteNodeBatch pSB_Boxes;
        private static Random psRandom = new Random();

        private readonly float x;
        private readonly float y;
        private int hash;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public DropBomb(float px, float py)
        {
            this.x = px;
            this.y = py;

            this.pBombRoot = GameObjectManager.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.pSB_Invaders = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.TheSwarm);
            Debug.Assert(this.pSB_Invaders != null);

            this.pSB_Boxes = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            GameObject pGrid = GameObjectManager.Find(GameObject.Name.AlienGrid);
            hash = pGrid.GetHashCode();


        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {
            //Debug.WriteLine("{0}------------- DROPPING BOMB !!!", hash);
            //Debug.WriteLine("({0}, {1})", this.x, this.y);

            // Create Bomb
            int bombType = psRandom.Next(0, 3);
            Bomb pBomb;

            if (bombType == 1.0f)
            {
                pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombZigZag, new FallZigZagStrategy(), this.x, this.y);

            }
            else if (bombType == 2.0f)
            {
                pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombDagger, new FallDaggerStrategy(), this.x, this.y);
            }
            else
            {
                pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombRolling, new FallDaggerStrategy(), this.x, this.y);
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
