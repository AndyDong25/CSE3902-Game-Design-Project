using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Objects.NPC;
using CSE3902_Project.Collisions;
using System.Collections.Generic;

namespace CSE3902_Project.Objects.Bomb
{
    class StaticBombForEnemy : ISprite, ICollideable
    {
        private Enemy enemy;
        public Texture2D texture { get; set; }
        public int radius;
        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }

        public StaticBombForEnemy(Texture2D texture, Enemy enemy)
        {
            this.texture = texture;
            this.enemy = enemy;
            radius = enemy.potionCount;
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

        public void Update()
        {
        }

        public void Explode(SpriteBatch spriteBatch, List<Rectangle> bombrange)
        {
            Texture2D explosionTexture = ItemTextureStorage.Instance.getExplosionSprite();
            Rectangle sourceRec = SpriteConstants.EXPLOSION;

            radius = enemy.potionCount;
            foreach (Rectangle rec in bombrange)
            {
                spriteBatch.Draw(explosionTexture, rec, sourceRec, Color.White);
            }
        }

        public void UpdateCollider()
        {
        }
    }
}

