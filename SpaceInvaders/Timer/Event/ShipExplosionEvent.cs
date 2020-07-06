using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipExplosionEvent : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        GameSprite.Name spriteName;
        GameObject pShip;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ShipExplosionEvent(GameObject ship, GameSprite.Name name)
        {
            this.spriteName = name;
            this.pShip = ship;
        }


        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {
            //GameObject pShip = ((GameObject)this.pShip);
            //TimerManager.Add(TimeEvent.Name.ShipExplosionEvent, new ShipExplosionEvent(pShip, GameSprite.Name.ShipExplosionA), 0.0f);
            //TimerManager.Add(TimeEvent.Name.ShipExplosionEvent, new ShipExplosionEvent(pShip, GameSprite.Name.ShipExplosionB), 0.25f);
            //TimerManager.Add(TimeEvent.Name.ShipExplosionEvent, new ShipExplosionEvent(pShip, GameSprite.Name.Ship), 0.5f);
            this.pShip.SetGameSprite(this.spriteName);
        }
    }
}
