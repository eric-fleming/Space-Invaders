using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMoveRightState : ShipState
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
            pShip.x += pShip.shipSpeed;
        }

        public override void MoveLeft(Ship pShip)
        {
            // void
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
