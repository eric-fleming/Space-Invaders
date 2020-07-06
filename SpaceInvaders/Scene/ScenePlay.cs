using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ScenePlay : SceneState
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public SpriteNodeBatchManager poSpriteNodeBatchMan;
        
        // TODO : make these Multiverse static
        public InputManager poInputManager;
        public GameObjectManager poGameObjectManager;


        //----------------------------------------------------------------------------------
        // Global Data - From PA6
        //----------------------------------------------------------------------------------


        readonly Random pRandom = new Random();

        // Text
        public int count;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ScenePlay()
        {
            this.CreateManagers();
            this.LoadContent();
            Level.createFactory();
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Handle()
        {
            Debug.WriteLine("Handle called from << PLAY SCENE >>");
        }

        public override void CreateManagers()
        {
            this.poSpriteNodeBatchMan = new SpriteNodeBatchManager(5, 1);
            SpriteNodeBatchManager.SetActive(this.poSpriteNodeBatchMan);

            this.poGameObjectManager = new GameObjectManager(5, 1);
            GameObjectManager.SetActive(this.poGameObjectManager);

            this.poInputManager = new InputManager(false);
            InputManager.SetActive(this.poInputManager);

        }

        public override void LoadContent()
        {

            // -----------------------------------------------------------------------------
            // ---------------------- Sound Setup ------------------------------------------
            // -----------------------------------------------------------------------------

            SoundManager.Add(Sound.Name.Fastinvader1, "fastinvader1.wav");
            SoundManager.Add(Sound.Name.Fastinvader2, "fastinvader2.wav");
            SoundManager.Add(Sound.Name.Fastinvader3, "fastinvader3.wav");
            SoundManager.Add(Sound.Name.Fastinvader4, "fastinvader4.wav");
            SoundManager.Add(Sound.Name.Shoot, "shoot.wav");
            SoundManager.Add(Sound.Name.Explosion, "explosion.wav");
            SoundManager.Add(Sound.Name.InvaderKilled, "invaderkilled.wav");
            SoundManager.Add(Sound.Name.UFO_HighPitch, "ufo_highpitch.wav");
            SoundManager.Add(Sound.Name.UFO_LowPitch, "ufo_lowpitch.wav");


            // -----------------------------------------------------------------------------
            // ------------------- Load the Textures ---------------------------------------
            // -----------------------------------------------------------------------------

            TextureManager.Add(Texture.Name.SpaceInvaders, "SpaceInvaders.tga");
            TextureManager.Add(Texture.Name.Invaders, "birds_N_shield.tga");
            Texture pTexture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            // -----------------------------------------------------------------------------
            // -------------------- Creating Images ----------------------------------------
            // -----------------------------------------------------------------------------

            ImageManager.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageManager.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageManager.Add(Image.Name.AlienA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageManager.Add(Image.Name.AlienB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageManager.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageManager.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);
            ImageManager.Add(Image.Name.AlienExplosion, Texture.Name.SpaceInvaders, 83, 3, 13, 8);
            ImageManager.Add(Image.Name.Saucer, Texture.Name.SpaceInvaders, 99, 3, 16, 8);
            ImageManager.Add(Image.Name.SaucerExplosion, Texture.Name.SpaceInvaders, 118, 3, 21, 8);

            ImageManager.Add(Image.Name.Ship, Texture.Name.SpaceInvaders, 3, 14, 13, 8);
            ImageManager.Add(Image.Name.ShipExplosionA, Texture.Name.SpaceInvaders, 19, 14, 16, 8);
            ImageManager.Add(Image.Name.ShipExplosionB, Texture.Name.SpaceInvaders, 38, 14, 16, 8);
            ImageManager.Add(Image.Name.Missile, Texture.Name.SpaceInvaders, 3, 29, 1, 4);
            ImageManager.Add(Image.Name.MissileExplosion, Texture.Name.SpaceInvaders, 7, 25, 8, 8);

            ImageManager.Add(Image.Name.Wall, Texture.Name.Invaders, 40, 185, 20, 10);

            ImageManager.Add(Image.Name.BombStraight, Texture.Name.Invaders, 111, 101, 5, 49);
            ImageManager.Add(Image.Name.BombZigZagA, Texture.Name.SpaceInvaders, 18, 26, 3, 7);
            ImageManager.Add(Image.Name.BombZigZagB, Texture.Name.SpaceInvaders, 24, 26, 3, 7);
            ImageManager.Add(Image.Name.BombZigZagC, Texture.Name.SpaceInvaders, 30, 26, 3, 7);
            ImageManager.Add(Image.Name.BombZigZagD, Texture.Name.SpaceInvaders, 36, 26, 3, 7);
            ImageManager.Add(Image.Name.BombDaggerA, Texture.Name.SpaceInvaders, 42, 27, 3, 6);
            ImageManager.Add(Image.Name.BombDaggerB, Texture.Name.SpaceInvaders, 48, 27, 3, 6);
            ImageManager.Add(Image.Name.BombDaggerC, Texture.Name.SpaceInvaders, 54, 27, 3, 6);
            ImageManager.Add(Image.Name.BombDaggerD, Texture.Name.SpaceInvaders, 60, 27, 3, 6);
            ImageManager.Add(Image.Name.BombRollingA, Texture.Name.SpaceInvaders, 65, 26, 3, 7);
            ImageManager.Add(Image.Name.BombRollingB, Texture.Name.SpaceInvaders, 70, 26, 3, 7);
            ImageManager.Add(Image.Name.BombRollingC, Texture.Name.SpaceInvaders, 75, 26, 3, 7);
            ImageManager.Add(Image.Name.BombRollingD, Texture.Name.SpaceInvaders, 80, 26, 3, 7);
            ImageManager.Add(Image.Name.BombExplosion, Texture.Name.SpaceInvaders, 86, 25, 6, 8);

            ImageManager.Add(Image.Name.Brick, Texture.Name.Invaders, 20, 210, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top0, Texture.Name.Invaders, 15, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top1, Texture.Name.Invaders, 15, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Invaders, 35, 215, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top0, Texture.Name.Invaders, 75, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top1, Texture.Name.Invaders, 75, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Bottom, Texture.Name.Invaders, 55, 215, 10, 5);



            // -----------------------------------------------------------------------------
            // ---------------------- Creating GameSprites ---------------------------------
            // -----------------------------------------------------------------------------
            float dim = 33.0f;
            float sm = dim;
            float md = dim * 1.15f;
            float lg = dim * 1.30f;


            GameSpriteManager.Add(GameSprite.Name.Squid, Image.Name.SquidA, 200, 400, sm, sm);
            GameSpriteManager.Add(GameSprite.Name.Alien, Image.Name.AlienA, 200, 200, md, md);
            GameSpriteManager.Add(GameSprite.Name.Octopus, Image.Name.OctopusA, 200, 300, lg, lg);
            
            GameSpriteManager.Add(GameSprite.Name.Saucer, Image.Name.Saucer, 300, 250, 60, 30);
            GameSpriteManager.Add(GameSprite.Name.SaucerExplosion, Image.Name.SaucerExplosion,300, 250, 60, 30);
            GameSpriteManager.Add(GameSprite.Name.AlienExplosion, Image.Name.AlienExplosion, -10, -10, dim, dim);

            // Utility for ship state movement

            float projWidth = 8.0f;
            float projHeight = 16.0f;
            GameSpriteManager.Add(GameSprite.Name.Missile, Image.Name.Missile, 0, 0, 0.5f * projWidth, 0.75f * projHeight);
            GameSpriteManager.Add(GameSprite.Name.MissileExplosion, Image.Name.MissileExplosion, 0, 0, 0.7f*dim, 0.7f * dim);
            GameSpriteManager.Add(GameSprite.Name.Ship, Image.Name.Ship, 400, 100, 60, 21);
            GameSpriteManager.Add(GameSprite.Name.ShipExplosionA, Image.Name.ShipExplosionA, 400, 100, 90, 31);
            GameSpriteManager.Add(GameSprite.Name.ShipExplosionB, Image.Name.ShipExplosionB, 400, 100, 90, 31);

            GameSpriteManager.Add(GameSprite.Name.Wall, Image.Name.Wall, 448, 100, 850, 4);

            GameSpriteManager.Add(GameSprite.Name.BombStraight, Image.Name.BombStraight, 100, 100, projWidth, projHeight);
            GameSpriteManager.Add(GameSprite.Name.BombZigZag, Image.Name.BombZigZagA, 200, 200, projWidth, projHeight);
            GameSpriteManager.Add(GameSprite.Name.BombDagger, Image.Name.BombDaggerA, 100, 100, projWidth, projHeight);
            GameSpriteManager.Add(GameSprite.Name.BombRolling, Image.Name.BombRollingA, 100, 100, projWidth, projHeight);
            GameSpriteManager.Add(GameSprite.Name.BombExplosion, Image.Name.BombExplosion, 100, 100, 0.5f * dim, 0.7f * dim);



            float brick_w = 12.0f;
            float brick_h = 6.0f;
            GameSpriteManager.Add(GameSprite.Name.Brick, Image.Name.Brick, 50, 25, brick_w, brick_h);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, brick_w, brick_h);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 50, 25, brick_w, brick_h);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, brick_w, brick_h);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, brick_w, brick_h);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 50, 25, brick_w, brick_h);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, brick_w, brick_h);



            // -----------------------------------------------------------------------------
            // ---------------------- Create Sprite Node Batches ---------------------------
            // -----------------------------------------------------------------------------

            

            SpriteNodeBatch pBatch_Texts = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Texts, 2);
            SpriteNodeBatch pBatch_Player = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Players, 5);
            SpriteNodeBatch pBatch_TheSwarm = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.TheSwarm, 10);
            SpriteNodeBatch pBatch_Explosions = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Explosions, 20);
            SpriteNodeBatch pBatch_Shields = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Shields, 200);
            SpriteNodeBatch pBatch_Boxes = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Boxes, 400);

            pBatch_Boxes.SetDrawStatus(false);
            Debug.WriteLine("Finished : Loading Sprite Batches");

            // -----------------------------------------------------------------------------
            // ---------------------- Instantiate Local GameObject Manager -----------------
            // -----------------------------------------------------------------------------

            // Moved to CreateManagers()


            // -----------------------------------------------------------------------------
            // ---------------------- Font Setup ------------------------------------------
            // -----------------------------------------------------------------------------

            Font pFont;

            int topTextLine = 980;

            pFont = FontManager.Add(Font.Name.Score1_Title, SpriteNodeBatch.Name.Texts, "SCORE<1>", Glyph.Name.Consolas36pt, 100, topTextLine);
            pFont = FontManager.Add(Font.Name.HighScore_Title, SpriteNodeBatch.Name.Texts, "HI-SCORE<1>", Glyph.Name.Consolas36pt, 350, topTextLine);
            pFont = FontManager.Add(Font.Name.Score2_Title, SpriteNodeBatch.Name.Texts, "SCORE<2>", Glyph.Name.Consolas36pt, 650, topTextLine);


            int scoreTextLine = 940;
            int x_shift = 40;
            pFont = FontManager.Add(Font.Name.Score1, SpriteNodeBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 100 + x_shift, scoreTextLine);
            pFont = FontManager.Add(Font.Name.HighScore, SpriteNodeBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 350 + x_shift, scoreTextLine);
            pFont = FontManager.Add(Font.Name.Score2, SpriteNodeBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 650 + x_shift, scoreTextLine);


            FontManager.Add(Font.Name.LifeCount, SpriteNodeBatch.Name.Texts, "3", Glyph.Name.Consolas36pt, 100, 50);




            // -----------------------------------------------------------------------------
            // ---------------------- Create Bomb GameObjects -------------------------------
            // -----------------------------------------------------------------------------
            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(pBatch_Boxes);
            GameObjectManager.Attach(pBombRoot);



            // -----------------------------------------------------------------------------
            // ---------------------- Create Explosion GameObjects -------------------------------
            // -----------------------------------------------------------------------------
            ExplosionFactory EF = new ExplosionFactory(SpriteNodeBatch.Name.Explosions, SpriteNodeBatch.Name.Boxes);
            GameObject pExplosionRoot = EF.Build(GameObject.Name.ExplosionRoot, 0.0f, 0.0f);


            // -----------------------------------------------------------------------------
            // ---------------------- Create Grids of Nested GameObjects -------------------
            // -----------------------------------------------------------------------------




            GameObject pWallGroup;
            GameObject pSwarmGrid;
            GameObject pUFOGrid;
            GameObject pShieldRoot;
            MissileGroup pMissileGroup = CreateMissleGroup(pBatch_Player, pBatch_Boxes);
            GameObject pBumperGroup = CreateBumperGroup(pBatch_Player, pBatch_Boxes);

            pWallGroup = CreateWalls(pBatch_TheSwarm, pBatch_Boxes);
            Debug.WriteLine("Finished : Creating the walls");



            AlienFactory AF = new AlienFactory(SpriteNodeBatch.Name.TheSwarm, SpriteNodeBatch.Name.Boxes);

            pSwarmGrid = AF.Build(GameObject.Name.AlienGrid);
            AF.swarmAnimation(pSwarmGrid);
            Debug.WriteLine("Finished : Creating the Swarm");




            pUFOGrid = AF.Build(GameObject.Name.UFOGrid);
            AF.UFOAnimation(pUFOGrid);
            Debug.WriteLine("Finished : Creating the UfO Boss");




            Debug.WriteLine("Create Animations Gamesprites");
            pShieldRoot = new ShieldRoot(GameObject.Name.ShieldRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            ShieldFactory SF = new ShieldFactory(SpriteNodeBatch.Name.Shields, SpriteNodeBatch.Name.Boxes, pShieldRoot);
            pShieldRoot = SF.Build(GameObject.Name.ShieldRoot);

            // -----------------------------------------------------------------------------
            // ---------------------- Create Ship GameObject ----------------------
            // -----------------------------------------------------------------------------

            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectManager.Attach(pShipRoot);
            ShipMan.Create();
            Debug.WriteLine("Finished : Creating the ShipRoot and Ship");





            // -----------------------------------------------------------------------------
            // ---------------------- Collision Pairs --------------------------------------
            // -----------------------------------------------------------------------------


            // Alien vs Missile
            CollPair pAttackAliens = CollPairManager.Add(CollPair.Name.Alien_Missle, pMissileGroup, pSwarmGrid);
            Debug.Assert(pAttackAliens != null);
            pAttackAliens.Attach(new ShipReadyObserver());
            pAttackAliens.Attach(new RemoveMissileObserver());
            pAttackAliens.Attach(new RemoveAlienObserver());
            pAttackAliens.Attach(new SoundObserverKillAlien());
            pAttackAliens.Attach(new ExplosionSpriteObserver(GameSprite.Name.AlienExplosion));

            // Alien vs Shild
            CollPair pAlienHitShield = CollPairManager.Add(CollPair.Name.Alien_Shield, pSwarmGrid, pShieldRoot);
            pAlienHitShield.Attach(new RemoveBrickObserver());
            pAlienHitShield.Attach(new SoundObserverExplosion());

            // AlienGrid vs Left/Right Wall
            CollPair pHitWall = CollPairManager.Add(CollPair.Name.Alien_SideWalls, pSwarmGrid, pWallGroup);
            Debug.Assert(pHitWall != null);
            pHitWall.Attach(new GridObserver());


            //// AlienGrid vs Bottom Wall
            //CollPair pBottomWall = CollPairManager.Add(CollPair.Name.Alien_BottomWall, pSwarmGrid, pWallGroup);
            //Debug.Assert(pHitWall != null);
            //pBottomWall.Attach(new GameOverObserver());


            // Bumper vs Ship
            CollPair pHitBumper = CollPairManager.Add(CollPair.Name.Bumper_Ship, pBumperGroup, pShipRoot);
            pHitBumper.Attach(new BumperObserver());


            // Bomb vs Ship
            CollPair pHitShip = CollPairManager.Add(CollPair.Name.Bomb_Ship, pBombRoot, pShipRoot);
            pHitShip.Attach(new RemoveBombObserver());
            pHitShip.Attach(new ExplosionSpriteObserver(GameSprite.Name.BombExplosion));
            pHitShip.Attach(new SoundObserverExplosion());
            pHitShip.Attach(new ShipTakeDamageObserver());  // triggers GAMEOVER
            pHitShip.Attach(new ExplosionSpriteObserver(GameSprite.Name.ShipExplosionA));
            pHitShip.Attach(new ExplosionSpriteObserver(GameSprite.Name.ShipExplosionB, 0.4f));
            //pHitShip.Attach(new GameOverObserver());


            // Bomb vs Bottom
            CollPair pHitBottom = CollPairManager.Add(CollPair.Name.Bomb_WallBottom, pBombRoot, pWallGroup);
            pHitBottom.Attach(new RemoveBombObserver());
            pHitBottom.Attach(new ExplosionSpriteObserver(GameSprite.Name.BombExplosion));

            // Bomb vs Missile
            CollPair pBombvsMissile = CollPairManager.Add(CollPair.Name.Bomb_Missile, pBombRoot, pMissileGroup);
            pBombvsMissile.Attach(new ShipReadyObserver());
            pBombvsMissile.Attach(new RemoveBombObserver());
            pBombvsMissile.Attach(new RemoveMissileObserver());
            pBombvsMissile.Attach(new ExplosionSpriteObserver(GameSprite.Name.BombExplosion));
            pBombvsMissile.Attach(new SoundObserverExplosion());


            // Bomb vs Shield
            CollPair pHitBombShield = CollPairManager.Add(CollPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            pHitBombShield.Attach(new RemoveBombObserver());
            pHitBombShield.Attach(new RemoveBrickObserver());
            pHitBombShield.Attach(new SoundObserverExplosion());
            pHitBombShield.Attach(new ExplosionSpriteObserver(GameSprite.Name.BombExplosion));


            // Missile vs Top-Wall
            CollPair pHitTopWall = CollPairManager.Add(CollPair.Name.Missile_WallTop, pMissileGroup, pWallGroup);
            Debug.Assert(pHitTopWall != null);
            pHitTopWall.Attach(new ShipReadyObserver()); 
            pHitTopWall.Attach(new RemoveMissileObserver());  //ShipRemoveMissileObserver()
            pHitTopWall.Attach(new ExplosionSpriteObserver(GameSprite.Name.MissileExplosion));


            // Missile vs Shield
            CollPair pColPair = CollPairManager.Add(CollPair.Name.Missile_Shield, pMissileGroup, pShieldRoot);
            pColPair.Attach(new ShipReadyObserver());
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new SoundObserverExplosion());



            // UFO vs WallGroup
            CollPair pUFOvsWall = CollPairManager.Add(CollPair.Name.Saucer_Wall, pUFOGrid, pWallGroup);
            pUFOvsWall.Attach(new GridObserverUFO());



            // UFO vs Missile
            CollPair pUFOvsMissile = CollPairManager.Add(CollPair.Name.Missile_UFO, pMissileGroup, pUFOGrid);
            pUFOvsMissile.Attach(new ShipReadyObserver());
            pUFOvsMissile.Attach(new RemoveMissileObserver());
            pUFOvsMissile.Attach(new RemoveUFOObserver());
            pUFOvsMissile.Attach(new SoundObserverKillAlien());
            pUFOvsMissile.Attach(new ExplosionSpriteObserver(GameSprite.Name.SaucerExplosion));

            Debug.WriteLine("Finished : Loading Collision Pairs");



            // -----------------------------------------------------------------------------
            // ---------------------- Test Input Handles -----------------------------------
            // -----------------------------------------------------------------------------

            // Creation moved to createManagers()

            InputSubject pInputSubject;
            pInputSubject = InputManager.GetArrowRightSubject();
            pInputSubject.Attach(new MoveRightObserver());

            pInputSubject = InputManager.GetArrowLeftSubject();
            pInputSubject.Attach(new MoveLeftObserver());

            pInputSubject = InputManager.GetSpaceSubject();
            pInputSubject.Attach(new ShootObserver());

            pInputSubject = InputManager.GetBkeySubject();
            pInputSubject.Attach(new RenderCollisionBoxesObserver());

            
            Simulation.SetState(Simulation.State.Realtime);

            Debug.WriteLine("Finished : Loading Input Subject");

        }



        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Handels Keyboard input
            InputManager.Update();

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Fire off the timer events
                TimerManager.Update(Simulation.GetTotalTime());


                // walk through all objects and push to flyweight
                GameObjectManager.Update();


                // Do the collision checks
                CollPairManager.Process();

                
                // Delete any objects here...
                DelayedObjectManager.Process();

                // Check to see if all aliens are dead to move to the next level.
                Level.Update();

            }


        }

        public override void Draw()
        {
            //Draws everything
            SpriteNodeBatchManager.Draw();
        }


        public override void Entering()
        {
            // Make sure all of the game settings are inline
            Lives.ResetLives();
            Score.ResetPlayerScores();
            Level.Reset();


            // update
            SpriteNodeBatchManager.SetActive(this.poSpriteNodeBatchMan);
            GameObjectManager.SetActive(this.poGameObjectManager);
            InputManager.SetActive(this.poInputManager);


            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerManager.PauseUpdate(delta);

        }

        public override void Leaving()
        {
            Font pHighScore = FontManager.Find(Font.Name.HighScore);
            Score.SaveHighScore(pHighScore);

            // update SpriteBatchMan()
            this.TimeAtPause = TimerManager.GetCurrentTime();
        }


        //----------------------------------------------------------------------------------
        // Private Methods - Further down means less important
        //----------------------------------------------------------------------------------


        private GameObject CreateBumperGroup(SpriteNodeBatch activateGame, SpriteNodeBatch activateCollision)
        {
            BumperGroup pBumperGroup = new BumperGroup(GameObject.Name.BumperGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pBumperGroup.ActivateGameSprite(activateGame);
            pBumperGroup.ActivateCollisionSprite(activateCollision);

            BumperRight pBumperRight = new BumperRight(GameObject.Name.BumperRight, GameSprite.Name.NullObject, 840.0f, 120.0f, 20.0f, 50.0f);
            pBumperRight.ActivateCollisionSprite(activateCollision);

            BumperLeft pBumperLeft = new BumperLeft(GameObject.Name.BumperLeft, GameSprite.Name.NullObject, 60.0f, 120.0f, 20.0f, 50.0f);
            pBumperLeft.ActivateCollisionSprite(activateCollision);

            // Add to the composite the children
            pBumperGroup.Add(pBumperRight);
            pBumperGroup.Add(pBumperLeft);
            GameObjectManager.Attach(pBumperGroup);

            return (GameObject)pBumperGroup;

        }


        private GameObject CreateWalls(SpriteNodeBatch activateGame, SpriteNodeBatch activateCollision)
        {
            // Called above : CreateWalls(pBatch_TheSwarm, pBatch_Boxes);

            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateGameSprite(activateGame);
            pWallGroup.ActivateCollisionSprite(activateCollision);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, GameSprite.Name.NullObject, 870.0f, 500.0f, 35.0f, 1000.0f);
            pWallRight.ActivateCollisionSprite(activateCollision);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, GameSprite.Name.NullObject, 30.0f, 500.0f, 35.0f, 1000.0f);
            pWallLeft.ActivateCollisionSprite(activateCollision);

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, GameSprite.Name.NullObject, 448, 950, 890, 50);
            pWallTop.ActivateCollisionSprite(activateCollision);

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, GameSprite.Name.Wall, 448, 80, 890, 10);
            pWallBottom.ActivateCollisionSprite(activateCollision);
            pWallBottom.ActivateGameSprite(activateGame);

            // Add to the composite the children
            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);
            
            GameObjectManager.Attach(pWallGroup);

            return (GameObject)pWallGroup;

        }


        private MissileGroup CreateMissleGroup(SpriteNodeBatch playerBatch, SpriteNodeBatch collisionBoxBatch)
        {
            // -----------------------------------------------------------------------------
            // ---------------------- Create Missile GameObjecs ----------------------------
            // -----------------------------------------------------------------------------

            MissileGroup pMissileGroup = new MissileGroup(GameObject.Name.MissileGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pMissileGroup.ActivateGameSprite(playerBatch);
            pMissileGroup.ActivateCollisionSprite(collisionBoxBatch);
            GameObjectManager.Attach(pMissileGroup);

            Debug.WriteLine("Finished : Creating the Missile Group");

            return pMissileGroup;
        }


    }
}
