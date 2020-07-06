﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ForwardIterator : Iterator
    {

        // --------------------------------------------------
        //  Data
        // --------------------------------------------------
        private readonly Component pRoot;
        private Component pCurrent;

        // --------------------------------------------------
        //  Constructor
        // --------------------------------------------------
        public ForwardIterator(Component pStart)
        {
            Debug.Assert(pStart != null);
            Debug.Assert(pStart.holder == Component.Container.COMPOSITE);

            this.pCurrent = pStart;
            this.pRoot = pStart;
        }

        private Component PrivNextStep(Component pNode, Component pParent, Component pChild, Component pSibling)
        {
            pNode = null;

            if (pChild != null)
            {
                pNode = pChild;
            }
            else
            {
                if (pSibling != null)
                {
                    pNode = pSibling;
                }
                else
                {
                    // No more 
                    //       siblings... 
                    //       children...
                    // Go up a level to the parent

                    while (pParent != null)
                    {
                        pNode = GetSibling(pParent);
                        if (pNode != null)
                        {
                            // Found one
                            break;
                        }
                        else
                        {
                            // Go fish
                            pParent = GetParent(pParent);
                        }
                    }
                }
            }

            return pNode;
        }

        override public Component First()
        {
            Debug.Assert(this.pRoot != null);
            Component pNode = this.pRoot;

            Debug.Assert(pNode != null);
            this.pCurrent = pNode;

            // Debug.WriteLine("---> {0} ", this.pCurr.GetHashCode());
            return this.pCurrent;
        }
        override public Component Next()
        {
            Debug.Assert(this.pCurrent != null);

            Component pNode = this.pCurrent;

            Component pChild = GetChild(pNode);
            Component pSibling = GetSibling(pNode);
            Component pParent = GetParent(pNode);

            // Start - Depth first iteration
            pNode = PrivNextStep(pNode, pParent, pChild, pSibling);

            this.pCurrent = pNode;

            return this.pCurrent;
        }

        override public bool IsDone()
        {
            return (this.pCurrent == null);
        }
    }
}
