using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GlobalGameJam17
{
    class spriteScenePicker
    {
        //40-d0
        float prieviousDraw;
        float frameTimeGap;

        public int initialize(float framerate)
        {
            frameTimeGap = 1.0f / framerate;
            return 0;
        }
        public int drawFrame(GameTime gameTime, SpriteBatch spriteBatch, Texture2D spriteSheet, Rectangle destinationRectangle, Rectangle sourceRectangle)
        {            
            sourceRectangle = new Rectangle();
            if (gameTime.ElapsedGameTime.Milliseconds > prieviousDraw + frameTimeGap)
            {
                spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
                prieviousDraw = gameTime.ElapsedGameTime.Milliseconds;
            }
            
            return 0;
        }
        public Rectangle idleFrame(int size)
        {
            int step = 1;
            Point location = new Point(size * step, 0);
            Rectangle sourceRectangle = new Rectangle(location, new Point(size));
            return sourceRectangle;
        }
        public Rectangle handsInAirFrame(int size)
        {
            int step = 12;
            Point location = new Point(size*step, 0);
            Rectangle sourceRectangle = new Rectangle(location, new Point(size));
            return sourceRectangle;
        }
        public int suprisedFrame()
        {
            return 0;
        }
        
    }
}
