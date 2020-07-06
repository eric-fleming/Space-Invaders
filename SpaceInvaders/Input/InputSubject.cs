﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputSubject
    {
        // Data ------------------------
        private InputObserver head;

        // Constructor ------------------------
        public InputSubject()
        {
            this.head = null;
        }



        // Methods ------------------------
        public void Attach(InputObserver observer)
        {
            // protection
            Debug.Assert(observer != null);

            observer.pSubject = this;

            // add to front
            if (head == null)
            {
                head = observer;
                observer.pNext = null;
                observer.pPrev = null;
            }
            else
            {
                observer.pNext = head;
                observer.pPrev = null;
                head.pPrev = observer;
                head = observer;
            }
        }

        public void Detach()
        {

        }

        public void Notify()
        {
            InputObserver pNode = this.head;

            while (pNode != null)
            {
                // Fire off listener
                pNode.Notify();

                pNode = (InputObserver)pNode.pNext;
            }
        }
    }
}
