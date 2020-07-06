using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public float delta;
        private FallStrategy pStrategy;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Bomb(GameObject.Name name, GameSprite.Name spriteName, FallStrategy strategy, float posX, float posY)
            : base(name, spriteName, BombCategory.Type.Bomb)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 1.5f;

            Debug.Assert(strategy != null);
            this.pStrategy = strategy;

            this.pStrategy.Reset(posY);
            this.poCollObj.pCollSprite.SetLineColor(1.0f, 1.0f, 0.0f);
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public void Reset()
        {
            this.y = 500.0f;
            this.pStrategy.Reset(this.y);
        }

        public float GetBoundingBoxHeight()
        {
            return this.poCollObj.poColRect.height;
        }

        public void MultiplyScale(float sx, float sy)
        {
            Debug.Assert(this.pProxySprite != null);

            this.pProxySprite.sx *= sx;
            this.pProxySprite.sy *= sy;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poCollObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (bomb root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

        public override void Update()
        {
            base.Update();
            this.y -= delta;

            // Delegate to FallStrategy
            this.pStrategy.Fall(this);
            
        }

        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitBomb(this);
        }

        
        
    }
}
