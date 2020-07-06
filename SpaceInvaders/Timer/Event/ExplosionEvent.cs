using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionEvent : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        GameObject pExplosion;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ExplosionEvent(GameObject gameobj)
        {
            this.pExplosion = gameobj;
        }


        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {
            this.pExplosion.SetCoords(-100.0f, -100.0f);
            this.pExplosion.Update();
            // Setting and updating
            //Debug.WriteLine("Setting and updating to (-100, -100)");
            //this.pExplosion.Remove();
            //Debug.WriteLine("Attempting to remove....");
            
        }
    }
}
