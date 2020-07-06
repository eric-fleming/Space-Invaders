using System;
using System.Diagnostics;

namespace SpaceInvaders
{


    class ReverseIterator : Iterator
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private Component pRoot;
        private Component pCurrent;
        private Component pPrev;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ReverseIterator(Component pStart)
        {
            Debug.Assert(pStart != null);
            Debug.Assert(pStart.holder == Component.Container.COMPOSITE);

            // Use a Forward Iterator to generate a Reverse Iterator
            ForwardIterator pForward = new ForwardIterator(pStart);

            this.pRoot = pStart;
            this.pCurrent = this.pRoot;
            this.pPrev = null;

            Component pPrevNode = this.pRoot;

            //The Reverse Pointer
            Component pNode = pForward.First();

            while (!pForward.IsDone())
            {
                // cache
                pPrevNode = pNode;

                // Advance
                pNode = pForward.Next();
                if (pNode != null)
                {
                    pNode.pReverse = pPrevNode;
                }
            }

            pRoot.pReverse = pPrevNode;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override Component First()
        {
            Debug.Assert(this.pRoot != null);

            this.pCurrent = this.pRoot.pReverse;
            return this.pCurrent;
        }

        public override bool IsDone()
        {
            return (this.pPrev == this.pRoot);
        }

        public override Component Next()
        {
            Debug.Assert(this.pCurrent != null);

            this.pPrev = this.pCurrent;
            this.pCurrent = this.pCurrent.pReverse;

            return this.pCurrent;
        }
    }
}
