using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint3.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Objects.Bomb
{
    public class Explosion : ISprite, ICollideable
    {
        public Dictionary<Vector2, int> staticExplosionList = new Dictionary<Vector2, int>();
        private Texture2D texture;
        public int timer;
        private Vector2 pos;

        public Rectangle collider2D;
        public ICollisionHandler collisionHandler;

        public Explosion(Vector2 pos)
        {
            this.pos = pos;
            timer = 20;
            texture = ItemTextureStorage.Instance.getExplosionSprite();
            collider2D = new Rectangle((int)pos.X + 3, (int)pos.Y + 3, 44, 44);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle destinationRec = new Rectangle((int)destination.X, (int)destination.Y, 50, 50);
            Rectangle sourceRec = SpriteConstants.EXPLOSION;
            spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
            
        }

        public void DrawExplosions(SpriteBatch spriteBatch)
        {
            timer--;
            if (timer != 0)
            {
                Draw(spriteBatch, pos);
            }
        }

/*        public void AddNewExplosionOrigin(Vector2 pos, int timer)
        {
            staticExplosionList.Add(pos, timer);
        }*/

        public void Update()
        {
        }

        public void UpdateCollider()
        {
        }
    }
}
