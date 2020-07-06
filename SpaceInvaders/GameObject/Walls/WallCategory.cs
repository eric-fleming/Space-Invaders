using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class WallCategory : Leaf
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public WallCategory.Type type;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Bottom,
            Top,
            Unitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        
        public WallCategory(GameObject.Name gameName, GameSprite.Name spriteName, WallCategory.Type wtype)
            : base(gameName,spriteName) 
        {
            this.type = wtype;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        
        public WallCategory.Type GetCategoryType()
        {
            return this.type;
        }
    }
}
