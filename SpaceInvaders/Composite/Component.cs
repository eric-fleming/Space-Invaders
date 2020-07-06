using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Component : CollVisitor
    {

        //----------------------------------------------------------------------------------
        // Staic Global Game Vars for Game Objects
        //----------------------------------------------------------------------------------
        static public float ghostDelta = 1.0f;
        static public float alienDelta = 1.0f;
        static public float bossDelta = 1.0f;
        static public readonly float GAMEWIDTH = 800.0f;
        static public readonly float GAMEHEIGHT = 600.0f;


        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public Component pParent = null;
        public Component pReverse = null;
        public Container holder = Container.UNDECIDED;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Container
        {
            LEAF,
            COMPOSITE,
            UNDECIDED
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods - for Composites and Leafs
        //----------------------------------------------------------------------------------
        
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Print();
        public abstract Component GetFirstChild();

    }
}
