using System;
using System.Diagnostics;
//----------------------------------------------------------------------------------
//----------------------------------------------------------------------------------
//                    **************** NOTE ****************
//
//
// It seems very natural to me that I could use the STATE Pattern to switch between the
// players score.  The mechanics work the exact same but they are targeting different
// instances
//----------------------------------------------------------------------------------
namespace SpaceInvaders
{
    class Score
    {
        //----------------------------------------------------------------------------------
        // Static Data
        //----------------------------------------------------------------------------------
        private static int HighScore = 0;
        private static int GameScore = 0;
        private static int TrueGameScore = 0;

        private static int Player1Score = 0;
        private static int Player1TrueScore = 0;

        private static int Player2Score = 0;
        private static int Player2TrueScore = 0;

        public static int CurrentPlayer = 1;


        //----------------------------------------------------------------------------------
        // Score Methods
        //----------------------------------------------------------------------------------
        public static void ResetPlayerScores()
        {
            Player1Score = 0;
            Player1TrueScore = 0;
            Player2Score = 0;
            Player2TrueScore = 0;
        }


        public static Font GetCurrentPlayerScore()
        {
            int player = Score.CurrentPlayer;
            Font pScoreFont = null;
            switch (player)
            {
                case 1:
                    pScoreFont = FontManager.Find(Font.Name.Score1);
                    break;

                case 2:
                    pScoreFont = FontManager.Find(Font.Name.Score2);
                    break;

                default:
                    Debug.WriteLine("There is no default player.  Set it up correctly!!!");
                    Debug.Assert(false);
                    break;
            }

            Debug.Assert(pScoreFont != null);

            return pScoreFont;

        }

        public static void IncreaseScore(int points)
        {
            int player = Score.CurrentPlayer;
            switch (player)
            {
                case 1:
                    Score.Player1Score += points;
                    Score.Player1TrueScore += points;
                    break;

                case 2:
                    Score.Player2Score += points;
                    Score.Player2TrueScore += points;
                    break;

                default:
                    Debug.WriteLine("There is no default player.  Set it up correctly!!!");
                    Debug.Assert(false);
                    break;
            }

            Score.GameScore += points;
            Score.TrueGameScore += points;
        }

        public static void Refresh()
        {
            int player = Score.GetCurrentPlayer();
            Font pScore = Score.GetCurrentPlayerScore();
   
            Debug.Assert(pScore != null);

            if (player == 1)
            {
                Score.RefreshPlayer1(pScore);
            }

            else if (player == 2)
            {
                Score.RefreshPlayer2(pScore);
            }

        }

        private static void RefreshPlayer1(Font pScore)
        {
            if (Player1Score < 100)
            {
                pScore.UpdateMessage("00" + Player1Score.ToString());
            }
            else if (Player1Score < 1000)
            {
                pScore.UpdateMessage("0" + Player1Score.ToString());
            }
            else if (Player1Score < 10000)
            {
                pScore.UpdateMessage("" + Player1Score.ToString());
            }
            else
            {
                Player1Score = Player1Score - 10000;
                // try again
                Score.RefreshPlayer1(pScore);
            }
        }

        private static void RefreshPlayer2(Font pScore)
        {
            if (Player2Score < 100)
            {
                pScore.UpdateMessage("00" + Player2Score.ToString());
            }
            else if (Player2Score < 1000)
            {
                pScore.UpdateMessage("0" + Player2Score.ToString());
            }
            else if (Player2Score < 10000)
            {
                pScore.UpdateMessage("" + Player2Score.ToString());
            }
            else
            {
                Player2Score = Player2Score - 10000;
                // try again
                Score.RefreshPlayer2(pScore);
            }
        }


        public static void SaveHighScore(Font pHighScore)
        {
            int score = -1;
            if (Score.CurrentPlayer ==1)
            {
                score = Score.Player1Score;
            }
            if(Score.CurrentPlayer == 2) {
                score = Score.Player2Score;
            }
            Debug.Assert(score != -1);

            if(score > HighScore)
            {
               HighScore = score;
            }

            
            if (HighScore == 0)
            {
                pHighScore.UpdateMessage("000" + HighScore.ToString());
            }
            else if (HighScore < 100)
            {
                pHighScore.UpdateMessage("00" + HighScore.ToString());
            }
            else if (HighScore < 1000)
            {
                pHighScore.UpdateMessage("0" + HighScore.ToString());
            }
            else if (HighScore < 10000)
            {
                pHighScore.UpdateMessage("" + HighScore.ToString());
            }
            else
            {
                HighScore = HighScore - 10000;
                // try again
                Score.SaveHighScore(pHighScore);
            }
        }

        //----------------------------------------------------------------------------------
        // Player Methods
        //----------------------------------------------------------------------------------
        public void SwitchCurrentPlayer()
        {
            if(Score.CurrentPlayer == 1)
            {
                Score.CurrentPlayer = 2;
            }
            else
            {
                Score.CurrentPlayer = 1;
            }
        }

        public static int GetCurrentPlayer()
        {
            return Score.CurrentPlayer;
        }

        public static void SetCurrentPlayer(int p)
        {
            Debug.Assert(p > 0);
            Score.CurrentPlayer = p;

        }



    }
}
