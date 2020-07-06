using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AnimationSprite : Command
    {

        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private readonly GameSprite pSprite;
        private DLink pCurrentImage;
        private DLink poFirstImage;

        private AlienGrid pAlienGrid;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public AnimationSprite(GameSprite.Name theName, AlienGrid ag)
        {
            this.pSprite = GameSpriteManager.Find(theName);
            Debug.Assert(this.pSprite != null);

            this.pCurrentImage = null;
            this.poFirstImage = null;

            this.pAlienGrid = ag;
        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        
        public GameSprite.Name GetName()
        {
            return this.pSprite.GetName();
        }
        
        public void Attach(Image.Name imageName)
        {
            Image pImg = ImageManager.Find(imageName);
            Debug.Assert(pImg != null);

            ImageHolder pImgHold = new ImageHolder(pImg);
            Debug.Assert(pImgHold != null);

            DLink.AddToEnd(ref this.poFirstImage, pImgHold);

            this.pCurrentImage = pImgHold;
        }

        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------


        public override void Execute(float deltaTime)
        {
            Debug.Assert(deltaTime > 0);

            ImageHolder pImgHold = (ImageHolder)this.pCurrentImage.pNext;

            // if you reached the end go back to the start
            if (pImgHold == null)
            {
                pImgHold = (ImageHolder)this.poFirstImage;
            }

            //set frame to next image
            this.pCurrentImage = pImgHold;

            //set the sprite to the same thing.
            this.pSprite.SwapImage(pImgHold.pImage);

            //Add this event to the Timer
            TimerManager.Add(TimeEvent.Name.SpriteAnimation, this, this.pAlienGrid.movementTimeInterval);


        }
    }
}
