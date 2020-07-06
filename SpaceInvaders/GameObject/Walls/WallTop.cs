using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallTop : WallCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public WallTop(GameObject.Name gameName, GameSprite.Name spriteName, float px, float py, float width, float height)
            : base(gameName, spriteName, WallCategory.Type.Top)
        {
            this.x = px;
            this.y = py;
            this.poCollObj.pCollSprite.SetLineColor(0.0f, 1.0f, 1.0f);
            this.poCollObj.poColRect.Set(px, py, width, height);
        }


        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public override void Update()
        {
            base.Update();
        }

        //----------------------------------------------------------------------------------
        // Visitor - Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            //Important : At this point we have an Alien / AlienCategory
            other.VisitWallTop(this);
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb vs Wall-Top
            //Does nothing, here to prevent crashing.
        }

        public override void VisitMissileGroup(MissileGroup mg)
        {
            // MissileGroup vs Wall-Top
            GameObject pGameObj = (GameObject)Iterator.GetChild(mg);
            CollPair.Collide(pGameObj, this);

        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Wall-Top
            CollPair pCollPair = CollPairManager.GetActiveCollPair();
            Debug.Assert(pCollPair != null);

            // Register collisiton and notify the observers
            pCollPair.SetCollision(m, this);
            pCollPair.NotifyListeners();

            // Who delete the bombs??
        }

    }
}
