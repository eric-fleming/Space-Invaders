using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipStateReady : ShipState
    {
        //----------------------------------------------------------------------------------
        // Handle
        //----------------------------------------------------------------------------------
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipMan.State.MissileFlying);
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
            pShip.x -= pShip.shipSpeed;
        }

        //----------------------------------------------------------------------------------
        // Shoot
        //----------------------------------------------------------------------------------
        public override void ShootMissile(Ship pShip)
        {
            Missile pMissile = ShipMan.ActivateMissile();

            pMissile.SetPos(pShip.x, pShip.y+20);

            //play sound
            Ship.soundEngine.SoundVolume = 0.15f;
            Ship.soundEngine.Play2D(Ship.shootSound, false, false, false);

            // switch states
            this.Handle(pShip);
        }

    }
}
