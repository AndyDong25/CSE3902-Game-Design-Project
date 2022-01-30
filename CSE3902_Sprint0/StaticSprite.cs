using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint0
{
    class StaticSprite : ISprite
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }

        public StaticSprite(Texture2D texture, Rectangle sourceRectangle)
        {
            Columns = 1;
            Rows = 1;

            Texture = texture;
            SourceRectangle = sourceRectangle;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle destinationRectangle = new Rectangle((int)destination.X,
                                                           (int)destination.Y,
                                                           SourceRectangle.Width,
                                                           SourceRectangle.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, SourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
        }
    }
}
