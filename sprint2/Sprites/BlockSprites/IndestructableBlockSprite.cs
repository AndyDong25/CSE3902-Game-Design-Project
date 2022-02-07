using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    class IndestructableBlockSprite : ISprite 
    { 
        public Texture2D Texture { get; set; }

        public IndestructableBlockSprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 250, 250);
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 30, 30);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }
}
