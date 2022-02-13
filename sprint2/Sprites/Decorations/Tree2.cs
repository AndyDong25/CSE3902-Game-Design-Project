using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Sprites.Decorations
{
    class Tree2 : ISprite
    {
        public Texture2D Texture { get; set; }


        public Tree2(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 660, 660);
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 45, 45);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
        }
    
    }
}

