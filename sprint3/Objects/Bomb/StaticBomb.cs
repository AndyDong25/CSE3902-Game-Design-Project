using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;

namespace CSE3902_Project.Objects.Bomb
{
    public class StaticBomb : ISprite, ICollideable
    {
        public Game1 game;
        private Player player;
        public Vector2 pos;
        public Texture2D texture { get; set; }
        public ICollisionHandler collisionHandler;
        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }
     
        public int timer;

        public bool passable;
        public StaticBomb(Game1 game, Player player, Vector2 pos)
        {
            this.player = player;
            this.game = game;
            texture = ItemTextureStorage.Instance.getBombObjectSprite();
            this.pos = pos;
            timer = 200;
            /** 
             * TODO: find the actual hitbox
             * */
            collider2D = new Rectangle((int)pos.X + 2, (int)pos.Y + 6, 25, 34);
            if (player.collider2D.Intersects(collider2D))
            {
                passable = true;
            }
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle sourcerectangle = new Rectangle(0, 0, 1340, 1340);
            Rectangle destinationrectangle = new Rectangle((int)pos.X, (int)pos.Y, 50, 50);
            float rotation = .0f;
            spriteBatch.Draw(texture, destinationrectangle, sourcerectangle, Color.White, rotation, new Vector2(100, 50), SpriteEffects.None, 0f);
        }

        public void Update()
        {
            timer--;
            if (timer <= 0)
            {
                game.map.finishedBombs.Add(this);
                game.map.AddExplosions(pos, player.potionCount);
            }
            if (!player.collider2D.Intersects(collider2D))
            {
                passable = false;
            }
        }

        public void UpdateCollider()
        {
            
        }
    }
}

