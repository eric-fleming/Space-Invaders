using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FallStraightStrategy : FallStrategy
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private float oldPosY;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public FallStraightStrategy()
        {
            this.oldPosY = 0.0f;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Fall(Bomb pBomb)
        {
            Debug.Assert(pBomb != null);
            // Do nothing special
        }

        public override void Reset(float py)
        {
            this.oldPosY = py;
        }
    }
}
