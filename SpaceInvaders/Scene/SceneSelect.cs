using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneSelect : SceneState
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public SpriteNodeBatchManager poSpriteNodeBatchMan;
        public GameObjectManager poGameObjectManager;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public SceneSelect()
        {
            this.CreateManagers();
            this.LoadContent();
        }

        public override void CreateManagers()
        {
            this.poSpriteNodeBatchMan = new SpriteNodeBatchManager(3, 1);
            SpriteNodeBatchManager.SetActive(this.poSpriteNodeBatchMan);

            this.poGameObjectManager = new GameObjectManager(5, 1);
            GameObjectManager.SetActive(this.poGameObjectManager);
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        
        public override void Handle()
        {
            Debug.WriteLine("Handle called from << SELECT SCENE >>");
        }


        public override void LoadContent()
        {
            

            SpriteNodeBatch pSB_Texts = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Texts);

            Texture pTexture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);





            TextureManager.Add(Texture.Name.SpaceInvaders, "SpaceInvaders.tga");
            ImageManager.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageManager.Add(Image.Name.AlienA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageManager.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageManager.Add(Image.Name.Saucer, Texture.Name.SpaceInvaders, 99, 3, 16, 8);


            //----------------------------------------------------------------------------------
            // Print Space Invaders Title Scene
            //----------------------------------------------------------------------------------

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


            int playTextLine = topTextLine - 200;
            pFont = FontManager.Add(Font.Name.Play, SpriteNodeBatch.Name.Texts, "PLAY", Glyph.Name.Consolas36pt, 400, playTextLine);
            pFont = FontManager.Add(Font.Name.GameTitle, SpriteNodeBatch.Name.Texts, "SPACE   INVADERS", Glyph.Name.Consolas36pt, 300, playTextLine - 60);


            int advTableTop = topTextLine - 430;
            pFont = FontManager.Add(Font.Name.ScoreTable, SpriteNodeBatch.Name.Texts, "*SCORE   ADVANCE   TABLE*", Glyph.Name.Consolas36pt, 200, advTableTop);


            int leftAlignPoints = 335;
            float size = 36.0f;


            GameSpriteManager.Add(GameSprite.Name.Saucer, Image.Name.Saucer, leftAlignPoints, advTableTop - 50, 60, 30);
            pFont = FontManager.Add(Font.Name.UFO_Points, SpriteNodeBatch.Name.Texts, "  =? MYSTERY", Glyph.Name.Consolas36pt, leftAlignPoints, advTableTop - 50);
            

            GameSpriteManager.Add(GameSprite.Name.Squid, Image.Name.SquidA, leftAlignPoints, advTableTop - 100, size, size);
            pFont = FontManager.Add(Font.Name.Squid_Points, SpriteNodeBatch.Name.Texts, "  =30 POINTS", Glyph.Name.Consolas36pt, leftAlignPoints, advTableTop - 100);


            GameSpriteManager.Add(GameSprite.Name.Alien, Image.Name.AlienA, leftAlignPoints, advTableTop - 150, size, size);
            pFont = FontManager.Add(Font.Name.Alien_Points, SpriteNodeBatch.Name.Texts, "  =20 POINTS", Glyph.Name.Consolas36pt, leftAlignPoints, advTableTop - 150);


            GameSpriteManager.Add(GameSprite.Name.Octopus, Image.Name.OctopusA, leftAlignPoints, advTableTop - 200, size, size);
            pFont = FontManager.Add(Font.Name.Octopus_Points, SpriteNodeBatch.Name.Texts, "  =10 POINTS", Glyph.Name.Consolas36pt, leftAlignPoints, advTableTop - 200);
            pFont.SetColor(0.1f, 0.9f, 0.1f);




            // -----------------------------------------------------------------------------
            // ---------------------- Create Sprite Node Batches ---------------------------
            // -----------------------------------------------------------------------------



            //SpriteNodeBatch pBatch_Texts = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Texts, 2);
            //SpriteNodeBatch pBatch_Player = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Players, 5);
            //SpriteNodeBatch pBatch_TheSwarm = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.TheSwarm, 10);
            //SpriteNodeBatch pBatch_Shields = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Shields, 200);
            SpriteNodeBatch pSB_Invaders = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Invaders, 100);
            SpriteNodeBatch pBatch_Boxes = SpriteNodeBatchManager.Add(SpriteNodeBatch.Name.Boxes, 400);
            pBatch_Boxes.SetDrawStatus(false);


            AlienFactory AF = new AlienFactory(SpriteNodeBatch.Name.Invaders, SpriteNodeBatch.Name.Boxes);

            AlienColumn pAlienCol = (AlienColumn)AF.Create(GameObject.Name.Column_0, AlienCategory.Type.Column);
            GameObject pGameObj;
            pGameObj = AF.Create(GameObject.Name.Saucer, AlienCategory.Type.Saucer, leftAlignPoints - 9, advTableTop - 50);
            pAlienCol.Add(pGameObj);
            pGameObj = AF.Create(GameObject.Name.Squid, AlienCategory.Type.Squid, leftAlignPoints, advTableTop - 100);
            pAlienCol.Add(pGameObj);
            pGameObj = AF.Create(GameObject.Name.Alien, AlienCategory.Type.Alien, leftAlignPoints, advTableTop - 150);
            pAlienCol.Add(pGameObj);
            pGameObj = AF.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, leftAlignPoints, advTableTop - 200);
            pAlienCol.Add(pGameObj);

            GameObjectManager.Attach(pAlienCol);

        }

        public override void Update(float systemTime)
        {
            // walk through all objects and push to flyweight
            GameObjectManager.Update();

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
            GameObjectManager.SetActive(this.poGameObjectManager);

            Font pHighScore = FontManager.Find(Font.Name.HighScore);
            Score.SaveHighScore(pHighScore);

        }

        public override void Leaving()
        {
            // update SpriteBatchMan()
            this.TimeAtPause = TimerManager.GetCurrentTime();
        }


    }
}
