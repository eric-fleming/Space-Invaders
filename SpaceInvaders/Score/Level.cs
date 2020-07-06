using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Level
    {
        //----------------------------------------------------------------------------------
        // Static Data
        //----------------------------------------------------------------------------------
        private static int currentLevel = 1;
        private static int numberOfAliens = 55;
        private static int aliensLeft = numberOfAliens;
        private static int ufosLeft = 1;

        private static AlienFactory AF = null;

        public static void createFactory()
        {
            AF = new AlienFactory(SpriteNodeBatch.Name.TheSwarm, SpriteNodeBatch.Name.Boxes);
        }



        //----------------------------------------------------------------------------------
        // Static Methods 
        //----------------------------------------------------------------------------------
        private static void SpeedUp()
        {
            AlienGrid pAlienGrid = (AlienGrid)GameObjectManager.Find(GameObject.Name.AlienGrid);
            pAlienGrid.movementTimeInterval -= 0.10f;
        }

        private static void LittleSpeedUp()
        {
            AlienGrid pAlienGrid = (AlienGrid)GameObjectManager.Find(GameObject.Name.AlienGrid);
            pAlienGrid.movementTimeInterval -= 0.02f;
        }


        public static void KilledAlien()
        {
            // update count
            Level.aliensLeft += -1;

            if (Level.aliensLeft % 10 == 5 && Level.aliensLeft != 5)
            {
                SpeedUp();
            }
            if (Level.aliensLeft < 11)
            {
                LittleSpeedUp();
            }

        }

        public static void KilledUFO()
        {
            // update count
            Level.ufosLeft += -1;
        }


        public static int GetCurrentLevel()
        {
            return Level.currentLevel;
        }

        public static void NextLevel()
        {
            Level.currentLevel += 1;
            Level.aliensLeft = numberOfAliens;
            AF.RepopulateGrid();



        }

        public static void Reset()
        {
            currentLevel = 1;
            aliensLeft = 55;
            ufosLeft = 1;
        }


        public static void Update()
        {
            // check if you should start a next Level
            if (Level.aliensLeft == 0)
            {
                NextLevel();
            }

            if(Level.ufosLeft == 0)
            {
                Level.ufosLeft = 1;
                AF.RepopulateUFO();
                Debug.WriteLine("Creating new UFO");
            }
        }



    }
}
