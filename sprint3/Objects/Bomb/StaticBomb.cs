using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint3.Collisions;
using sprint3.Objects.Bomb;
using System.Collections.Generic;

namespace sprint2.Objects.Bomb
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
            collider2D = new Rectangle((int)pos.X + 3, (int)pos.Y + 3, 150, 150);
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
        }

        public void UpdateCollider()
        {
            
        }
    }
}

