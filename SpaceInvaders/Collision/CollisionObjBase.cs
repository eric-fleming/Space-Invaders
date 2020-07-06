using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollisionObjBase
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public BoxSprite pCollSprite;
        public CollRect poColRect;



        public abstract void UpdatePos(float x, float y);
    }
}
