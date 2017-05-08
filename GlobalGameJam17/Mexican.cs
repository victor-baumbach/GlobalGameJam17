using GlobalGameJam17;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Mexican
    {
    // The static image that is not animated 

    Texture2D staticSprite;

    // The tiled image from which we animate

    Texture2D animatedSprite;

    // Area for drawing

    Rectangle bounds;

    // Duration of time to show each frame.
    private float myFrameTime;

    //  is it looping... probably!
    // Non looping ones are for "one-shot" events such as explosions etc
    private bool myIsLooping = false;

    // The amount of time in seconds that the current frame has been shown for.
    private float elapsedFrameTime;

    // The actual cell being addressed at this GameTime (0... numCells-1) 
    private int myFrameIndex;


    // counts from 0 to everupwards as the object lives on
    private int myFrameCounter;

    Vector2 temp;

    public Mexican(Texture2D sSprite, Texture2D aSprite, Rectangle vector, float frameTime)
    {
        staticSprite = sSprite;
        animatedSprite = aSprite;
        myFrameTime = frameTime;
        bounds = vector;
        elapsedFrameTime = 0.0f;
        myFrameIndex = 0;
        myFrameCounter = 0;
        temp.X = bounds.X;
        temp.Y = bounds.Y;
    }

    public int FrameCount()
    {
        return animatedSprite.Width / animatedSprite.Height;
    }

    private Vector2 Origin()
    {
        return new Vector2(animatedSprite.Height / 2.0f, animatedSprite.Height / 2.0f);
    }

    public void drawAnimation(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects)
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
        int cellWidth = animatedSprite.Height;
        int leftMostPixel = myFrameIndex * cellWidth;
        Rectangle sourceRect = new Rectangle(leftMostPixel, 0, cellWidth, cellWidth);

        // Draw the current frame.
        // (bigTexture, posOnScreen, sourceRect in big texture, col, rotation, origin, scale, effect, depth)
        Vector2 orig = Origin();
        spriteBatch.Draw(animatedSprite, temp, sourceRect, Color.White, 0.0f, orig, 1.0f, spriteEffects, 0.5f);
    }

    public void drawStatic(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(staticSprite, temp, Color.White);

    }

}
