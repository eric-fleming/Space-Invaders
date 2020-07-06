using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class BumperCategory : Leaf
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public BumperCategory.Type type;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Type
        {
            BumperGroup,
            LeftBumper,
            RightBumper,
            Unitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public BumperCategory(GameObject.Name gameName, GameSprite.Name spriteName, BumperCategory.Type btype)
            : base(gameName, spriteName)
        {
            this.type = btype;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public BumperCategory.Type GetCategoryType()
        {
            return this.type;
        }
    }
}
