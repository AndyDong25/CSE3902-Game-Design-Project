using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint0
{
    class StaticMovingSprite : ICommand
    {
        private Vector2 ScreenSize;
        private Vector2 Position = new Vector2(100,100);
       
       

        
       
        public void Execute(SpriteBatch spriteBatch, Texture2D texture, Rectangle SourceRectangle, Vector2 screenSize)
        {
            
            
            Rectangle destinationRectangle = new Rectangle((int)Position.X,
                                                           (int)Position.Y,
                                                           SourceRectangle.Width,
                                                           SourceRectangle.Height);
            
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, SourceRectangle, Color.White);
            spriteBatch.End();
            ScreenSize = screenSize;
        }

        public void Update()
        {
            if (Position.Y == 0)
            {
                Position.Y = ScreenSize.Y;
            }
            else
            {
                Position.Y--;
            }
        }
        
    }
}
