using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Decorations;

namespace CSE3902_CSE3902_Project.Sprites.BlockSprites
{
    public class DestructableBlockSprite : ISprite, ICollideable
    {
        private Game1 game;
        public Vector2 pos;

        public ICollisionHandler collisionHandler;
        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }

        public Texture2D texture { get; set; }

        public DestructableBlockSprite(Game1 game, Vector2 pos)
        {
            this.game = game;
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

        public void Remove()
        {
            game.map.finishedObstacles.Add(this);
            game.map.AddItem(pos);
        }

        public void Update()
        {
        }

        public void UpdateCollider()
        {
        }
    }
}
