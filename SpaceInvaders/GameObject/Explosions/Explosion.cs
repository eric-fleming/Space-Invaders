using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Explosion : GameObject
    {
        
        
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Explosion(GameObject.Name gameName, GameSprite.Name spriteName, float x, float y)
            : base(gameName, spriteName)
        {
            // All work delegated to the GameObject Constructor
            // Creates a Null Collision Object
        }

        public Explosion() : base()
        {
            // constructs a blank game object
        }



        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public new void Clear()
        {
            // Does to DLink
            base.Clear();
        }
        
        public void Wash()
        {
            //Debug.WriteLine("Currently Explosions do not get washed");
        }

        public new void Print()
        {
            // Goes to GameObject
            base.Print();
        }

        //----------------------------------------------------------------------------------
        // Visitor Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            throw new NotImplementedException();
        }


        //----------------------------------------------------------------------------------
        // Component Methods
        //----------------------------------------------------------------------------------
        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }

        public override Component GetFirstChild()
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component c)
        {
            // Keenan(delete.E)
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poCollObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();


            // Now remove it
            base.Remove();
        }
    }
}
