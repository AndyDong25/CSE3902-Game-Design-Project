using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint0
{
    
    class AnimatedSprite : ISprite
    {

        public Texture2D Texture { get; set; }

        private int currentFrame = 0;
        private int totalFrames;
        private int Columns;
        private int Rows;
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = 6;
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            // int width = Texture.Width / Columns;
            int width = 245; 
            //As the spritesheet is not perfect, hardcoding here for temporary useage
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, width, height);
            
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;

            }
            
        }
    }
}
