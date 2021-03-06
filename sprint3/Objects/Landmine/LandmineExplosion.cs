using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using System.Collections.Generic;
using System;

namespace CSE3902_Project.Objects.Torpedo
{
    public class LandmineExplosion : ISprite
    {
        public Game1 game;
        public Dictionary<Vector2, int> staticExplosionList = new Dictionary<Vector2, int>();
        private Texture2D texture;
        public Vector2 pos;
        public Rectangle collider2D { get; set; }
        public ICollisionHandler collisionHandler;

        public int sheetRow = 6;
        public int sheetColumn = 6;
        private int currentFrame = 0;
        private int totalFrames = 36;
        int randomNum = 1;
        int count = 0;

        public LandmineExplosion(Game1 game, Vector2 pos)
        {
            this.game = game;
            this.pos = pos;
            texture = ItemTextureStorage.Instance.getLandmineExplosionItemSprite();
        }

        public void Update()
        {
            if (currentFrame <= totalFrames)
            {
                Random rd = new Random();
                if (count % 30 != 0)
                {
                    randomNum = rd.Next(1, 6);
                }
                if (randomNum == 1)
                {
                    currentFrame++;
                    count++;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = texture.Width / sheetColumn;
            int height = texture.Height / sheetRow;
            int row = currentFrame / sheetColumn;
            int column = currentFrame % sheetColumn;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, width, height);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}

