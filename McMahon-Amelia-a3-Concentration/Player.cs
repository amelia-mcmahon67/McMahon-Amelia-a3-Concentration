using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace McMahon_Amelia_a3_Concentration
{
    public class Player
    {
        public int health;
        public int points;
        public Player(int health, int points)
        {
            this.health = health;
            this.points = points;
        }

        public void Update()
        {
            drawPlayerStats();
            EndScreen();
        }
        public void drawPlayerStats()
        {
            Text.Draw(new string($"score:{this.points}"), new Vector2(50, 50));
            Text.Draw(new string($"health:{this.health}"), new Vector2(600, 50));
        }
        public void EndScreen()
        {
            if (health > 0 && points == 8)
            {
                Window.ClearBackground(new Color(0, 102, 51));
                Text.Size = 80;
                Text.Draw("You Win", new Vector2(255, 100));
            }
            if (health <= 0)
            {
                Window.ClearBackground(new Color(102, 0, 0));
                Text.Size = 80;
                Text.Draw("You Lose", new Vector2(255, 100));
            }
        }
    }
}