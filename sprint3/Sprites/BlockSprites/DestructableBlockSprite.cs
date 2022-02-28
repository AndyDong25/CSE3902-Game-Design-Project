﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint2.Objects.Decorations;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    public class DestructableBlockSprite : ISprite
    {
        public Vector2 pos;

        ICollisionHandler collisionHandler;
        public Rectangle collider2D;

        public Texture2D texture { get; set; }

        public DestructableBlockSprite(Vector2 pos)
        {
            this.pos = pos;
            /** 
 * TODO: find the actual hitbox
 * */
            collider2D = new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getDestructibleBlockSprite();
            Rectangle sourceRectangle = SpriteConstants.DESTRUCTIBLE_BLOCK;
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
