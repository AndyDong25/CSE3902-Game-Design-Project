using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using System.Collections.Generic;

namespace CSE3902_Project.Objects.Bomb
{
    public class Explosion : ISprite, ICollideable
    {
        public Game1 game;
        public Dictionary<Vector2, int> staticExplosionList = new Dictionary<Vector2, int>();
        private Texture2D texture;
        public int timer;
        private Vector2 pos;

        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }
        public ICollisionHandler collisionHandler;

        public Explosion(Game1 game, Vector2 pos)
        {
            this.game = game;
            this.pos = pos;
            timer = 20;
            texture = ItemTextureStorage.Instance.getExplosionSprite();
            collider2D = new Rectangle((int)pos.X + 7, (int)pos.Y + 7, 36, 36);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle destinationRec = new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
            Rectangle sourceRec = SpriteConstants.EXPLOSION;
            spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
            
        }

        public void Update()
        {
/*            timer--;
            if (timer <= 0)
            {
                game.map.finishedExplosions.Add(this);
            }*/
        }

        public void UpdateCollider()
        {
        }
    }
}
