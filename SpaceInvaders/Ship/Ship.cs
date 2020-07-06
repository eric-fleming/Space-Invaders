using System;
using System.Diagnostics;


namespace SpaceInvaders
{

    public class Ship : ShipCategory
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public static IrrKlang.ISoundEngine soundEngine = new IrrKlang.ISoundEngine();
        public static IrrKlang.ISoundSource shootSound = soundEngine.AddSoundSourceFromFile("shoot.wav");

        public float shipSpeed;
        private ShipState state;
        private ShipState pMoveState;
        private ShipState pShootState;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Ship(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, ShipCategory.Type.Ship)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 3.0f;
            this.state = null;

            this.pMoveState = ShipMan.GetState(ShipMan.State.MoveLeftRight);
            this.pShootState = null;
        }

        //----------------------------------------------------------------------------------
        // State Methods
        //----------------------------------------------------------------------------------

        public void Handle()
        {
            this.state.Handle(this);
        }

        public void SetState(ShipMan.State inState)
        {
            this.state = ShipMan.GetState(inState);
        }

        public void SetMoveState(ShipMan.State inState)
        {
            this.pMoveState = ShipMan.GetState(inState);
        }

        public void SetShootState(ShipMan.State inState)
        {
            this.pShootState = ShipMan.GetState(inState);
        }

        public ShipState GetState()
        {
            return this.state;
        }

        public ShipState GetMoveState()
        {
            return this.pMoveState;
        }

        public ShipState GetShootState()
        {
            return this.pShootState;
        }

        public override void Update()
        {
            base.Update();
            // All move handles set back to LR move State
            //Debug.WriteLine("------");
            this.pMoveState = ShipMan.GetState(ShipMan.State.MoveLeftRight);
        }

        //----------------------------------------------------------------------------------
        // Visitor Methods
        //----------------------------------------------------------------------------------

        public override void Accept(CollVisitor other)
        {
            // Important: at this point we have an Bomb
            // Call the appropriate collision reaction
            other.VisitShip(this);
        }


        public override void VisitBomb(Bomb b)
        {
            // Bomb vs Ship
            Debug.WriteLine(" ---> Bomb Hit Ship");
            CollPair pColPair = CollPairManager.GetActiveCollPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBumperLeft(BumperLeft b)
        {
            // Bumper-Left vs ShieldBrick
            //Debug.WriteLine(" ---> Hit bumper Left!");
            CollPair pCollPair = CollPairManager.GetActiveCollPair();
            pCollPair.SetCollision(b, this);
            pCollPair.NotifyListeners();
        }

        public override void VisitBumperRight(BumperRight b)
        {
            // Bumper-Left vs ShieldBrick
            //Debug.WriteLine(" ---> Hit bumper Right!");
            CollPair pCollPair = CollPairManager.GetActiveCollPair();
            pCollPair.SetCollision(b, this);
            pCollPair.NotifyListeners();
        }

        //----------------------------------------------------------------------------------
        // Movement Methods
        //----------------------------------------------------------------------------------

        public void MoveRight()
        {
            this.pMoveState.MoveRight(this);
        }


        public void MoveLeft()
        {
            this.pMoveState.MoveLeft(this);
        }

        //----------------------------------------------------------------------------------
        // Shoot
        //----------------------------------------------------------------------------------
        public void ShootMissile()
        {
            this.state.ShootMissile(this);
        }


        
    }
}
