using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint2.Objects.Decorations;
using sprint3.Collisions;

namespace CSE3902_Sprint2.Sprites.BlockSprites
{
    public class IndestructableBlockSprite : ISprite, ICollideable 
    {
        public Vector2 pos;
        public Texture2D texture { get; set; }
        ICollisionHandler collisionHandler;
        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }

        public IndestructableBlockSprite(Vector2 pos)
        {
            this.pos = pos;
            /** 
 * TODO: find the actual hitbox
 * */
            collider2D = new Rectangle((int)pos.X - 5, (int)pos.Y, 55, 50);
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

        public void UpdateCollider()
        {
        }
    }
}
