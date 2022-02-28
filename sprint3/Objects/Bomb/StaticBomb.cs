using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint3.Collisions;
using sprint3.Objects.Bomb;
using System.Collections.Generic;

namespace sprint2.Objects.Bomb
{
    public class StaticBomb : ISprite, ICollideable
    {
        private Player player;
        public List<Explosion> explosionList;
        public Texture2D texture { get; set; }
        public Rectangle collider2D;

        public StaticBomb(Player player)
        {
            texture = ItemTextureStorage.Instance.getBombObjectSprite();
            this.player = player;
            explosionList = new List<Explosion>();
            /** 
             * TODO: find the actual hitbox
             * */
            collider2D = new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = ItemTextureStorage.Instance.getBombObjectSprite();
            Rectangle sourcerectangle = new Rectangle(0, 0, 1340, 1340);
            Rectangle destinationrectangle = new Rectangle((int)destination.X, (int)destination.Y, 50, 50);
            float rotation = .0f;
            spriteBatch.Draw(texture, destinationrectangle, sourcerectangle, Color.White, rotation, new Vector2(100, 50), SpriteEffects.None, 0f);
        }

        public void AddNewExplosion(Vector2 pos, int potionCount)
        {
            int xOffset = -12;
            int yOffset = -7;
            // origin
            explosionList.Add(new Explosion(new Vector2(pos.X + xOffset, pos.Y + yOffset)));
            int x = (int)pos.X;
            int y = (int)pos.Y;
            // radius in each direction
            for (int i = 1; i < potionCount; i++)
            {
                explosionList.Add(new Explosion(new Vector2(xOffset + 50 * i + x, yOffset + y)));
                explosionList.Add(new Explosion(new Vector2(xOffset + x - (50 * i), yOffset + y)));
                explosionList.Add(new Explosion(new Vector2(xOffset + x, yOffset + 50 * i + y)));
                explosionList.Add(new Explosion(new Vector2(xOffset + x, yOffset + y - (50 * i))));
            }
        }
        public void DrawExplosions(SpriteBatch spriteBatch)
        {
            foreach (Explosion e in explosionList)
            {
                e.DrawExplosions(spriteBatch);
            }
        }

        public void Update()
        {
            List<Explosion> finishedExplosions = new List<Explosion>();
            foreach (Explosion explosion in explosionList)
            {
                if (explosion.timer <= 0)
                {
                    finishedExplosions.Add(explosion);
                }
            }
            foreach (Explosion explosion in finishedExplosions)
            {
                explosionList.Remove(explosion);
            }
        }

        public void UpdateCollider()
        {
        }
    }
}

