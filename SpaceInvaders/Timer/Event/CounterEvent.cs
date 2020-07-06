using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CounterEvent : Command
    {
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public static int count = 0;

        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public CounterEvent()
        {
            // Static variable for count
        }


        //----------------------------------------------------------------------------------
        // Abstract Methods
        //----------------------------------------------------------------------------------
        public override void Execute(float deltaTime)
        {
            //Debug.WriteLine("event: {0}", deltaTime);

            Debug.WriteLine("{0}", count);

            // Add itself back to timer
            //  TimerMan.Add(TimeEvent.Name.Counter, this, deltaTime);

            Font pFont = FontManager.Add(Font.Name.TestMessage,
                SpriteNodeBatch.Name.Texts,
                "c " + count,
                Glyph.Name.Consolas36pt,
                20 + 100 * (count / 10),
                700 - count * 40 + (count / 10) * 400);

            pFont.SetColor(0.10f, 0.10f, 0.10f);
            count++;

        }

        
    }
}
