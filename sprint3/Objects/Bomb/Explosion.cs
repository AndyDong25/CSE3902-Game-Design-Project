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
        private Texture2D Rangetexture;
        public int timer;
        private Vector2 pos;
        public bool canHurtAI = false;
        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }
        public ICollisionHandler collisionHandler;

        public Explosion(Game1 game, Vector2 pos, bool canHurtAI)
        {
            this.game = game;
            this.pos = pos;
            this.canHurtAI = canHurtAI;
            timer = 20;
            texture = ItemTextureStorage.Instance.getExplosionSprite();
            Rangetexture = ItemTextureStorage.Instance.getRangeTexture(); 
            collider2D = new Rectangle((int)pos.X + 2, (int)pos.Y + 2, 36, 36);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRec = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);
            Rectangle sourceRec = SpriteConstants.EXPLOSION;
            spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
            
        }
        public void DrawRange(SpriteBatch spriteBatch)
        {
            Rectangle destinationRec = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);
            Rectangle sourceRec = SpriteConstants.EXPLOSION;
            spriteBatch.Draw(Rangetexture, destinationRec, sourceRec, new Color(Color.Transparent,4), 0.0f, Vector2.Zero, SpriteEffects.None, (float)0.0000000000000001);

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
        public Rectangle GetCollider2D()
        {
            return collider2D;
        }

    }
}
