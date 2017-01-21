﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GlobalGameJam17
{
    class cButton
    {
        Texture2D texture;
        Texture2D  hoveredTexture;
        Texture2D initialTexture;
        Vector2 position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;

        public cButton(Texture2D firstTexture, Texture2D endTexture, GraphicsDevice graphics)
        {
            initialTexture = firstTexture;
            hoveredTexture = endTexture;
            //ScreenW = 800, ScreenH = 600
            //ImgW = 100, ImgH = 20
            size = new Vector2(graphics.Viewport.Width / 8, graphics.Viewport.Height / 30);
        }

        bool down;
        public bool isClicked;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mouse"></param>
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y,
                (int)size.X, (int)size.Y);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y,  1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                //    if (colour.A == 255) down = false;
                //    if (colour.A == 0) down = true;
                //    if (down) colour.A += 3; else colour.A -= 3;
                texture = hoveredTexture;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }
            else
            {
                texture = initialTexture;
            }

            //else if (colour.A < 255)
            //{
            //    colour.A += 3;
            //    isClicked = false;
            //}
        }
        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
