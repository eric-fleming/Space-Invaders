using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory : Factory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly SpriteNodeBatch pSpriteBatch;
        private readonly SpriteNodeBatch pCollisionSpriteBatch;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public AlienFactory(SpriteNodeBatch.Name spriteBatchName, SpriteNodeBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteNodeBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteNodeBatchManager.Find(boxSpriteBatchName);
            Debug.Assert(this.pCollisionSpriteBatch != null);
        }



        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public GameObject Create(GameObject.Name theName, AlienCategory.Type type, float posx = 0.0f, float posy = 0.0f)
        {

            GameObject pGameObj = null;

            switch (type)
            {
                case AlienCategory.Type.AlienGrid:
                    pGameObj = new AlienGrid(theName,  GameSprite.Name.NullObject, posx, posy);
                    ((AlienGrid)pGameObj).SetCanDropBombs(true);
                    break;

                case AlienCategory.Type.Column:
                    pGameObj = new AlienColumn(theName,  GameSprite.Name.NullObject, posx, posy);
                    break;

                case AlienCategory.Type.Alien:
                    pGameObj = new AlienGO(theName,  GameSprite.Name.Alien, 20, posx, posy);
                    break;

                case AlienCategory.Type.Octopus:
                    pGameObj = new AlienGO(theName,  GameSprite.Name.Octopus, 10, posx, posy);
                    break;

                case AlienCategory.Type.Squid:
                    pGameObj = new AlienGO(theName,  GameSprite.Name.Squid, 30, posx, posy);
                    break;

                case AlienCategory.Type.UFOGrid:
                    pGameObj = new AlienGrid(theName, GameSprite.Name.NullObject, posx, posy);
                    ((AlienGrid)pGameObj).SetCanDropBombs(false);
                    break;

                case AlienCategory.Type.Saucer:
                    pGameObj = new AlienGO(theName, GameSprite.Name.Saucer, 100, posx, posy);
                    break;

                default:
                    Debug.WriteLine("Choose the Space Invader you want by name.");
                    Debug.Assert(false);
                    break;
            }

            // add it to the Game Object Manager
            Debug.Assert(pGameObj != null);
            
            // Should only attach root elements in the Scene

            // attach to the group
            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatch);

            return pGameObj;

        }



        public override GameObject Build(GameObject.Name theName, float posx = 0.0f, float posy = 0.0f)
        {
            // The build method is used to make the main elements on the screen
            GameObject pGameObj = null;

            switch (theName)
            {
                case GameObject.Name.AlienGrid:
                    pGameObj = this.CreateSwarmGrid();
                    break;

                case GameObject.Name.UFOGrid:
                    pGameObj = this.CreateUFOGrid();
                    break;

                default:
                    Debug.WriteLine("There is no default case.  Figure out what you want!");
                    Debug.Assert(false);
                    break;
            }

            return pGameObj;

        }





        //----------------------------------------------------------------------------------
        // Private Methods - Mainly used to help the build method
        //----------------------------------------------------------------------------------

        private void FillSwarmColumn(GameObject pColumn, float px, float py)
        {
            GameObject pGameObj;
            //AlienFactory AF = new AlienFactory(SpriteNodeBatch.Name.TheSwarm, SpriteNodeBatch.Name.Boxes);

            //Fill first two
            for (int i = 0; i < 5; i++)
            {
                pGameObj = null;
                if (i < 2)
                {
                    pGameObj = this.Create(GameObject.Name.Squid, AlienCategory.Type.Squid, px, py - 45.0f * i);
                }
                else if (i < 4)
                {
                    
                    pGameObj = this.Create(GameObject.Name.Alien, AlienCategory.Type.Alien, px, py - 45.0f * i);
                }
                else
                {
                    pGameObj = this.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, px, py - 45.0f * i);
                }
                Debug.Assert(pGameObj != null);
                pColumn.Add(pGameObj);
            }


        }

        public void RepopulateUFO()
        {
            GameObject pUFOGrid = GameObjectManager.Find(GameObject.Name.UFOGrid);
            Debug.Assert(pUFOGrid != null);
            GameObject pBoss = this.Create(GameObject.Name.Saucer, AlienCategory.Type.Saucer, 100.0f, 1100.0f);
            ((AlienGrid)pUFOGrid).SetMovementTimeInterval(0.5f);
            pUFOGrid.Add(pBoss);
            TimerManager.Add(TimeEvent.Name.SpawnUFO, new SpawnUFO((AlienGrid)pUFOGrid), 30.0f);

        }

        private GameObject CreateUFOGrid()
        {
            //AlienFactory AF = new AlienFactory(SpriteNodeBatch.Name.TheSwarm, SpriteNodeBatch.Name.Boxes);

            GameObject pUFOGrid = this.Create(GameObject.Name.UFOGrid, AlienCategory.Type.UFOGrid);

            // Starts off screen then jumps in with spawn timeEvent
            GameObject pBoss = this.Create(GameObject.Name.Saucer, AlienCategory.Type.Saucer, 100.0f, 1100.0f);
            ((AlienGrid)pUFOGrid).SetMovementTimeInterval(0.5f);
            pUFOGrid.Add(pBoss);
            GameObjectManager.Attach(pUFOGrid);

            return pUFOGrid;
        }

        public void RepopulateGrid()
        {
            GameObject pSwarmGrid = GameObjectManager.Find(GameObject.Name.AlienGrid);

            // Set the initial speed
            float speed = 0.8f - 0.06f*Level.GetCurrentLevel();
            ((AlienGrid)pSwarmGrid).movementTimeInterval = speed;

            GameObject pCol0 = this.Create(GameObject.Name.Column_0, AlienCategory.Type.Column);
            GameObject pCol1 = this.Create(GameObject.Name.Column_1, AlienCategory.Type.Column);
            GameObject pCol2 = this.Create(GameObject.Name.Column_2, AlienCategory.Type.Column);
            GameObject pCol3 = this.Create(GameObject.Name.Column_3, AlienCategory.Type.Column);
            GameObject pCol4 = this.Create(GameObject.Name.Column_4, AlienCategory.Type.Column);
            GameObject pCol5 = this.Create(GameObject.Name.Column_5, AlienCategory.Type.Column);
            GameObject pCol6 = this.Create(GameObject.Name.Column_6, AlienCategory.Type.Column);
            GameObject pCol7 = this.Create(GameObject.Name.Column_7, AlienCategory.Type.Column);
            GameObject pCol8 = this.Create(GameObject.Name.Column_8, AlienCategory.Type.Column);
            GameObject pCol9 = this.Create(GameObject.Name.Column_9, AlienCategory.Type.Column);
            GameObject pCol10 = this.Create(GameObject.Name.Column_10, AlienCategory.Type.Column);

            float ititHeight = 800.0f;
            float start_x = 100.0f;
            float w = 70.0f;
            FillSwarmColumn(pCol0, start_x, ititHeight);
            FillSwarmColumn(pCol1, start_x + 1.0f * w, ititHeight);
            FillSwarmColumn(pCol2, start_x + 2.0f * w, ititHeight);
            FillSwarmColumn(pCol3, start_x + 3.0f * w, ititHeight);
            FillSwarmColumn(pCol4, start_x + 4.0f * w, ititHeight);
            FillSwarmColumn(pCol5, start_x + 5.0f * w, ititHeight);
            FillSwarmColumn(pCol6, start_x + 6.0f * w, ititHeight);
            FillSwarmColumn(pCol7, start_x + 7.0f * w, ititHeight);
            FillSwarmColumn(pCol8, start_x + 8.0f * w, ititHeight);
            FillSwarmColumn(pCol9, start_x + 9.0f * w, ititHeight);
            FillSwarmColumn(pCol10, start_x + 10.0f * w, ititHeight);

            pSwarmGrid.Add(pCol0);
            pSwarmGrid.Add(pCol1);
            pSwarmGrid.Add(pCol2);
            pSwarmGrid.Add(pCol3);
            pSwarmGrid.Add(pCol4);
            pSwarmGrid.Add(pCol5);
            pSwarmGrid.Add(pCol6);
            pSwarmGrid.Add(pCol7);
            pSwarmGrid.Add(pCol8);
            pSwarmGrid.Add(pCol9);
            pSwarmGrid.Add(pCol10);

        }

        private GameObject CreateSwarmGrid()
        {
            //AlienFactory AF = new AlienFactory(SpriteNodeBatch.Name.TheSwarm, SpriteNodeBatch.Name.Boxes);

            GameObject pSwarmGrid = this.Create(GameObject.Name.AlienGrid, AlienCategory.Type.AlienGrid);

            GameObject pCol0 = this.Create(GameObject.Name.Column_0, AlienCategory.Type.Column);
            GameObject pCol1 = this.Create(GameObject.Name.Column_1, AlienCategory.Type.Column);
            GameObject pCol2 = this.Create(GameObject.Name.Column_2, AlienCategory.Type.Column);
            GameObject pCol3 = this.Create(GameObject.Name.Column_3, AlienCategory.Type.Column);
            GameObject pCol4 = this.Create(GameObject.Name.Column_4, AlienCategory.Type.Column);
            GameObject pCol5 = this.Create(GameObject.Name.Column_5, AlienCategory.Type.Column);
            GameObject pCol6 = this.Create(GameObject.Name.Column_6, AlienCategory.Type.Column);
            GameObject pCol7 = this.Create(GameObject.Name.Column_7, AlienCategory.Type.Column);
            GameObject pCol8 = this.Create(GameObject.Name.Column_8, AlienCategory.Type.Column);
            GameObject pCol9 = this.Create(GameObject.Name.Column_9, AlienCategory.Type.Column);
            GameObject pCol10 = this.Create(GameObject.Name.Column_10, AlienCategory.Type.Column);

            float ititHeight = 800.0f;
            float start_x = 100.0f;
            float w = 70.0f;
            FillSwarmColumn(pCol0, start_x, ititHeight);
            FillSwarmColumn(pCol1, start_x + 1.0f*w, ititHeight);
            FillSwarmColumn(pCol2, start_x + 2.0f * w, ititHeight);
            FillSwarmColumn(pCol3, start_x + 3.0f * w, ititHeight);
            FillSwarmColumn(pCol4, start_x + 4.0f * w, ititHeight);
            FillSwarmColumn(pCol5, start_x + 5.0f * w, ititHeight);
            FillSwarmColumn(pCol6, start_x + 6.0f * w, ititHeight);
            FillSwarmColumn(pCol7, start_x + 7.0f * w, ititHeight);
            FillSwarmColumn(pCol8, start_x + 8.0f * w, ititHeight);
            FillSwarmColumn(pCol9, start_x + 9.0f * w, ititHeight);
            FillSwarmColumn(pCol10, start_x + 10.0f * w, ititHeight);

            pSwarmGrid.Add(pCol0);
            pSwarmGrid.Add(pCol1);
            pSwarmGrid.Add(pCol2);
            pSwarmGrid.Add(pCol3);
            pSwarmGrid.Add(pCol4);
            pSwarmGrid.Add(pCol5);
            pSwarmGrid.Add(pCol6);
            pSwarmGrid.Add(pCol7);
            pSwarmGrid.Add(pCol8);
            pSwarmGrid.Add(pCol9);
            pSwarmGrid.Add(pCol10);

            GameObjectManager.Attach(pSwarmGrid);

            return pSwarmGrid;

        }


        //----------------------------------------------------------------------------------
        // Animation Methods
        //----------------------------------------------------------------------------------
        public void UFOAnimation(GameObject pBossGrid, float movementTimeInterval = 1.0f)
        {
            AlienGrid pUfoGrid = (AlienGrid)pBossGrid;
            TimerManager.Add(TimeEvent.Name.SpawnUFO, new SpawnUFO(pUfoGrid), 10.0f);

        }

        public void swarmAnimation(GameObject pAlienGrid)
        {
            GameObject pSwarmGrid = pAlienGrid;
            

            float repeatInterval = ((AlienGrid)pSwarmGrid).movementTimeInterval;
            Command pMoveAlienGrid = new MoveGrid((AlienGrid)pSwarmGrid);
            //TimerManager.Add(TimeEvent.Name.MoveGrid, pMoveAlienGrid, repeatInterval);


            AnimationSprite pAnimatedAlien = new AnimationSprite(GameSprite.Name.Alien, (AlienGrid)pSwarmGrid);
            pAnimatedAlien.Attach(Image.Name.AlienA);
            pAnimatedAlien.Attach(Image.Name.AlienB);
            //TimerManager.Add(TimeEvent.Name.SpriteAnimation, pAnimatedAlien, repeatInterval);


            AnimationSprite pAnimatedSquid = new AnimationSprite(GameSprite.Name.Squid, (AlienGrid)pSwarmGrid);
            pAnimatedSquid.Attach(Image.Name.SquidA);
            pAnimatedSquid.Attach(Image.Name.SquidB);
            //TimerManager.Add(TimeEvent.Name.SpriteAnimation, pAnimatedSquid, repeatInterval);


            AnimationSprite pAnimatedOctopus = new AnimationSprite(GameSprite.Name.Octopus, (AlienGrid)pSwarmGrid);
            pAnimatedOctopus.Attach(Image.Name.OctopusA);
            pAnimatedOctopus.Attach(Image.Name.OctopusB);
            //TimerManager.Add(TimeEvent.Name.SpriteAnimation, pAnimatedOctopus, repeatInterval);

            
            

            PlaySound pAlienSoundCommand = new PlaySound((AlienGrid)pSwarmGrid);

            //Oscillates the sounds
            pAlienSoundCommand.Attach(Sound.Name.Fastinvader1);
            pAlienSoundCommand.Attach(Sound.Name.Fastinvader2);
            pAlienSoundCommand.Attach(Sound.Name.Fastinvader3);
            pAlienSoundCommand.Attach(Sound.Name.Fastinvader4);

            //TimerManager.Add(TimeEvent.Name.PlaySound, pAlienSoundCommand, repeatInterval);


            // Chaining all of the commands
            // Move, spites, and sound
            CommandChain pSwarmAnimate = new CommandChain();
            pSwarmAnimate.Attach(pMoveAlienGrid);
            pSwarmAnimate.Attach(pAnimatedAlien);
            pSwarmAnimate.Attach(pAnimatedSquid);
            pSwarmAnimate.Attach(pAnimatedOctopus);
            pSwarmAnimate.Attach(pAlienSoundCommand);
            TimerManager.Add(TimeEvent.Name.CommandChain, pSwarmAnimate, repeatInterval);
        }


    }
}
