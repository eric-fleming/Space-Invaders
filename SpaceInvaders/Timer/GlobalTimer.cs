using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GlobalTimer
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static GlobalTimer pInstance = null;
        protected float mCurrTime;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private GlobalTimer()
        {
            this.mCurrTime = 0.0f;
        }


        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        
        
        public static void Update(float time)
        {
            GlobalTimer pTimer = GlobalTimer.privGetInstance();
            Debug.Assert(pTimer !=  null);
            pTimer.mCurrTime = time;
        }

        public static float GetTime()
        {
            GlobalTimer pTimer = GlobalTimer.privGetInstance();
            Debug.Assert(pTimer != null);
            return pTimer.mCurrTime;
        }


        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private static GlobalTimer privGetInstance()
        {
            // Will lazy create the static Global Timer if it does not exist.
            if (pInstance == null)
            {
                pInstance = new GlobalTimer();
            }

            return pInstance;
        }
    }
}
