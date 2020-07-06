using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollSubject
    {
        // ---------------- Data ----------------
        private CollObserver pHead;
        public GameObject pObjA;
        public GameObject pObjB;


        // ---------------- Constructor ----------------
        public CollSubject()
        {
            this.pHead = null;
            this.pObjA = null;
            this.pObjB = null;
        }


        // ---------------- Methods ----------------
        
        public void Attach(CollObserver pObserver)
        {
            Debug.Assert(pObserver != null);

            pObserver.pSubject = this;

            //add to the front
            if (this.pHead == null)
            {
                pHead = pObserver;
                pObserver.pPrev = null;
                pObserver.pNext = null;
            }
            else
            {
                pObserver.pNext = this.pHead;
                this.pHead.pPrev = pObserver;
                this.pHead = pObserver;
            }
        }

        public void Detach(CollObserver pObserver)
        {

        }

        public void Notify()
        {
            CollObserver pNode = this.pHead;

            while (pNode != null)
            {
                // Fire off listener
                pNode.Notify();

                pNode = (CollObserver)pNode.pNext;
            }
        }
    }
}
