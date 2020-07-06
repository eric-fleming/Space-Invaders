using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BumperObserver : CollObserver
    {


        public BumperObserver()
        {

        }




        public override void Notify()
        {
            Debug.WriteLine("Bumper_Observer: {0} {1}", this.pSubject.pObjA.GetName(), this.pSubject.pObjB.GetName());

            // OK do some alphabetic magic
            BumperCategory pBumper = (BumperCategory)this.pSubject.pObjA;
            Ship pShip = (Ship)this.pSubject.pObjB;


            if (pBumper.GetCategoryType() == BumperCategory.Type.RightBumper)
            {
                pShip.SetMoveState(ShipMan.State.MoveLeft);

            }
            else if (pBumper.GetCategoryType() == BumperCategory.Type.LeftBumper)
            {
                pShip.SetMoveState(ShipMan.State.MoveRight);
            }


        }
    }
}
