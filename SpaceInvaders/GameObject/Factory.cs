using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Factory
    {

        
        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        protected Factory()
        {
            
        }

        //----------------------------------------------------------------------------------
        // Abstract Methdods - Caused issues with parameters in Create
        //----------------------------------------------------------------------------------

        //abstract public GameObject Create(GameObject.Name theName, Factory.Type type, float x, float y);
        public abstract GameObject Build(GameObject.Name theName, float x, float y);
        public virtual GameObject Create()
        {
            return null;
        }
    }
}
