using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallFactory : Factory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly SpriteNodeBatch pSpriteBatch;
        private readonly SpriteNodeBatch pCollisionSpriteBatch;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public WallFactory(SpriteNodeBatch.Name spriteBatchName, SpriteNodeBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteNodeBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteNodeBatchManager.Find(boxSpriteBatchName);
            Debug.Assert(this.pCollisionSpriteBatch != null);
        }



        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public GameObject Create(GameObject.Name theName, WallCategory.Type type)
        {

            GameObject pGameObj = null;

            switch (type)
            {
                case WallCategory.Type.WallGroup:
                    pGameObj = new WallGroup(theName, GameSprite.Name.NullObject, 0.0f, 0.0f);
                    pGameObj.ActivateGameSprite(this.pSpriteBatch);
                    pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatch);
                    break;


                case WallCategory.Type.Left:
                    pGameObj = new WallLeft(theName, GameSprite.Name.NullObject, 30.0f, 500.0f, 35.0f, 1000.0f);
                    pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatch);
                    break;

                case WallCategory.Type.Right:
                    pGameObj = new WallRight(theName, GameSprite.Name.NullObject, 870.0f, 500.0f, 35.0f, 1000.0f);
                    pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatch);
                    break;

                case WallCategory.Type.Top:
                    pGameObj = new WallTop(theName, GameSprite.Name.NullObject, 448, 950, 890, 50);
                    pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatch);
                    break;

                case WallCategory.Type.Bottom:
                    pGameObj = new WallBottom(theName, GameSprite.Name.Wall, 448, 80, 890, 10);
                    pGameObj.ActivateGameSprite(this.pSpriteBatch);
                    pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatch);
                    break;

                default:
                    Debug.WriteLine("Choose the Wall you want by name.");
                    Debug.Assert(false);
                    break;
            }

            // add it to the Game Object Manager
            Debug.Assert(pGameObj != null);

            // Should only attach root elements to the GameObjectManager in the Scene

            // attach to the group in the switch statments because not all of them attach the same
            

            return pGameObj;

        }

        public override GameObject Build(GameObject.Name theName, float posx = 0.0f, float posy = 0.0f)
        {
            // The build method is used to make the main elements on the screen
            GameObject pGameObj = null;

            switch (theName)
            {
                case GameObject.Name.WallGroupLeftRight:
                    pGameObj = this.BuildLeftRightWallGroup();
                    break;

                case GameObject.Name.WallGroupTopBottom:
                    pGameObj = this.BuildTopBottomWallGroup();
                    break;

                default:
                    Debug.WriteLine("There is no default case.  Figure out what you want!");
                    Debug.Assert(false);
                    break;
            }

            return pGameObj;

        }
    
        private GameObject BuildLeftRightWallGroup()
        {
            GameObject pWallGroup = this.Create(GameObject.Name.WallGroupLeftRight, WallCategory.Type.WallGroup);
            GameObject pWallRight = this.Create(GameObject.Name.WallRight, WallCategory.Type.Right);
            GameObject pWallLeft = this.Create(GameObject.Name.WallLeft, WallCategory.Type.Left);


            // Add to the composite the children
            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);

            GameObjectManager.Attach(pWallGroup);

            return pWallGroup;
        }

        private GameObject BuildTopBottomWallGroup()
        {
            GameObject pWallGroup = this.Create(GameObject.Name.WallGroupTopBottom, WallCategory.Type.WallGroup);
            GameObject pWallTop = this.Create(GameObject.Name.WallTop, WallCategory.Type.Top);
            GameObject pWallBottom = this.Create(GameObject.Name.WallBottom, WallCategory.Type.Bottom);


            // Add to the composite the children
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);

            GameObjectManager.Attach(pWallGroup);

            return pWallGroup;
        }



    }
}
