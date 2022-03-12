using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Decorations;

namespace CSE3902_CSE3902_Project.Sprites.BlockSprites
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
            collider2D = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);
        }

        public void Draw(SpriteBatch spriteBatch)
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
