using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollObserver : DLink
    {
        // ---------------- Data ----------------
        public CollSubject pSubject;


        // ---------------- Abstract Methods ----------------
        public abstract void Notify();



        // ---------------- Virtual Methods ----------------
        
        public virtual void Execute()
        {
            // WHY not add a state pattern into our Observer!
            // default implementation
            
        }
    }
}
