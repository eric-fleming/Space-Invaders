using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Iterator
    {
        // --------------------------------------------------
        //  Abstract Methods - to be overriden
        // --------------------------------------------------
        abstract public Component First();
        abstract public Component Next();
        abstract public bool IsDone();


        // --------------------------------------------------
        //  Helper Methods - base class
        // --------------------------------------------------

        public static Component GetParent(Component pLink)
        {
            Debug.Assert(pLink != null);
            return pLink.pParent;
        }

        public static Component GetChild(Component pLink)
        {
            Debug.Assert(pLink != null);

            // Assume it is a Leaf, therefore no children.
            Component pChild = null;

            if (pLink.holder == Component.Container.COMPOSITE)
            {
                //could have children, go look.
                pChild = pLink.GetFirstChild();
            }

            return pChild;
        }


        public static Component GetSibling(Component pLink)
        {
            Debug.Assert(pLink != null);
            return (Component)pLink.pNext;
        }
    }
}
