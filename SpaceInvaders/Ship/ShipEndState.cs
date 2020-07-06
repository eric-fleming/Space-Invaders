using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipStateDead : ShipState
    {

        //----------------------------------------------------------------------------------
        // Handle
        //----------------------------------------------------------------------------------
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipMan.State.Ready);
        }

        //----------------------------------------------------------------------------------
        // Movement Methods
        //----------------------------------------------------------------------------------
        public override void MoveRight(Ship pShip)
        {
            //Does nothing
        }

        public override void MoveLeft(Ship pShip)
        {
            //Does nothing
        }

        //----------------------------------------------------------------------------------
        // Shoot
        //----------------------------------------------------------------------------------

        public override void ShootMissile(Ship pShip)
        {
            //Does nothing
        }
    }
}
