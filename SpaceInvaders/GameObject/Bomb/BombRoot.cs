﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombRoot : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public BombRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollObj.pCollSprite.SetLineColor(1.0f, 1.0f, 0.0f);
        }

        ~BombRoot()
        {
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitBombRoot(this);
        }


        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
