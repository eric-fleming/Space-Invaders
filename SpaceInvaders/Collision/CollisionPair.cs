using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class CollPair_Link : DLink
    {

    }

    public class CollPair : CollPair_Link
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public CollPair.Name name;
        public GameObject treeA;
        public GameObject treeB;
        public CollSubject poSubject;

        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Alien_Missle,
            Alien_Shield,
            Alien_Ship,
            Alien_SideWalls,
            Alien_BottomWall,

            Bomb_Missile,
            Bomb_Shield,
            Bomb_Ship,
            Bomb_WallBottom,

            Bumper_Ship,

            Missile_Saucer,
            Missile_Shield,
            Missile_UFO,
            Missile_WallTop,
            
            Saucer_Wall,

            Ship_Wall,

            NullObject,
            UnInitialized
        }

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public CollPair() : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = CollPair.Name.UnInitialized;

            this.poSubject = new CollSubject();
            Debug.Assert(this.poSubject != null);
        }

        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------
        public static void Collide(GameObject pTreeNodeA, GameObject pTreeNodeB)
        {
            // Cache A & B
            GameObject pNodeA = pTreeNodeA;
            GameObject pNodeB = pTreeNodeB;

            while (pNodeA != null)
            {
                // Start back at the top
                pNodeB = pTreeNodeB;

                while (pNodeB != null)
                {
                    //Debug.WriteLine("ColPair:    test:  {0}, {1}", pNodeA.GetName(), pNodeB.GetName());

                    // Get Rectangles
                    CollRect rectA = pNodeA.GetCollObj().poColRect;
                    CollRect rectB = pNodeB.GetCollObj().poColRect;

                    // Check
                    if (CollRect.Intersect(rectA, rectB))
                    {
                        // Success, liftoff!!
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)Iterator.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)Iterator.GetSibling(pNodeA);
            }
        }

        //----------------------------------------------------------------------------------
        // Set Methods
        //----------------------------------------------------------------------------------
        public void Set(CollPair.Name theName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootA != null);

            this.name = theName;
            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
        }

        public void SetName(CollPair.Name theName)
        {
            this.name = theName;
        }

        public void SetCollision(GameObject pGameObjA, GameObject pGameObjB)
        {
            Debug.Assert(pGameObjA!= null);
            Debug.Assert(pGameObjB != null);

            this.poSubject.pObjA = pGameObjA;
            this.poSubject.pObjB = pGameObjB;
        }



        //----------------------------------------------------------------------------------
        // Get Methods
        //----------------------------------------------------------------------------------
        public CollPair.Name GetName()
        {
            return this.name;
        }
        //----------------------------------------------------------------------------------
        // Other Methods
        //----------------------------------------------------------------------------------
        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }

        public void Attach(CollObserver pObserver)
        {
            // delegate
            this.poSubject.Attach(pObserver);
        }

        public void NotifyListeners()
        {
            this.poSubject.Notify();
        }

        public void Wash()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = CollPair.Name.UnInitialized;
        }

        public void Print()
        {
            // later
        }
    }
}
