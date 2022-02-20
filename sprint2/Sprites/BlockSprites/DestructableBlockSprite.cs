using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    class DestructableBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public DestructableBlockSprite()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Texture = DecorationTextureStorage.Instance.getDestructibleBlockSprite();
            Rectangle sourceRectangle = SpriteConstants.DESTRUCTIBLE_BLOCK;
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 40, 40);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
