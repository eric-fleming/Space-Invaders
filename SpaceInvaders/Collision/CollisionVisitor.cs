using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollVisitor : DLink
    {
        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public abstract void Accept(CollVisitor other);

        //----------------------------------------------------------------------------------
        // Visit Shilds
        //----------------------------------------------------------------------------------

        public virtual void VisitShieldGrid(ShieldGrid sg)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Shield Grid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldRoot(ShieldRoot sr)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Shield root not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldColumn(ShieldColumn sc)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Shield Column not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldBrick(ShieldBrick sb)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Shield brick not implemented");
            Debug.Assert(false);
        }

        //----------------------------------------------------------------------------------
        // Visit Walls
        //----------------------------------------------------------------------------------
        public virtual void VisitWallLeft(WallLeft w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Wall-Left not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallRight(WallRight w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Wall-Right not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallTop(WallTop w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Wall-Top not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallBottom(WallBottom w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Wall-Bottom not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallGroup(WallGroup wg)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }

        //----------------------------------------------------------------------------------
        // Visit Bumpers
        //----------------------------------------------------------------------------------
        public virtual void VisitBumperLeft(BumperLeft b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bumper-Left not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBumperRight(BumperRight b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bumper-Right not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBumperGroup(BumperGroup bg)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bumper-Group not implemented");
            Debug.Assert(false);
        }
        //----------------------------------------------------------------------------------
        // Visit Ship
        //----------------------------------------------------------------------------------
        public virtual void VisitShip(Ship s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Ship not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShipRoot(ShipRoot sr)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Ship-Root not implemented");
            Debug.Assert(false);
        }

        //----------------------------------------------------------------------------------
        // Visit Missile
        //----------------------------------------------------------------------------------
        public virtual void VisitMissileGroup(MissileGroup mg)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissile(Missile m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        //----------------------------------------------------------------------------------
        // Visit Bomb
        //----------------------------------------------------------------------------------
        public virtual void VisitBomb(Bomb b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBombRoot(BombRoot b)
        {
            Debug.WriteLine("Visit by BombRoot not implemented");
            Debug.Assert(false);
        }



        //----------------------------------------------------------------------------------
        // Visit Aliens
        //----------------------------------------------------------------------------------

        public virtual void VisitAlienGrid(AlienGrid ag)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienGrid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitColumn(AlienColumn ac)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlien(AlienGO a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Alien Game Object not implemented");
            Debug.Assert(false);
        }


        //----------------------------------------------------------------------------------
        // Visit Null GameObject
        //----------------------------------------------------------------------------------
        public virtual void VisitNullGameObject(NullGameObject n)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Null Game Object not implemented");
            Debug.Assert(false);
        }
    }
}
