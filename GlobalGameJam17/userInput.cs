using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GlobalGameJam17
{
    class userInput
    {
        static KeyboardState pressing;
        MouseState mousey;
        //put code here! ;)
        public Point mouseClick()
        {
            //to-do
            Point mousePossition = new Point(-100);
            mousey = Mouse.GetState();
            if (mousey.LeftButton == ButtonState.Pressed && mousey.LeftButton == ButtonState.Released)
            {
                //
                mousePossition.X = mousey.X;
                mousePossition.Y = mousey.Y;
            }
            return mousePossition;
        }
        static int updateInput()
        {
            //to-do
            pressing = Keyboard.GetState();
            return 0;
        }
        public static char getKeyPress()
        {
            //to-do
            updateInput();
            if (pressing.IsKeyDown(Keys.A))
            {
                return 'A';
            }
            else if (pressing.IsKeyDown(Keys.B))
            {
                return 'B';
            }
            else if (pressing.IsKeyDown(Keys.C))
            {
                return 'C';
            }
            else if (pressing.IsKeyDown(Keys.D))
            {
                return 'D';
            }
            else if (pressing.IsKeyDown(Keys.E))
            {
                return 'E';
            }
            else if (pressing.IsKeyDown(Keys.F))
            {
                return 'F';
            }
            else if (pressing.IsKeyDown(Keys.G))
            {
                return 'G';
            }
            else if (pressing.IsKeyDown(Keys.H))
            {
                return 'H';
            }
            else if (pressing.IsKeyDown(Keys.I))
            {
                return 'I';
            }
            else if (pressing.IsKeyDown(Keys.J))
            {
                return 'J';
            }
            else if (pressing.IsKeyDown(Keys.K))
            {
                return 'K';
            }
            else if (pressing.IsKeyDown(Keys.L))
            {
                return 'L';
            }
            else if (pressing.IsKeyDown(Keys.M))
            {
                return 'M';
            }
            else if (pressing.IsKeyDown(Keys.N))
            {
                return 'N';
            }
            else if (pressing.IsKeyDown(Keys.O))
            {
                return 'O';
            }
            else if (pressing.IsKeyDown(Keys.P))
            {
                return 'P';
            }
            else if (pressing.IsKeyDown(Keys.Q))
            {
                return 'Q';
            }
            else if (pressing.IsKeyDown(Keys.R))
            {
                return 'R';
            }
            else if (pressing.IsKeyDown(Keys.S))
            {
                return 'S';
            }
            else if (pressing.IsKeyDown(Keys.T))
            {
                return 'T';
            }
            else if (pressing.IsKeyDown(Keys.U))
            {
                return 'U';
            }
            else if (pressing.IsKeyDown(Keys.V))
            {
                return 'V';
            }
            else if (pressing.IsKeyDown(Keys.W))
            {
                return 'W';
            }
            else if (pressing.IsKeyDown(Keys.X))
            {
                return 'X';
            }
            else if (pressing.IsKeyDown(Keys.Y))
            {
                return 'Y';
            }
            else if (pressing.IsKeyDown(Keys.Z))
            {
                return 'Z';
            }
            else
            {
                return ' ';
            }
            
        }

    }
}
