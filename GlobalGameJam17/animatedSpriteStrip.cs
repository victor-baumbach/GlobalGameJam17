#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace GlobalGameJam17
{
    class animatedSpriteStrip
    {
        // The tiled image from which we animate
        private Texture2D myCellsTexture;

        // Duration of time to show each frame.
        private float myFrameTime;

        //  is it looping... probably!
        // Non looping ones are for "one-shot" events such as explosions etc
        private bool myIsLooping;

        // The amount of time in seconds that the current frame has been shown for.
        private float elapsedFrameTime;

        // The actual cell being addressed at this GameTime (0... numCells-1) 
        private int myFrameIndex;


        // counts from 0 to everupwards as the object lives on
        private int myFrameCounter;

        public animatedSpriteStrip(Texture2D texture, float frameTime, bool isLooping)
        {
            myCellsTexture = texture;
            myFrameTime = frameTime;
            myIsLooping = isLooping;
            elapsedFrameTime = 0.0f;
            myFrameIndex = 0;
            myFrameCounter = 0;
        }

        public int FrameCount()
        {
            return myCellsTexture.Width / myCellsTexture.Height;
        }

        // returns the centre of each cell
        private Vector2 Origin()
        {
            return new Vector2(myCellsTexture.Height / 2.0f, myCellsTexture.Height / 2.0f);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
        {


            // Process passing time. ElapsedGameTime returns the amount of time elapsed since the last Update
            elapsedFrameTime += (float)gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedFrameTime > myFrameTime)
            {
                // Advance the frame index; looping or clamping as appropriate.
                myFrameCounter++;

                if (myIsLooping)
                {
                    myFrameIndex = myFrameCounter % FrameCount();
                }
                else
                {
                    // freezes on the last frame
                    myFrameIndex = Math.Min(myFrameCounter, FrameCount() - 1);

                }

                elapsedFrameTime = 0.0f;
            }

            // Calculate the source rectangle of the current frame
            int cellWidth = myCellsTexture.Height;
            int leftMostPixel = myFrameIndex * cellWidth;
            Rectangle sourceRect = new Rectangle(leftMostPixel, 0, cellWidth, cellWidth);

            // Draw the current frame.
            // (bigTexture, posOnScreen, sourceRect in big texture, col, rotation, origin, scale, effect, depth)
            Vector2 orig = Origin();
            spriteBatch.Draw(myCellsTexture, position, sourceRect, Color.White, 0.0f, orig, 1.0f, spriteEffects, 0.5f);
        }


    }
}
