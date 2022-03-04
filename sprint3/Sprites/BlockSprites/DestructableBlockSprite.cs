using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Decorations;

namespace CSE3902_CSE3902_Project.Sprites.BlockSprites
{
    public class DestructableBlockSprite : ISprite, ICollideable
    {
        public Vector2 pos;

        ICollisionHandler collisionHandler;
        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }

        public Texture2D texture { get; set; }

        public DestructableBlockSprite(Vector2 pos)
        {
            this.pos = pos;
            /** 
 * TODO: find the actual hitbox
 * */
            collider2D = new Rectangle((int)pos.X - 5, (int)pos.Y, 55, 50);
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

        public void UpdateCollider()
        {
        }
    }
}
