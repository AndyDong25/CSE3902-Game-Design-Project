using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint2.Objects.Decorations;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    class DestructableBlockSprite : ISprite
    {

        ICollisionHandler collisionHandler;
        public Texture2D texture { get; set; }

        public DestructableBlockSprite()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getDestructibleBlockSprite();
            Rectangle sourceRectangle = SpriteConstants.DESTRUCTIBLE_BLOCK;
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
