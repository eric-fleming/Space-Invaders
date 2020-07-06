using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipReadyObserver : CollObserver
    {
        // Data



        // Methods
        public override void Notify()
        {
            Ship pShip = ShipMan.GetShip();

            //old way to do it
            //pShip.SetState(ShipMan.State.Ready);

            pShip.Handle();
        }



    }
}
