// Include the namespaces (code libraries) you need below.
using McMahon_Amelia_a3_Concentration;
using MohawkGame2D;
using System;
using System.Linq;
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

        public Cards?[] shownCards = new Cards?[2];
        public Cards?[] solvedCards = new Cards?[16];


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
public class Game
{
    bool titleScreen;
    bool rulesScreen;
    bool gameGoing;

    Buttons[] titleScreenButtons =
    {
            new Buttons(new Vector2(350, 385), new Vector2(100, 30), "play"),
            new Buttons(new Vector2(350, 425), new Vector2(100, 30), "rules")
        };
    Buttons rulesButton = new Buttons(new Vector2(10, 10), new Vector2(100, 30), "Back");

    Cards[] gameCards =
    {
            // Row 1
            new Cards(new Vector2(10, 100), new Vector2(80, 120), Color.Red),
            new Cards(new Vector2(100, 100), new Vector2(80, 120), Color.Green),
            new Cards(new Vector2(190, 100), new Vector2(80, 120), Color.Blue),
            new Cards(new Vector2(280, 100), new Vector2(80, 120), Color.Yellow),
            new Cards(new Vector2(370, 100), new Vector2(80, 120), new Color(127, 0, 255)), // Purple
            new Cards(new Vector2(460, 100), new Vector2(80, 120), Color.Cyan),
            new Cards(new Vector2(550, 100), new Vector2(80, 120), new Color(255, 128, 0)), // Orange
            new Cards(new Vector2(640, 100), new Vector2(80, 120), Color.Magenta),

            // Row 2
            new Cards(new Vector2(10, 230), new Vector2(80, 120), Color.Yellow),
            new Cards(new Vector2(100, 230), new Vector2(80, 120), Color.Red),
            new Cards(new Vector2(190, 230), new Vector2(80, 120), new Color(127, 0, 255)), // Purple
            new Cards(new Vector2(280, 230), new Vector2(80, 120), Color.Green),
            new Cards(new Vector2(370, 230), new Vector2(80, 120), new Color(255, 128, 0)), // Orange
            new Cards(new Vector2(460, 230), new Vector2(80, 120), Color.Magenta),
            new Cards(new Vector2(550, 230), new Vector2(80, 120), Color.Cyan),
            new Cards(new Vector2(640, 230), new Vector2(80, 120), Color.Blue)
        };
    public Cards[] shownCards = new Cards[2];
    public Cards[] solvedCards = new Cards[16];

    Player mainPlayer = new Player(10, 0);
    public void Setup()
    {
        Window.SetSize(800, 600);
        titleScreen = true;
        gameGoing = false;
        rulesScreen = false;
    }

    public void Update()
    {
        Window.ClearBackground(Color.White);

        if (titleScreen)
        {
            // Title screen
            Text.Size = 70;
            Text.Draw("Colours", new Vector2(255, 100));
            Text.Draw("Concentration", new Vector2(150, 170));

            for (int i = 0; i < titleScreenButtons.Length; i++)
                titleScreenButtons[i].Update();

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
        else if (rulesScreen)
        {
            rulesButton.Update();
            if (rulesButton.ClickCheck())
            {
                titleScreen = true;
                rulesScreen = false;
            }

            Text.Size = 30;
            Text.Draw(new string("This is a game of Concentration with colours"), new Vector2(10, 140));
            Text.Draw(new string("instead of cards, To 'flip' a card you have"), new Vector2(10, 180));
            Text.Draw(new string("to click it but be careful you only have 10"), new Vector2(10, 220));
            Text.Draw(new string("lives, Try to collect all the card pairs"), new Vector2(10, 260));
            Text.Draw(new string("before losing all your health, good luck!"), new Vector2(10, 300));
            Text.Draw(new string("if your cards arn't a pair press space"), new Vector2(10, 340));
        }
        else if (gameGoing)
        {


            // Draw and handle cards
            for (int i = 0; i < gameCards.Length; i++)
            {
                // Check if card is flipped or solved
                bool isFlipped = false;
                if (shownCards[0] == gameCards[i] || shownCards[1] == gameCards[i] || solvedCards.Contains(gameCards[i]))
                {
                    isFlipped = true;
                }

                gameCards[i].DrawCard(isFlipped);

                // Handle click
                if (gameCards[i].ClickCheck())
                {
                    for (int j = 0; j < shownCards.Length; j++)
                    {
                        if (shownCards[j] == null)
                        {
                            shownCards[j] = gameCards[i];
                            break;
                        }
                    }
                }
            }

            // Check match if two cards are shown
            if (shownCards[0] != null && shownCards[1] != null)
            {
                if (shownCards[0].colour.Equals(shownCards[1].colour))
                {
                    // Move cards to solvedCards
                    for (int s = 0; s < solvedCards.Length; s++)
                    {
                        if (solvedCards[s] == null)
                        {
                            solvedCards[s] = shownCards[0];
                            break;
                        }
                    }
                    for (int s = 0; s < solvedCards.Length; s++)
                    {
                        if (solvedCards[s] == null)
                        {
                            solvedCards[s] = shownCards[1];
                            break;
                        }
                    }
                    shownCards[0] = null!;
                    shownCards[1] = null!;
                    mainPlayer.points++;
                }
                else if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                    mainPlayer.health--;
                    // flip back mismatched cards
                    shownCards[0] = null!;
                    shownCards[1] = null!;


                }
            }
            mainPlayer.Update();
        }
    }
}
