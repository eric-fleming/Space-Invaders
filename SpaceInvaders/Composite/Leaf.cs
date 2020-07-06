using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Leaf : GameObject
    {

        //----------------------------------------------------------------------------------
        // Data - Should be some concrete GameObject
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Leaf(GameObject.Name gameName, GameSprite.Name spriteName)
            : base(gameName, spriteName)
        {
            this.holder = Container.LEAF;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Add(Component c)
        {
            //This method should not be invoked on this type of object
            Debug.Assert(false);
        }

        public override void Remove(Component c)
        {
            //This method should not be invoked on this type of object
            Debug.Assert(false);
        }

        public override Component GetFirstChild()
        {
            Debug.Assert(false);
            return null;
        }

        public override void Print()
        {
            Debug.WriteLine("\t\t   GameObject Name : {0} ({1}) | My Parent : ({2})", this.GetName(), this.GetHashCode(), Iterator.GetParent(this).GetHashCode());
        }

    }
}
