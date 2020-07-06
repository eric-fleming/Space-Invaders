using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMoveLeftState : ShipState
    {
        //----------------------------------------------------------------------------------
        // Handle
        //----------------------------------------------------------------------------------
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipMan.State.MoveLeftRight);
        }

        //----------------------------------------------------------------------------------
        // Movement Methods
        //----------------------------------------------------------------------------------

        public override void MoveRight(Ship pShip)
        {
            // void
        }

        public override void MoveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;
        }

        //----------------------------------------------------------------------------------
        // Shoot
        //----------------------------------------------------------------------------------
        public override void ShootMissile(Ship pShip)
        {
            //Debug.Assert(false);
        }
    }
}
