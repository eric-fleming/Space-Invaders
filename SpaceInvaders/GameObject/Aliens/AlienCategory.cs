using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class AlienCategory : Leaf
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        protected AlienCategory.Type type;
        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Type
        {
            Alien,
            AlienExplosion,
            AlienGrid,
            Octopus,
            Squid,
            Saucer,
            SaucerExplosion,
            UFOGrid,

            Grid,
            Column,
            Uninitialized
        }
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public AlienCategory(GameObject.Name gameObjName, GameSprite.Name gameSpriteName, AlienCategory.Type at)
            : base(gameObjName,gameSpriteName)
        {
            this.type = at;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        
        public AlienCategory.Type GetCategoryType()
        {
            return this.type;
        }

    }
}
