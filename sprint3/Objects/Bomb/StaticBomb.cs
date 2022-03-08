using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using System.Diagnostics;

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
            collider2D = new Rectangle((int)pos.X + 2, (int)pos.Y + 6, 35, 40);
            if (player.collider2D.Intersects(collider2D))
            {
                passable = true;
            }
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle sourcerectangle = new Rectangle(0, 0, 255, 255);
            Rectangle destinationrectangle = new Rectangle((int)pos.X, (int)pos.Y, 45, 45);
            spriteBatch.Draw(texture, destinationrectangle, sourcerectangle, Color.White);
        }

        public void Update()
        {
            timer--;
            if (timer <= 0)
            {
                game.map.tileMap.tileMap.Remove(pos);
                game.map.finishedBombs.Add(this);
                game.map.AddExplosions(pos, player.potionCount);
                player.bombCount++;
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

