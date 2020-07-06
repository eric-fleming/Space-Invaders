using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Lives
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static int newGameLifeCount = 3;
        private static int count = newGameLifeCount;
        private static int credit = 0;

        //----------------------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------------------

        public static int GetLives()
        {
            return Lives.count;
        }

        public static void GainLife()
        {
            Lives.count++;
        }

        public static void LoseLife()
        {
            Lives.count--;
        }

        public static void AddCredit()
        {
            Lives.credit += 1;
            Debug.WriteLine("Credit = {0}", Lives.credit);
        }

        public static void SubtractCredit()
        {
            Lives.credit -= 1;
        }

        public static void ResetLives()
        {
            Lives.count = 3;
        }
        public static void Refresh()
        {
            // For updating the correct number of lives
            Font pLives = FontManager.Find(Font.Name.LifeCount);
            pLives.UpdateMessage(Lives.count.ToString());

            // For a new game
            if (Lives.count == 0 && Lives.credit > 0)
            {
                Lives.count = Lives.newGameLifeCount;
                SubtractCredit();
            }
        }



    }
}
