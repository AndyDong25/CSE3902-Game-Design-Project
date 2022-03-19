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
    public class Portal : ICollideable, ISprite
    {
        private Game1 game;
        public Portal otherPortal;
        public Vector2 position;
        private List<Rectangle> sources;
        private Rectangle sourceRec;
        private Rectangle destinationRec;
        private Texture2D texture;
        private int sourceIndex;
        private int frameRate;
        public Rectangle collider2D;
        public ICollisionHandler collisionHandler;
        public int cooldownTimer;
        public bool cooldown;
        public Portal(Vector2 position, Game1 game)
        {
            this.game = game;
            this.position = position;
            sources = SpriteConstants.PORTAL;
            destinationRec = new Rectangle((int)position.X, (int)position.Y, 30, 70);
            texture = DecorationTextureStorage.Instance.getPortalSprite();
            sourceIndex = 0;
            sourceRec = sources[sourceIndex];
            frameRate = 5;
            collider2D = new Rectangle((int)position.X + 3, (int)position.Y + 3, 24, 60);
            cooldownTimer = 500;
            cooldown = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
        }

        public void Update()
        {
            if (cooldown)
            {
                if (--cooldownTimer <= 0)
                {
                    cooldownTimer = 500;
                    cooldown = false;
                }
            }
            if (--frameRate <= 0)
            {
                frameRate = 5;
                sourceIndex = (sourceIndex + 1) % sources.Count;
                sourceRec = sources[sourceIndex];
            }
        }

        public void UpdateCollider()
        {
        }

        public void SetOtherPortal(Portal p)
        {
            otherPortal = p;
        }
    }
}
