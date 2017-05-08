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
    Rectangle bounds;
        
    public Mexican(Texture2D sSprite, Texture2D aSprite, Rectangle vector)
    {
        staticSprite = sSprite;
        animatedSprite = aSprite;
        bounds = vector;
    }

    public void drawStatic(SpriteBatch spriteBatch)
    {
        Vector2 temp;
        temp.X = bounds.X;
        temp.Y = bounds.Y;
        spriteBatch.Draw(staticSprite, temp, Color.White);

    }
}
