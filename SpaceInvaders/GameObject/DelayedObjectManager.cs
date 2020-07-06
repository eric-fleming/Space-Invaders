using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DelayedObjectManager
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private CollObserver head;
        private static DelayedObjectManager pInstance = null;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private DelayedObjectManager()
        {
            this.head = null;
        }

        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static void Attach(CollObserver observer)
        {
            // protection
            Debug.Assert(observer != null);

            DelayedObjectManager pDelayMan = DelayedObjectManager.PrivGetInstance();

            // add to front
            if (pDelayMan.head == null)
            {
                pDelayMan.head = observer;
                observer.pNext = null;
                observer.pPrev = null;
            }
            else
            {
                observer.pNext = pDelayMan.head;
                observer.pPrev = null;
                pDelayMan.head.pPrev = observer;
                pDelayMan.head = observer;
            }
        }
        

        public static void Process()
        {
            DelayedObjectManager pDelayMan = DelayedObjectManager.PrivGetInstance();

            CollObserver pNode = pDelayMan.head;

            while (pNode != null)
            {
                // Fire off listener
                pNode.Execute();

                pNode = (CollObserver)pNode.pNext;
            }


            // remove
            pNode = pDelayMan.head;
            CollObserver pTmp = null;

            while (pNode != null)
            {
                pTmp = pNode;
                pNode = (CollObserver)pNode.pNext;

                // remove
                pDelayMan.PrivDetach(pTmp, ref pDelayMan.head);
            }
        }


        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private void PrivDetach(CollObserver node, ref CollObserver head)
        {
            // protection
            Debug.Assert(node != null);

            if (node.pPrev != null)
            {	// middle or last node
                node.pPrev.pNext = node.pNext;
            }
            else
            {  // first
                head = (CollObserver)node.pNext;
            }

            if (node.pNext != null)
            {	// middle node
                node.pNext.pPrev = node.pPrev;
            }
        }


        private static DelayedObjectManager PrivGetInstance()
        {
            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new DelayedObjectManager();
            }

            // Safety - this forces users to call create first
            Debug.Assert(pInstance != null);

            return pInstance;
        }
    }
}
