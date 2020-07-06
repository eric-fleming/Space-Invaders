using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienColumn : Composite
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public AlienColumn(GameObject.Name gameObjName, GameSprite.Name gameSpriteName, float posX, float posY)
            : base(gameObjName,gameSpriteName)
        {
            this.x = posX;
            this.y = posY;
            // column outline color
            this.poCollObj.pCollSprite.SetLineColor(0.0f, 0.0f, 1.0f);
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods - For Collision / Visitor Pattern
        //----------------------------------------------------------------------------------
        public override void Accept(CollVisitor other)
        {
            //We are in the NullObject class
            //Call the the collsion reaction in the other GameObject/ CollVisitor
            other.VisitColumn(this);
        }


        public override void VisitMissileGroup(MissileGroup mg)
        {
            //Debug.WriteLine("         collide:  {0} <-> {1}", mg.GetName(), this.GetName());

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollPair.Collide(mg, pGameObj);
        }



    }
}
