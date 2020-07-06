using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NodeManager : Manager
    {
        private readonly Node poNodeComparePlaceHolder;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public NodeManager(int InitialNodesInReserve = 5, int deltaRate = 2)
            : base(InitialNodesInReserve, deltaRate)
        {
            //most of the work is done in the super class constructor
            this.poNodeComparePlaceHolder = new Node();
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void Add(Node.DataNames myName, int myVal)
        {
            // base call pushes the DLink to the head of active
            Node pNode = (Node)this.baseAdd();
            Debug.Assert(pNode != null);
            // now we set it with the info
            pNode.Set(myName,myVal);

        }

        public void Remove(Node pNode)
        {
            Debug.Assert(pNode != null);
            this.baseRemove(pNode);
        }

        public Node Find(Node.DataNames targetName)
        {
            this.poNodeComparePlaceHolder.name = targetName;
            Node pNode = (Node)this.baseFind(this.poNodeComparePlaceHolder);

            return pNode;
        }





        //----------------------------------------------------------------------
        // Overridden Methods from the Base Class Manager
        //----------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            // Should be filled with default values
            DLink pNode = new Node();
            return pNode;
        }

        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            Node pA = (Node)pLinkA;
            Node pB = (Node)pLinkB;

            // result of comparison, expression results a bool
            return (pA.name == pB.name) && (pA.x == pB.x);
        }

        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Node pNode = (Node)pLink;
            pNode.WashNode();
        }

        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Node pNode = (Node)pLink;
            pNode.Print();

        }
    }
}
