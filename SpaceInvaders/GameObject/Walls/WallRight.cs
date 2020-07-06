using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallRight : WallCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public WallRight(GameObject.Name gameName, GameSprite.Name spriteName, float px, float py, float width, float height)
            : base(gameName, spriteName, WallCategory.Type.Right)
        {
            this.x = px;
            this.y = py;
            this.poCollObj.pCollSprite.SetLineColor(0.0f, 0.7f, 1.0f);
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
            other.VisitWallRight(this);
        }

        public override void VisitAlienGrid(AlienGrid ag)
        {
            // AlienGrid vs Wall-Right
            //Debug.WriteLine("\ncollide: {0} with {1}", this, ag);
            //Debug.WriteLine("               --->DONE<----");

            // Set a new direction : Positive means go right -->
            ag.SetDelta(-1.0f);
            ag.SetIsOnWall(true);

            CollPair pCollPair = CollPairManager.GetActiveCollPair();
            Debug.Assert(pCollPair != null);

            // Register collisiton and notify the observers
            pCollPair.SetCollision(ag, this);
            pCollPair.NotifyListeners();
        }

        public override void VisitBomb(Bomb b)
        {
            // does nothing
            //its okay
        }

        public override void VisitMissile(Missile m)
        {
            // does nothing
            //its okay
        }
    }
}
