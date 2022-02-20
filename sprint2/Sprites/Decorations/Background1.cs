using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Sprites.Decorations
{
    class Background1 : ISprite
    {
        public Texture2D Texture { get; set; }
        public Background1()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Texture = DecorationTextureStorage.Instance.getBackground1Sprite();
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 800, 480);

            spriteBatch.Draw(Texture, destinationRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
