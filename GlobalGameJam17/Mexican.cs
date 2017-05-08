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
    Texture2D staticSprite;
    Texture2D animatedSprite;
    Vector2 bounds;
    GameTime gameTime;
        
    Mexican(Texture2D sSprite, Texture2D aSprite, Vector2 vector)
    {
        staticSprite = sSprite;
        animatedSprite = aSprite;
        bounds = vector;
    }


    public void update(GameTime t)
    {
        gameTime = t;
    }

    public void drawStatic(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(staticSprite, bounds, Color.White);
    }
    public void drawAnimation(SpriteBatch spriteBatch)
    {
        animatedSpriteStrip animation = new animatedSpriteStrip(animatedSprite, 100f, false);
        animation.Draw(gameTime, spriteBatch, bounds, SpriteEffects.None);

    }
}
