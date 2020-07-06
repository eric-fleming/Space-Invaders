using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    

    public class SpaceInvaders : Azul.Game
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public static SceneContext pSceneContext = null;


        //----------------------------------------------------------------------------------
        // Old Data - Eventually Refactor Out
        //----------------------------------------------------------------------------------



        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------

        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("------------>>>> Space Invaders Demo 0, 1, 2, 3 <<<<------------");
            this.SetWidthHeight(896, 1024);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

            // -------------------- Create the Managers --------------------

            Simulation.Create();
            TimerManager.Create(5, 2);


            SoundManager.Create(9, 1);
            TextureManager.Create(1,1);
            ImageManager.Create(5, 2);
            

            

            // REWORK - SpriteBatchMan
            //    It's a singleton... but it holds an actual instance pointer to the SpriteBatchMan instance
            //    this way scene can own their unique sprite batch man independent of other scenes
            //
            // SpriteBatchMan.Create(3, 1); 
            //                    
            // Once you understand this... you have to do this for many other systems
            //


            SpriteNodeBatchManager.Create();
            
            GameSpriteManager.Create(4, 4);
            BoxSpriteManager.Create(3, 1);
            ProxySpriteManager.Create(10, 1);
            GameObjectManager.Create();
            CollPairManager.Create(5, 1);


            GlyphManager.Create(36, 1);
            FontManager.Create(1, 1);
            InputManager.Create();


            pSceneContext = new SceneContext();



        }


        private void SoundUpdate()
        {
            //Need to make global vars so this to function

            //shootCount++;
            //if (shootCount == 50)
            //{
            //    shootCount = 0;
            //    // play one by file, not by load 
            //    //sndEngine.Play2D("shoot.wav");
            //}

            //// Trigger already loaded sounds
            //if (pBossGrid.x >= 700.0f || pBossGrid.x <= 100.0f)
            //{

            //    switch (modSoundCount)
            //    {
            //        case 0:
            //            sndEngine.Play2D(sndVader0, false, false, false);
            //            break;
            //        case 1:
            //            sndEngine.Play2D(sndVader1, false, false, false);
            //            break;
            //        case 2:
            //            sndEngine.Play2D(sndVader2, false, false, false);
            //            break;
            //        case 3:
            //            sndEngine.Play2D(sndVader3, false, false, false);
            //            break;
            //        default:
            //            Debug.Assert(false);
            //            break;
            //    }

            //    modSoundCount++;
            //    if (modSoundCount == 4)
            //    {
            //        modSoundCount = 0;
            //    }
            //}
        }
        
        
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------


        public override void Update()
        {
            // Add your update below this line: ----------------------------
            //  stuff called every update no matter the scene here... 
            //  example: like audio update


            GlobalTimer.Update(this.GetTime());

            // Hack to proof of concept...
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_0) == true)
            {
                pSceneContext.SetState(SceneContext.Scene.Demo);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_3) == true)
            {
                pSceneContext.SetState(SceneContext.Scene.Select);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                pSceneContext.SetState(SceneContext.Scene.Play);
                Score.SetCurrentPlayer(1);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true)
            {
                pSceneContext.SetState(SceneContext.Scene.Play);
                Score.SetCurrentPlayer(2);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_4) == true)
            {
                pSceneContext.SetState(SceneContext.Scene.GameOver);
            }

            

            // Update the scene
            (pSceneContext.GetState()).Update(this.GetTime());



        }


        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------

        public override void Draw()
        {
            // Draw the scene
            // Universal Draw with the state Pattern
            pSceneContext.GetState().Draw();

        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

