using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    class IndestructableBlockSprite : ISprite 
    { 
        public Texture2D Texture { get; set; }

        public IndestructableBlockSprite()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Texture = DecorationTextureStorage.Instance.getIndestructibleBlockSprite();
            Rectangle sourceRectangle = SpriteConstants.INDESTRUCTIBLE_BLOCK;
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 40, 40);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

        }
    }
}
