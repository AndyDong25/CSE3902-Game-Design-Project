using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint0
{
    class StaticMovingSprite : ISprite
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public int screenHeight;
        private Vector2 Position;
        
        public StaticMovingSprite(Texture2D texture, Rectangle sourceRectangle,Vector2 position, Vector2 screenSize)
        {
            Columns = 1;
            Rows = 1;
            Position = position;
            Texture = texture;
            SourceRectangle = sourceRectangle;
            screenHeight = (int)screenSize.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle destinationRectangle = new Rectangle((int)Position.X,
                                                           (int)Position.Y,
                                                           SourceRectangle.Width,
                                                           SourceRectangle.Height);
            
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, SourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            if (Position.Y == 0)
            {
                Position.Y = screenHeight;
            }
            else
            {
                Position.Y--;
            }
        }
    }
}
