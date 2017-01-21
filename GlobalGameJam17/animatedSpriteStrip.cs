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
        // Image to be animated
        private Texture2D myCellsTexture;

        //Duration of time to show each Frame
        private float myFrameTime;

        // Is the animation recurring
        private bool myIsLooping;

        // The amount of time in seconds that the current frame has been shown for
        private float elapsedFrameTime;

        // The actual cell being addressed at this GameTime (0... numCells-1) 
        private int myFrameIndex;

        // counts from 0 to everupwards as the object lives on
        private int myFrameCounter;

        public int XPos;
        public int YPos;
        private SpriteEffects mySpriteEffects;
        private float myDrawingDepth;

        public string myName;

        public animatedSpriteStrip(Texture2D texture, float frameTime, bool isLooping)
        {
            myCellsTexture = texture;
            myFrameTime = frameTime;
            myIsLooping = isLooping;
            elapsedFrameTime = 0.0f;
            myFrameIndex = 0;
            myFrameCounter = 0;
            XPos = 0;
            YPos = 0;
            mySpriteEffects = SpriteEffects.None;
            myDrawingDepth = 0.5f;
        }

        public void setName(string actionName)
        {
            myName = actionName;
        }

        public int FrameCount()
        {
            return myCellsTexture.Width / myCellsTexture.Height;
        }

        private Vector2 Origin()
        {
            return new Vector2(myCellsTexture.Height / 2.0f, myCellsTexture.Height / 2.0f);
        }


        public void setSpriteEffect(SpriteEffects se)
        {
            mySpriteEffects = se;
        }


        public void setDrawingDepth(float z)
        {
            myDrawingDepth = z;
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            // Process passing time. ElapsedGameTime returns the amount of time elapsed since the last Update
            elapsedFrameTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
            Vector2 myPosition;
            myPosition.X = (float)XPos;
            myPosition.Y = (float)YPos;
            spriteBatch.Draw(myCellsTexture, myPosition, sourceRect, Color.White, 0.0f, orig, 1.0f, mySpriteEffects, myDrawingDepth);
        }



    }
}
