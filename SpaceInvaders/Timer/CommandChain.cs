using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandChain : Command
    {
        DLink pHead;

        public CommandChain()
        {
            this.pHead = null;
        }

        public void Attach(Command cmd)
        {
            DLink.AddToEnd(ref this.pHead, cmd);
        }

        public override void Execute(float deltaTime)
        {
            DLink pcurrent = this.pHead;

            while (pcurrent != null)
            {
                ((Command)pcurrent).Execute(deltaTime);
                pcurrent = pcurrent.pNext;
            }
        }
    }
}
