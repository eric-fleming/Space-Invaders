using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionSpriteManager
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------

        private readonly ExplosionSpriteFactory pParentFactory;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionSpriteManager(ExplosionSpriteFactory pFactory)
        {
            // most of the work is carried out by base class
            //this.baseInitialize();
            this.pParentFactory = pFactory;
        }

    }
}
