using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollRect : Azul.Rect
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------------------

        public CollRect(float x, float y, float width, float height)
            : base(x, y, width, height)
        {

        }

        public CollRect(Azul.Rect pAzulRect) : base(pAzulRect)
        {

        }

        public CollRect(CollRect pRect) : base(pRect)
        {

        }

        public CollRect() : base()
        {

        }

        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------

        public static bool Intersect(CollRect pRectA, CollRect pRectB)
        {
            bool status = false;

            float A_minx = pRectA.x - pRectA.width / 2;
            float A_maxx = pRectA.x + pRectA.width / 2;
            float A_miny = pRectA.y - pRectA.height / 2;
            float A_maxy = pRectA.y + pRectA.height / 2;

            float B_minx = pRectB.x - pRectB.width / 2;
            float B_maxx = pRectB.x + pRectB.width / 2;
            float B_miny = pRectB.y - pRectB.height / 2;
            float B_maxy = pRectB.y + pRectB.height / 2;

            // Trivial reject
            if ((B_maxx < A_minx) || (B_minx > A_maxx) || (B_maxy < A_miny) || (B_miny > A_maxy))
            {
                status = false;
            }
            else
            {
                status = true;
            }


            return status;
        }

        public void Union(CollRect pRect)
        {
            // To construct the union rectangle
            float minX;
            float maxX;
            float minY;
            float maxY;

            if ((this.x - this.width / 2) < (pRect.x - pRect.width / 2))
            {
                minX = (this.x - this.width / 2);
            }
            else
            {
                minX = (pRect.x - pRect.width / 2);
            }

            if ((this.x + this.width / 2) > (pRect.x + pRect.width / 2))
            {
                maxX = (this.x + this.width / 2);
            }
            else
            {
                maxX = (pRect.x + pRect.width / 2);
            }

            if ((this.y + this.height / 2) > (pRect.y + pRect.height / 2))
            {
                maxY = (this.y + this.height / 2);
            }
            else
            {
                maxY = (pRect.y + pRect.height / 2);
            }

            if ((this.y - this.height / 2) < (pRect.y - pRect.height / 2))
            {
                minY = (this.y - this.height / 2);
            }
            else
            {
                minY = (pRect.y - pRect.height / 2);
            }

            //Create the union
            this.width = (maxX - minX);
            this.height = (maxY - minY);
            //center
            this.x = minX + this.width / 2;
            this.y = minY + this.height / 2; // origin is in the upper-right corner

        }
    }
}
