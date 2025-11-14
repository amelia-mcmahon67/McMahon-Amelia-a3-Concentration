using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace McMahon_Amelia_a3_Concentration
{
    public class Buttons
    {
        Vector2 size;
        Vector2 position;
        private string text;

        public Buttons(Vector2 position, Vector2 size, string text)
        {
            this.position = position;
            this.size = size;
            this.text = text;
        }
        public void Update()
        {
            drawButton();
        }
        public void drawButton()
        {
            Draw.FillColor = Color.Gray;
            Draw.Rectangle(position, size);
            Text.Size = 30;
            Text.Draw(text, position);
        }
        //checks if button is clicked
        public bool ClickCheck()
        {
            Vector2 mousePosition = Input.GetMousePosition();
            bool buttonPressed = false;
            if (mousePosition.X > position.X && mousePosition.X < position.X + size.X && mousePosition.Y > position.Y && mousePosition.Y < position.Y + size.Y && Input.IsMouseButtonPressed(0))
            {
                buttonPressed = true;
                return buttonPressed;
            }
            else
            {
                return false;
            }
        }
    }
}