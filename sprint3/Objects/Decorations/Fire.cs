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
    public class Fire : ICollideable, ISprite
    {
        private Game1 game;
        public Portal otherPortal;
        public Vector2 position;
        private List<Rectangle> sources;
        private Rectangle sourceRec;
        private int row;
        private int colomn;
        private Rectangle destinationRec;
        private Texture2D texture;
        private int sourceIndex;
        private int frameRate;
        public Rectangle collider2D;
        public ICollisionHandler collisionHandler;
        
        public Fire(Vector2 position, Game1 game)
        {
            this.game = game;
            this.position = position;
            sources = SpriteConstants.FIRE;
            destinationRec = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            texture = DecorationTextureStorage.Instance.getFireSprite();
            sourceIndex = 0;
            sourceRec = sources[sourceIndex];
            collider2D = new Rectangle((int)position.X + 3, (int)position.Y + 3, 60, 60);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
        }

        public void Update()
        {
            sourceIndex = (sourceIndex + 1) % 60;
            row = sourceIndex / 10;
            colomn = sourceIndex % 10;
            sourceRec = new Rectangle(64 * colomn, 64 * row, 64 *(colomn+1), 64 * (row+1));

        }

        public void UpdateCollider()
        {
        }

    }
}
