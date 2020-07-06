using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class GameObjectNode_Link : DLink
    {

    }

    public class GameObjectNode : GameObjectNode_Link
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public GameObject poGameObj;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public GameObjectNode() : base()
        {
            this.poGameObj = null;
        }

        ~GameObjectNode()
        {
            //What does this do??
        }

        //----------------------------------------------------------------------------------
        // Set Methods
        //----------------------------------------------------------------------------------
        public void Set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.poGameObj = pGameObject;
        }

        public void Wash()
        {
            this.poGameObj = null;
        }

        //----------------------------------------------------------------------------------
        // Get Methods
        //----------------------------------------------------------------------------------

        public Enum GetName()
        {
            return this.poGameObj.GetName();
        }

        public void Print()
        {
            Debug.Assert(this.poGameObj != null);
            Debug.WriteLine("\t\t      GameObject : ({0})",this.GetHashCode());

            this.poGameObj.Print();
        }
    }
}
