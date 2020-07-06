using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldFactory : Factory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private SpriteNodeBatch pSpriteBatch;
        private readonly SpriteNodeBatch pCollisionSpriteBatch;
        private GameObject pTree;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ShieldFactory(SpriteNodeBatch.Name spriteBatchName, SpriteNodeBatch.Name collisionSpriteBatch, GameObject pTree)
        {
            this.pSpriteBatch = SpriteNodeBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteNodeBatchManager.Find(collisionSpriteBatch);
            Debug.Assert(this.pCollisionSpriteBatch != null);

            Debug.Assert(pTree != null);
            this.pTree = pTree;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public void SetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }


        public GameObject Create(ShieldCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pShield = null;

            switch (type)
            {
                case ShieldCategory.Type.Brick:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop1:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftTop1, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop0:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftTop0, posX, posY);
                    break;

                case ShieldCategory.Type.LeftBottom:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftBottom, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop1:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightTop1, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop0:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightTop0, posX, posY);
                    break;

                case ShieldCategory.Type.RightBottom:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightBottom, posX, posY);
                    break;

                case ShieldCategory.Type.Grid:
                    pShield = new ShieldGrid(gameName, GameSprite.Name.NullObject, posX, posY);
                    //pShield.SetCollisionColor(1.0f, 0.0f, 1.0f);
                    break;

                case ShieldCategory.Type.Root:
                    pShield = new ShieldRoot(gameName, GameSprite.Name.NullObject, posX, posY);
                    //pShield.SetCollisionColor(1.0f, 0.0f, 1.0f);
                    break;

                case ShieldCategory.Type.Column:
                    pShield = new ShieldColumn(gameName, GameSprite.Name.NullObject, posX, posY);
                    //pShield.SetCollisionColor(0.0f, 1.0f, 1.0f);
                    break;

                default:
                    Debug.WriteLine("Choose the Shield piece you want by name.");
                    Debug.Assert(false);
                    break;
            }

            // add to the tree
            this.pTree.Add(pShield);

            // Attached to Group
            pShield.ActivateGameSprite(this.pSpriteBatch);
            pShield.ActivateCollisionSprite(this.pCollisionSpriteBatch);

            return pShield;
        }




        public override GameObject Build(GameObject.Name theName, float x = 0.0f, float y = 0.0f)
        {
            
            GameObject pGameObj = null;

            switch (theName)
            {
                case GameObject.Name.ShieldRoot:
                    // brick width and height
                    pGameObj = this.BuildShields(x,y);
                    break;

                case GameObject.Name.ShieldGrid:
                    //pGameObj = 
                    break;

                default:
                    Debug.WriteLine("There is no default case.  Know what you want by name!");
                    Debug.Assert(false);
                    break;

            }

            return pGameObj;
        }



        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private GameObject BuildShields(float width, float height)
        {
            Composite pShieldRoot = (Composite)new ShieldRoot(GameObject.Name.ShieldRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectManager.Attach((GameObject)pShieldRoot);

            Composite pShield = ((Composite)new ShieldGrid(GameObject.Name.ShieldGrid, GameSprite.Name.NullObject, 0.0f, 0.0f));
            for (int s = 0; s < 4; s++)
            {
                pShield = this.BuildShield(150.0f + 180.0f * s, 170.0f, pShield);
                pShieldRoot.Add(pShield);
            }

            return (GameObject)pShieldRoot;

        }

        private Composite BuildShield(float start_x, float start_y, Composite pRoot)
        {
            // pShieldRoot == pRoot
            {
                int j = 0;

                GameObject pColumn;

                // Shield parameters
                float off_x = 0;
                float brickWidth = 10.0f;
                float brickHeight = 5.0f;


                // First Column
                this.SetParent(pRoot);
                pColumn = this.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                this.SetParent(pColumn);
                for (int h = 0; h < 8; h++)
                {
                    // 0 throguh 7
                    this.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + h * brickHeight);
                }
                this.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x, start_y + 8 * brickHeight);
                this.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x, start_y + 9 * brickHeight);



                // Second Column
                this.SetParent(pRoot);
                pColumn = this.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                this.SetParent(pColumn);
                off_x += brickWidth;

                for (int h = 0; h < 10; h++)
                {
                    // 0 throguh 9
                    this.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + h * brickHeight);
                }




                // Third Column
                this.SetParent(pRoot);
                pColumn = this.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                this.SetParent(pColumn);
                off_x += brickWidth;

                this.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                for (int h = 3; h < 10; h++)
                {
                    // 3 through 9
                    this.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + h * brickHeight);
                }




                //Fourth coulmn
                this.SetParent(pRoot);
                pColumn = this.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                this.SetParent(pColumn);
                off_x += brickWidth;

                for (int h = 3; h < 10; h++)
                {
                    // 3 through 9
                    this.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + h * brickHeight);
                }


                // Fifth Column
                this.SetParent(pRoot);
                pColumn = this.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                this.SetParent(pColumn);
                off_x += brickWidth;

                this.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                for (int h = 3; h < 10; h++)
                {
                    // 3 through 9
                    this.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + h * brickHeight);
                }



                // Sixth Column
                this.SetParent(pRoot);
                pColumn = this.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                this.SetParent(pColumn);
                off_x += brickWidth;

                for (int h = 0; h < 10; h++)
                {
                    // 0 through 9
                    this.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + h * brickHeight);
                }



                // Seventh Column
                this.SetParent(pRoot);
                pColumn = this.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                this.SetParent(pColumn);
                off_x += brickWidth;

                for (int h = 0; h < 8; h++)
                {
                    // 0 through 8
                    this.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + h * brickHeight);
                }
                this.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                this.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);
            }

            return pRoot;
        }

        


    }
}
