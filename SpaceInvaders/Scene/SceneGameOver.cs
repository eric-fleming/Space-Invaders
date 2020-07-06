using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SceneGameOver : SceneState
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public SpriteNodeBatchManager poSpriteNodeBatchMan;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SceneGameOver()
        {
            this.CreateManagers();
            this.LoadContent();
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Handle()
        {
            Debug.WriteLine("Handle called from << GAME OVER SCENE >>");
        }

        public override void CreateManagers()
        {
            this.poSpriteNodeBatchMan = new SpriteNodeBatchManager(3, 1);
            SpriteNodeBatchManager.SetActive(this.poSpriteNodeBatchMan);


        }

        public override void LoadContent()
        {
            this.poSpriteNodeBatchMan = new SpriteNodeBatchManager(3, 1);
            SpriteNodeBatchManager.SetActive(this.poSpriteNodeBatchMan);

            SpriteNodeBatch pSB_Texts = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Texts);

            Texture pTexture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            Font pFont;
            pFont = FontManager.Add(Font.Name.GameOver, SpriteNodeBatch.Name.Texts, "GAME OVER", Glyph.Name.Consolas36pt, 300, 400);
            pFont.SetColor(0.50f, 0.50f, 0.50f);



            // -----------------------------------------------------------------------------
            // ---------------------- Create Sprite Node Batches ---------------------------
            // -----------------------------------------------------------------------------



            SpriteNodeBatch pBatch_Texts = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Texts, 2);
            SpriteNodeBatch pBatch_Player = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Players, 5);
            SpriteNodeBatch pBatch_TheSwarm = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.TheSwarm, 10);
            SpriteNodeBatch pBatch_Shields = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Shields, 200);


            SpriteNodeBatch pBatch_Boxes = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Boxes, 400);
            pBatch_Boxes.SetDrawStatus(false);


        }

        public override void Update(float systemTime)
        {
            

        }

        public override void Draw()
        {
            // draw all objects
            SpriteNodeBatchManager.Draw();
        }

        public override void Entering()
        {
            // update
            SpriteNodeBatchManager.SetActive(this.poSpriteNodeBatchMan);

        }

        public override void Leaving()
        {
            // update SpriteBatchMan()
            this.TimeAtPause = TimerManager.GetCurrentTime();

            SpaceInvaders.pSceneContext.ResetState(SceneContext.Scene.Play);
        }


    }
}
