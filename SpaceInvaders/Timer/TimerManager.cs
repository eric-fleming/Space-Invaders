using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class TimerManager_MLink : Manager
    {
        public TimeEvent_Link poActive;
        public TimeEvent_Link poReserve;
    }
    class TimerManager : TimerManager_MLink
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static TimerManager pInstance = null;

        private TimeEvent poNodeCompare;
        protected float mCurrentTime;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private TimerManager(int initReserve = 5, int growthRate = 1) : base()
        {
            // delegate to base class; For the reserve DLink list
            this.baseInitialize(initReserve, growthRate);

            // initialize the derived fields
            this.poNodeCompare = new TimeEvent();
        }


        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static float GetCurrentTime()
        {
            TimerManager pTimerMan = TimerManager.privGetInstance();
            Debug.Assert(pTimerMan != null);

            return pTimerMan.mCurrentTime;
        }

        public static void Create(int initReserve = 5, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            Debug.Assert(TimerManager.pInstance == null);

            // create the one an only instance.
            if (TimerManager.pInstance == null)
            {
                TimerManager.pInstance = new TimerManager(initReserve, growthRate);
            }
        }
        public static TimeEvent Add(TimeEvent.Name timeName, Command pCmd, float timeToTrigger)
        {
            TimerManager pMan = TimerManager.privGetInstance();
            Debug.Assert(pMan != null);

            TimeEvent pNode = (TimeEvent)pMan.baseAdd();
            Debug.Assert(pNode != null);
            Debug.Assert(pCmd != null);
            Debug.Assert(timeToTrigger >= 0.0f);

            pNode.Set(timeName, pCmd, timeToTrigger);
            return pNode;

        }

        public static TimeEvent Find(TimeEvent.Name theName)
        {
            TimerManager pTimerMan = TimerManager.privGetInstance();
            Debug.Assert(pTimerMan != null);

            Debug.Assert(pTimerMan.poNodeCompare != null);
            pTimerMan.poNodeCompare.Wash();
            pTimerMan.poNodeCompare.SetName(theName);

            TimeEvent pTimeEvent = (TimeEvent)pTimerMan.baseFind(pTimerMan.poNodeCompare);
            return pTimeEvent;
        }

        public static void Remove(TimeEvent pLink)
        {
            TimerManager pTimerMan = TimerManager.privGetInstance();
            Debug.Assert(pTimerMan != null);

            Debug.Assert(pLink != null);
            pTimerMan.baseRemove(pLink);
        }

        public static void Print()
        {
            TimerManager pTimerMan = TimerManager.privGetInstance();
            Debug.Assert(pTimerMan != null);

            pTimerMan.basePrint();
        }

        public static void Update(float totalTime)
        {
            TimerManager pTimerMan = TimerManager.privGetInstance();
            Debug.Assert(pTimerMan != null);

            pTimerMan.mCurrentTime = totalTime;

            TimeEvent pTimeEvent = (TimeEvent)pTimerMan.baseGetActive();
            TimeEvent pNextEvent = null; // for iterating

            while (pTimeEvent != null)
            {
                //cache
                pNextEvent = (TimeEvent)pTimeEvent.pNext;

                if (pTimerMan.mCurrentTime >= pTimeEvent.GetTriggerTime())
                {
                    // do it
                    pTimeEvent.Process();

                    //remove it
                    pTimerMan.baseRemove(pTimeEvent);
                }

                // go to next
                pTimeEvent = pNextEvent;
            }

        }


        public static void PauseUpdate(float delta)
        {
            // Get the instance
            TimerManager pMan = TimerManager.privGetInstance();
            Debug.Assert(pMan != null);

            // walk the list
            TimeEvent pEvent = (TimeEvent)pMan.baseGetActive();

            while (pEvent != null)
            {
                pEvent.triggerTime += delta;
                // advance the pointer
                pEvent = (TimeEvent)pEvent.pNext;
            }
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        protected override DLink derivedCreateNode()
        {
            DLink pTE = new TimeEvent();
            Debug.Assert(pTE != null);

            return pTE;
        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {

            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            TimeEvent pTEA = (TimeEvent)pLinkA;
            TimeEvent pTEB = (TimeEvent)pLinkB;

            // result of comparison, expression results a bool
            // check pointer equality, if true, then the contents are the same
            return (pTEA == pTEB);
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TimeEvent pTE = (TimeEvent)pLink;
            pTE.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TimeEvent pTE = (TimeEvent)pLink;
            pTE.Print();
        }



        //----------------------------------------------------------------------------------
        // Private Methods
        //----------------------------------------------------------------------------------
        private static TimerManager privGetInstance()
        {
            // Forces you to check to make sure Create() was called earlier by the client.
            Debug.Assert(pInstance != null);
            return TimerManager.pInstance;
        }
    }
}
