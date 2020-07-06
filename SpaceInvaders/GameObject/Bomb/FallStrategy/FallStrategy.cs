using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class FallStrategy
    {
        public abstract void Fall(Bomb pBomb);
        public abstract void Reset(float py);
    }
}
