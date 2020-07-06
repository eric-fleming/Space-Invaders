using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    public class NullGameObject : Leaf
    {
        public NullGameObject()
            : base(GameObject.Name.Null_GameObject, GameSprite.Name.NullObject)
        {

        }

        ~NullGameObject()
        {
            //What do these do??
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            //We are in the NullObject class
            //Call the the collsion reaction in the other GameObject/ CollVisitor
            other.VisitNullGameObject(this);
        }

        public override void Update()
        {
            //do nothing :)
        }


    }
}
