using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShieldCategory : Leaf
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        protected ShieldCategory.Type type;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Type
        {
            Grid,
            Root,
            Column,
            Brick,

            LeftTop0,
            LeftTop1,
            LeftBottom,
            RightTop0,
            RightTop1,
            RightBottom,

            Unitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------

        protected ShieldCategory(GameObject.Name name, GameSprite.Name spriteName, ShieldCategory.Type shieldType)
            : base(name, spriteName)
        {
            this.type = shieldType;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public ShieldCategory.Type GetCategoryType()
        {
            return this.type;
        }
    }
}
