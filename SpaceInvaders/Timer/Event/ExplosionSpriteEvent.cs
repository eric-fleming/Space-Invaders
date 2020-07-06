using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionSpriteEvent : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        ExplosionSprite pExplosionSprite;
        

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionSpriteEvent(ExplosionSprite expSprite)
        {
            this.pExplosionSprite = expSprite;
        }


        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {
            // Hopefully removes okay... fingers crossed
            this.pExplosionSprite.RemoveExplosion();

        }
    }
}
