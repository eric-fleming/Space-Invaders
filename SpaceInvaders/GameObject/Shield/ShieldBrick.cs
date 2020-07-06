using System;
using System.Diagnostics;

namespace SpaceInvaders
{ 
    
    public class ShieldBrick : ShieldCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public ShieldBrick(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldBrick(this);
        }

        public override void VisitAlien(AlienGO a)
        {
            // Alien vs Shield-Brick
            Debug.WriteLine(" ---> GAAAAAHHHHHHHHH!!!!!!!!");
            CollPair pColPair = CollPairManager.GetActiveCollPair();
            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb vs ShieldBrick
            //Debug.WriteLine(" ---> Boom");
            CollPair pColPair = CollPairManager.GetActiveCollPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldBrick
            //Debug.WriteLine(" ---> Shild Brick Destroyed!");
            CollPair pCollPair = CollPairManager.GetActiveCollPair();
            pCollPair.SetCollision(m, this);
            pCollPair.NotifyListeners();
        }

        public override void Update()
        {
            base.Update();
        }

    }
}
