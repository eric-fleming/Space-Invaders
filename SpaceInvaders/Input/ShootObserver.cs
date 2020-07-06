using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShootObserver : InputObserver
    {
        public override void Notify()
        {
            //Debug.WriteLine("Shoot Fired!! (Observer)");
            Ship pShip = ShipMan.GetShip();
            pShip.ShootMissile();
        }
    }
}