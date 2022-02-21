using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    class IndestructableBlockSprite : ISprite 
    { 
        public Texture2D texture { get; set; }

        public IndestructableBlockSprite()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getIndestructibleBlockSprite();
            Rectangle sourceRectangle = SpriteConstants.INDESTRUCTIBLE_BLOCK;
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

        }
    }
}
