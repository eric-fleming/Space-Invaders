using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundManager : Manager
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static SoundManager pInstance = null;
        private readonly Sound poNodeCompare;


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private SoundManager(int initReserve = 3, int growthRate = 1)
        : base(initReserve, growthRate)
        {
            // most of the work is carried out by base class

            this.poNodeCompare = new Sound();
        }


        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static void Create(int initReserve = 3, int growthRate = 1)
        {
            // pre-conditions
            Debug.Assert(initReserve > 0);
            Debug.Assert(growthRate > 0);

            // init
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                SoundManager.pInstance = new SoundManager(initReserve, growthRate);
            }

            //Include a NullObject Image
            Sound pSound = SoundManager.Add(Sound.Name.NullObject, null, 0.0f);
            Debug.Assert(pSound != null);

            //Include a Default Sound
            //Copy the Null



        }

        public static void Destroy()
        {
            // unimplemented
        }

        public static Sound Add(Sound.Name soundName, string fileName, float repeatTimeInterval = 1.0f)
        {
            SoundManager pImgManager = SoundManager.privGetInstance();
            Debug.Assert(pImgManager != null);

            // grab an blank imgage node
            Sound pNode = (Sound)pImgManager.baseAdd();
            Debug.Assert(pNode != null);


            //configure the image node
            pNode.Set(soundName,fileName, repeatTimeInterval);

            return pNode;

        }

        public static void Remove(Sound pNode)
        {
            SoundManager pMan = SoundManager.privGetInstance();

            Debug.Assert(pMan != null);
            Debug.Assert(pNode != null);

            pMan.baseRemove(pNode);
        }

        public static Sound Find(Sound.Name theName)
        {
            SoundManager pMan = SoundManager.privGetInstance();
            Debug.Assert(pMan != null);

            // set the static compare object for use
            pMan.poNodeCompare.SetName(theName);

            Sound pNode = (Sound)pMan.baseFind(pMan.poNodeCompare);
            return pNode;

        }

        public static void Print()
        {
            SoundManager pMan = SoundManager.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.basePrint();
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Sound();
            Debug.Assert(pNode != null);

            return pNode;
        }


        protected override bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            //This is called by baseFind

            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            //Cast to type
            Sound pDataA = (Sound)pLinkA;
            Sound pDataB = (Sound)pLinkB;

            // result of comparison, expression results a bool
            return (pDataA.GetName() == pDataB.GetName());
        }


        protected override void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Sound pNode = (Sound)pLink;
            pNode.Wash();
        }


        protected override void derivedPrint(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Sound pNode = (Sound)pLink;
            pNode.Print();
        }

        //----------------------------------------------------------------------------------
        // Private Singleton Methods
        //----------------------------------------------------------------------------------

        private static SoundManager privGetInstance()
        {
            Debug.Assert(pInstance != null);
            return SoundManager.pInstance;
        }
    }
}
