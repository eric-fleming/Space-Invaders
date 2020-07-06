using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallBottom : WallCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public WallBottom(GameObject.Name gameName, GameSprite.Name spriteName, float px, float py, float width, float height)
            : base(gameName, spriteName, WallCategory.Type.Bottom)
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
            other.VisitWallBottom(this);
        }

        public override void VisitAlien(AlienGO a)
        {
            // Alien vs Wall-Bottom
            CollPair pColPair = CollPairManager.GetActiveCollPair();
            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb vs Wall-Bottom
            CollPair pColPair = CollPairManager.GetActiveCollPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();

        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Wall-Bottom
            //Does nothing, here to prevent crashing.

        }
    }
}
