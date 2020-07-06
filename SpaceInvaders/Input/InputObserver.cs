using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class InputObserver : DLink
    {
        abstract public void Notify();

        public InputSubject pSubject;
    }
}
