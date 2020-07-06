using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Manager
    {
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        public DLink poHeadActive;
        public DLink poHeadReserve;

        private int mNumActiveNodes;
        private int mNumReserveNodes;
        private int mNumTotalNodes;
        private int growthRate;

        //----------------------------------------------------------------------
        // Abstract methods - the "contract" Derived class must implement
        //----------------------------------------------------------------------
        abstract protected DLink derivedCreateNode();
        abstract protected bool derivedCompare(DLink pLinkA, DLink pLinkB);
        abstract protected void derivedWash(DLink pLink);
        abstract protected void derivedPrint(DLink pLink);

        //----------------------------------------------------------------------
        // Concstructor
        //----------------------------------------------------------------------
        protected Manager(int InitialNodesInReserve = 5, int deltaRate = 2)
        {
            //Check for valid inputs
            Debug.Assert(InitialNodesInReserve >= 0);
            Debug.Assert(deltaRate > 0);

            // init
            this.poHeadActive = null;
            this.poHeadReserve = null;
            this.mNumActiveNodes = 0;
            this.mNumReserveNodes = 0;
            this.mNumTotalNodes = 0;
            this.growthRate = deltaRate;

            // fill with empty nodes
            this.privFillReservePool(InitialNodesInReserve);

        }

        protected void baseInitialize(int initReserve = 3, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            this.growthRate = growthRate;

            // This method updates the counters
            this.privFillReservePool(initReserve);
        }


        //----------------------------------------------------------------------
        // Base Methods
        //----------------------------------------------------------------------
        public DLink baseAdd()
        {
            //calls addtofront in DLink
            // derived add method will have parameters

            //Check if there are any nodes in reserve
            if (this.poHeadReserve == null)
            {
                //perform a refill
                this.privFillReservePool(this.growthRate);
            }

            // Now that we are guarenteed that the reserve is not-empty we can pull
            DLink pLink = DLink.PullFromFront(ref this.poHeadReserve);

            //Clean the node of data and references to other DLinks
            pLink.Clear();
            this.derivedWash(pLink);


            // initialize
            DLink.AddToFront(ref this.poHeadActive, pLink);

            // update counters
            this.mNumActiveNodes++;
            this.mNumReserveNodes--;

            return pLink;

        }

        public void baseRemove(DLink pLink)
        {
            // remove safely
            Debug.Assert(pLink != null);
            DLink target = this.baseFind(pLink);

            DLink.RemoveNode(ref this.poHeadActive, target);

            if (target != null)
            {
                // Clean the node
                target.Clear();
                this.derivedWash(target);

                // Push the node to the reserve list
                DLink.AddToFront(ref this.poHeadReserve, target);

                // update counters
                this.mNumActiveNodes--;
                this.mNumReserveNodes++;
            }
        }


        public DLink baseFind(DLink pLinkTarget)
        {
            //pHead could be either Active or Reserve
            //hhhh

            DLink pLinkedList = this.poHeadActive;

            while (pLinkedList != null)
            {
                // pass the comparison down to the derived class
                if (this.derivedCompare(pLinkedList, pLinkTarget))
                {
                    //found it
                    return pLinkedList;
                }
                pLinkedList = pLinkedList.pNext;
            }
            //could not find it
            return null;
        }


        protected void baseSetReserve(int initReserve, int growthRate)
        {
            this.growthRate = growthRate;

            //add more to the reserve list if found lacking resources
            int diff = initReserve - this.mNumReserveNodes;
            if (diff > 0)
            {
                this.privFillReservePool(diff);
            }
        }


        protected DLink baseGetActive()
        {
            return this.poHeadActive;
        }



        public void basePrint()
        {
            Debug.WriteLine("********** Manager Begins ********************");
            Debug.WriteLine("------------------------------------\n");
            Debug.WriteLine("           Growth Rate : {0}", this.growthRate);
            Debug.WriteLine("      # of Total Nodes : {0}", this.mNumTotalNodes);
            Debug.WriteLine("     # of Active Nodes : {0}", this.mNumActiveNodes);
            Debug.WriteLine("    # of Reserve Nodes : {0}", this.mNumReserveNodes);
            Debug.WriteLine("");

            // prints the head of each list, shows if its null too
            this.privPrintHeadPointers();

            //print each list
            if (this.poHeadActive != null)
            {
                this.privPrintList(this.poHeadActive, "Active");
            }

            if (this.poHeadReserve != null)
            {
                this.privPrintList(this.poHeadReserve, "Reserve");
            }

            Debug.WriteLine("********** Manager Ends ********************");

        }

        //----------------------------------------------------------------------
        // Helper Methods
        //----------------------------------------------------------------------

        private void privFillReservePool(int val)
        {
            Debug.Assert(val > 0);

            DLink current = this.poHeadReserve;
            for (int i = 0; i < val; i++)
            {
                DLink pLink = this.derivedCreateNode();
                Debug.Assert(pLink != null);
                DLink.AddToFront(ref this.poHeadReserve, pLink);
            }

            // update counters
            this.mNumReserveNodes += val;
            this.mNumTotalNodes += val;

        }

        private void privPrintHeadPointers()
        {
            if (this.poHeadActive == null)
            {
                Debug.WriteLine("      Active Head : null");
            }
            else
            {
                Debug.WriteLine("      Active Head : ({0})", this.poHeadActive.GetHashCode());
            }
            if (this.poHeadReserve == null)
            {
                Debug.WriteLine("     Reserve Head : null");
            }
            else
            {
                Debug.WriteLine("     Reserve Head : ({0})", this.poHeadReserve.GetHashCode());
            }
        }

        private void privPrintList(DLink pHead, String name)
        {
            Debug.WriteLine("   --- " + name + " ---\n");
            DLink pLink = pHead;

            int i = 0;
            while (pLink != null)
            {
                Debug.WriteLine("   {0} : ----------", i);
                this.derivedPrint(pLink);
                i++;
                pLink = pLink.pNext;
            }


        }

    }
}
