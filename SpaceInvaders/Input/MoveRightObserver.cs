﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveRightObserver : InputObserver
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private int debouceCount;
        private int debounceLimit;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public MoveRightObserver()
        {
            this.debouceCount = 0;
            this.debounceLimit = 8;
        }

        public override void Notify()
        {
            this.debouceCount++;
            //debounceLimit is a static var in InputObserver.cs
            if (this.debouceCount % debounceLimit == 1)
            {
                //Debug.WriteLine("Moving Right");
            }
            Ship pShip = ShipMan.GetShip();
            pShip.MoveRight();
        }
    }
}
