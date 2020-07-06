using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public DLink poHead;
        public DLink poTail;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------

        //public Composite()
        //{
        //    this.poHead = null;
        //    this.holder = Container.COMPOSITE;
        //}

        public Composite(GameObject.Name gameObjName, GameSprite.Name gameSpriteName)
            : base(gameObjName, gameSpriteName)
        {
            this.poHead = null;
            this.poTail = null;
            this.holder = Container.COMPOSITE;

        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Add(Component pComp)
        {
            Debug.Assert(pComp != null);
            DLink.AddToEnd(ref this.poHead, ref this.poTail, pComp);
            pComp.pParent = this;
        }


        public override void Remove(Component pComp)
        {
            Debug.Assert(pComp != null);
            DLink.RemoveNode(ref this.poHead, ref this.poTail, pComp);
        }


        public override Component GetFirstChild()
        {
            DLink pLink = this.poHead;
            //okay to return null, just means it has no children.

            return (Component)pLink;
        }

        public int CountChildren()
        {
            int sum = 0;
            Component pNode = this.GetFirstChild();

            while (pNode != null)
            {
                sum++;
                pNode = (Component)pNode.pNext;
            }

            return sum;
        }

        public Component GetNthChild(int nth)
        {
            int childrenTotal = this.CountChildren();
            Debug.Assert(nth-1 <= childrenTotal);

            if (nth == 0 || childrenTotal == 0)
            {
                return null;
            }

            DLink pNode = this.poHead;
            int i = 1;
            
            while (i < nth)
            {
                pNode = pNode.pNext;
                i++;
            }

            return (Component)pNode;
        }

        public override void Print()
        {
            this.PrintMyself();
            this.PrintMyChildren();
            
           
        }

        private void PrintMyself()
        {
            if (Iterator.GetParent(this) != null)
            {
                Debug.WriteLine("GameObject : ({0}) | Parent : ({1}) <---- Composite", this.GetHashCode(), Iterator.GetParent(this).GetHashCode());
            }
            else
            {
                Debug.WriteLine("GameObject : ({0}) | Parent : null <---- Composite : root", this.GetHashCode());
            }
        }

        private void PrintMyChildren()
        {
            DLink pNode = this.poHead;
            while (pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.Print();

                pNode = pNode.pNext;
            }
            Debug.WriteLine("<---- Done with composite");
        }

        
    }
}
