using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FallDaggerStrategy : FallStrategy
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        
        private float oldPosY;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        
        public FallDaggerStrategy()
        {
            this.oldPosY = 0.0f;
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Fall(Bomb pBomb)
        {
            Debug.Assert(pBomb != null);

            float targetY = oldPosY - 1.0f * pBomb.GetBoundingBoxHeight();

            if (pBomb.y < targetY)
            {
                pBomb.MultiplyScale(1.0f, -1.0f);
                oldPosY = targetY;
            }
        }

        public override void Reset(float py)
        {
            this.oldPosY = py;
        }

    }
}
