using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageHolder : DLink
    {

        // Data
        public Image pImage;

        public ImageHolder(Image img) : base()
        {
            this.pImage = img;
        }
    }
}
