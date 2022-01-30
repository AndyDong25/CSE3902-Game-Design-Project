using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint0
{
    
    class AnimatedMovingSprite : ISprite
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Texture2D Texture { get; set; }
        public int screenWidth;
        private int currentFrame = 0;
        private int totalFrames;
        private Vector2 Position;
        
        public AnimatedMovingSprite(Texture2D texture, int rows, int columns,Vector2 position, Vector2 screenSize)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = 6;
            Position = position;
            screenWidth = (int)screenSize.X;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            if (Position.X == 0)
            {
                Position.X = screenWidth+ 256;
            }
            else
            {
                Position.X++;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;

            }
            
        }
    }
}
