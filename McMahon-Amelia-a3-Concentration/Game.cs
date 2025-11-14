// Include the namespaces (code libraries) you need below.
using McMahon_Amelia_a3_Concentration;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        bool titleScreen;
        bool gameGoing;
        bool rulesScreen;

        //min 30 tall
        Buttons[] titleScreenButtons =
        {
            new Buttons(new Vector2(350, 385), new Vector2(100, 30), "PLAY"),
            new Buttons(new Vector2(350, 425), new Vector2(100, 30), new string("RULES"))
        };
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            titleScreen = true;
            gameGoing = false;
            rulesScreen = false;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);
            if (titleScreen == true)
            {
                //drawing Title
                Text.Size = 70;
                Text.Draw(new string("Colours"), new Vector2(255, 100));
                Text.Draw(new string("Concentration"), new Vector2(150, 170));
                //button drawing
                for (int i = 0; i < titleScreenButtons.Length; i++)
                {
                    titleScreenButtons[i].Update();
                }
                //buttons being checked if theyre clicked
                if (titleScreenButtons[0].ClickCheck())
                {
                    gameGoing = true;
                    titleScreen = false;
                }
                if (titleScreenButtons[1].ClickCheck())
                {
                    rulesScreen = true;
                    titleScreen = false;
                }
            }
            else if (gameGoing == true)
            {

            }
            else if (rulesScreen == true)
            {

            }
        }
    }

}
