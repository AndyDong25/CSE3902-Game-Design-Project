using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint2.Objects.Decorations;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    public class IndestructableBlockSprite : ISprite 
    {
        public Vector2 pos;
        public Texture2D texture { get; set; }
        ICollisionHandler collisionHandler;
        public Rectangle collider2D;

        public IndestructableBlockSprite(Vector2 pos)
        {
            this.pos = pos;
            /** 
 * TODO: find the actual hitbox
 * */
            collider2D = new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getIndestructibleBlockSprite();
            Rectangle sourceRectangle = SpriteConstants.INDESTRUCTIBLE_BLOCK;
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

        }
    }
}
