using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class TimeEvent_Link : DLink
    {

    }
    class TimeEvent : TimeEvent_Link
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        
        private Name name;
        private Command pCommand;
        public float triggerTime;
        public float deltaTime;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Counter,
            CommandChain,

            BombSpawn,
            ExplodeAndRemove,
            ExplosionSprite,
            DropBomb,
            DropGrid,
            MissileSpawn,
            ShipExplosionEvent,

            MoveGrid,
            MoveGridOffWall,
            MoveUFO,
            SpawnUFO,
            HideUFO,
            SetWallStatus,
            SpriteAnimation,
            PlaySound,

            Sample,
            RepeatSample,
            Uninitialized
        }


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public TimeEvent() : base()
        {
            this.name = TimeEvent.Name.Uninitialized;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------


        public void Set(TimeEvent.Name eventName, Command pCmd, float deltaTimeToTrigger)
        {
            Debug.Assert(pCmd != null);

            this.name = eventName;
            this.pCommand = pCmd;
            this.deltaTime = deltaTimeToTrigger;

            // set the trigger time
            this.triggerTime = TimerManager.GetCurrentTime() + deltaTimeToTrigger;
        }

        public void SetName(TimeEvent.Name theName)
        {
            this.name = theName;
        }

        public void SetDeltaTime(float newDelta)
        {
            this.deltaTime = newDelta;
        }

        public TimeEvent.Name GetName()
        {
            return this.name;
        }

        public float GetTriggerTime()
        {
            return this.triggerTime;
        }

        public void Process()
        {
            // Is this used for Repeat Commands Only??
            Debug.Assert(this.pCommand != null);
            this.pCommand.Execute(this.deltaTime);
        }

        public new void Clear()
        {
            //different from the base class Clear() method
            this.name = TimeEvent.Name.Uninitialized;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;

        }

        public void Wash()
        {
            base.Clear();
            this.Clear();
        }

        public void Print()
        {
            //Object data
            Debug.WriteLine("Name : {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("     Command      : {0} ", this.pCommand);
            Debug.WriteLine("     Trigger Time : {0}", this.triggerTime);
            Debug.WriteLine("     Delta Time   : {0}", this.deltaTime);

            //DLink data
            TimeEvent temp;
            if (this.pNext == null)
            {
                Debug.WriteLine("next Dlink : null");
            }
            else
            {
                temp = (TimeEvent)this.pNext;
                Debug.WriteLine("next Dlink : ({0})", temp.name, temp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("prev Dlink : null");
            }
            else
            {
                temp = (TimeEvent)this.pPrev;
                Debug.WriteLine("prev Dlink : ({0})", temp.name, temp.GetHashCode());
            }

        }
    }
}
