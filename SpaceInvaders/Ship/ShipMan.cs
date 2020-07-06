using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMan
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static ShipMan pInstance = null;

        // Active
        private Ship pShip;
        private Missile pMissile;

        // Reference
        private ShipStateReady pStateReady;
        private ShipStateMissileFlying pStateMissileFlying;
        private readonly ShipStateDead pStateDead;

        private ShipMoveLeftRightState pMoveLeftRightState;
        private ShipMoveLeftState pMoveLeftState;
        private ShipMoveRightState pMoveRightState;


        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum State
        {
            Ready,
            MissileFlying,
            MoveLeft,
            MoveRight,
            MoveNone,
            MoveLeftRight,

            Dead
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private ShipMan()
        {
            // Store the states
            this.pStateReady = new ShipStateReady();
            this.pStateMissileFlying = new ShipStateMissileFlying();
            this.pStateDead = new ShipStateDead();


            this.pMoveLeftRightState = new ShipMoveLeftRightState();
            this.pMoveLeftState = new ShipMoveLeftState();
            this.pMoveRightState = new ShipMoveRightState();

            // set active
            this.pShip = null;
            this.pMissile = null;
        }

        public static void Create()
        {
            // make sure its the first time
            //Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new ShipMan();
            }

            Debug.Assert(pInstance != null);

            // Stuff to initialize after the instance was created
            pInstance.pShip = ActivateShip();
            pInstance.pShip.SetState(ShipMan.State.Ready);

        }

        private static ShipMan PrivInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static Ship GetShip()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }

        public static ShipState GetState(State state)
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            ShipState pShipState = null;

            switch (state)
            {
                case ShipMan.State.Ready:
                    pShipState = pShipMan.pStateReady;
                    break;

                case ShipMan.State.MissileFlying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;

                case ShipMan.State.Dead:
                    pShipState = pShipMan.pStateDead;
                    break;

                case ShipMan.State.MoveLeftRight:
                    pShipState = pShipMan.pMoveLeftRightState;
                    break;

                case ShipMan.State.MoveLeft:
                    pShipState = pShipMan.pMoveLeftState;
                    break;

                case ShipMan.State.MoveRight:
                    pShipState = pShipMan.pMoveRightState;
                    break;


                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static Missile GetMissile()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }

        public static Missile ActivateMissile()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            // TODO: This can be cleaned up more... no need to re-calling new()
            Missile pMissile = new Missile(GameObject.Name.Missile, GameSprite.Name.Missile, 400, 100);
            pShipMan.pMissile = pMissile;

            // Attached to SpriteBatches
            SpriteNodeBatch pSB_Player = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Players);
            SpriteNodeBatch pSB_Boxes = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Boxes);

            pMissile.ActivateCollisionSprite(pSB_Boxes);
            pMissile.ActivateGameSprite(pSB_Player);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectManager.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pShipMan.pMissile);

            return pShipMan.pMissile;
        }


        private static Ship ActivateShip()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            Ship pShip = new Ship(GameObject.Name.Ship, GameSprite.Name.Ship, 400, 120);
            pShipMan.pShip = pShip;

            // Attach the sprite to the correct sprite batch
            SpriteNodeBatch pSB_Player = SpriteNodeBatchManager.Find(SpriteNodeBatch.Name.Players);
            pSB_Player.Attach(pShip.pProxySprite);

            // Attach the missile to the missile root
            GameObject pShipRoot = GameObjectManager.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pShipRoot.Add(pShipMan.pShip);

            return pShipMan.pShip;
        }

        

    }
}
