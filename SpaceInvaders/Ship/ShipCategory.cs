using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipCategory : Leaf
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        protected ShipCategory.Type type;


        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Type
        {
            Ship,
            ShipRoot,
            Unitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        protected ShipCategory(GameObject.Name name, GameSprite.Name spriteName, ShipCategory.Type shipType)
            : base(name, spriteName)
        {
            this.type = shipType;
        }


        

    }
}