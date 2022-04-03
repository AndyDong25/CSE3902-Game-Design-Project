using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Objects.Decorations
{
    public class Minecart : ICollideable, ISprite
    {
        private Game1 game;
        public Portal otherPortal;
        public Vector2 position;
        private Rectangle sourceRec;
        private Rectangle destinationRec;
        private Texture2D texture;
        private int sourceIndex;
        private int frameRate;
        public Rectangle collider2D;
        public ICollisionHandler collisionHandler;
        public int cooldownTimer;
        public bool cooldown;
        public Minecart(Vector2 position, Game1 game)
        {
            this.game = game;
            this.position = position;
            sourceRec = SpriteConstants.MINECART;
            destinationRec = new Rectangle((int)position.X, (int)position.Y, 40, 32);
            texture = DecorationTextureStorage.Instance.getMinecartSprite();
            collider2D = new Rectangle((int)position.X + 3, (int)position.Y + 3, 40, 30);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
        }

        public void Update()
        {
            
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
