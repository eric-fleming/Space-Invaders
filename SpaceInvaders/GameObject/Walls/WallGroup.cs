using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallGroup : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public WallGroup(GameObject.Name gameName, GameSprite.Name spriteName, float px, float py) 
            : base(gameName, spriteName) 
        {
            this.x = px;
            this.y = py;
            this.poCollObj.pCollSprite.SetLineColor(1.0f, 1.0f, 1.0f);
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        //----------------------------------------------------------------------------------
        // Visitor - Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            // Important : at this point we are in alien or missile
            // Alien for left right wall
            // Missile for top bottom wall
            other.VisitWallGroup(this);
        }

        public override void VisitAlienGrid(AlienGrid ag)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(ag, pGameObj);
        }

        //public override void VisitAlien(AlienGO a)
        //{
        //    // Bomb vs WallRoot
        //    GameObject pGameObj = (GameObject)Iterator.GetChild(this);
        //    CollPair.Collide(a, pGameObj);
        //}

        public override void VisitMissileGroup(MissileGroup mg)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(mg);
            CollPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs WallGroup
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(m, pGameObj);
        }

        public override void VisitBombRoot(BombRoot br)
        {
            // BombRoot vs WallRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(br);
            CollPair.Collide(pGameObj, this);
        }
        public override void VisitBomb(Bomb b)
        {
            // Bomb vs WallRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(b, pGameObj);
        }
    }
}
