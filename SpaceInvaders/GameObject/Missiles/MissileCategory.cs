using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class MissileCategory : Leaf
    {
        protected MissileCategory.Type type;

        public enum Type
        {
            Missile,
            MissileGroup,
            Uninitialized
        }

        public MissileCategory(GameObject.Name gameName, GameSprite.Name spriteName, MissileCategory.Type mt)
            : base(gameName, spriteName)
        {
            this.type = mt;
        }

        public MissileCategory.Type GetCategoryType()
        {
            return this.type;
        }
    }
}
