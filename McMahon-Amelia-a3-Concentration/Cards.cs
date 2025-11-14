using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace McMahon_Amelia_a3_Concentration
{
    public class Cards
    {
        public Vector2 position;
        public Vector2 size;
        public Color colour;

        public Cards(Vector2 position, Vector2 size, Color colour)
        {
            this.position = position;
            this.size = size;
            this.colour = colour;
        }

        public void DrawCard(bool isFlipped)
        {
            if (isFlipped)
                Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, colour);
            else
                Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.Gray);
        }

        public bool ClickCheck()
        {
            Vector2 mouse = Raylib.GetMousePosition();
            return Raylib.IsMouseButtonPressed(0) &&
                   mouse.X >= position.X && mouse.X <= position.X + size.X &&
                   mouse.Y >= position.Y && mouse.Y <= position.Y + size.Y;
        }
    }
}
