using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Objects.Bomb
{
    class StaticBomb : ISprite
    {
        public Texture2D Texture { get; set; }

        
        public StaticBomb(Texture2D texture)
        {
            this.Texture = texture;
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            //destination.X = player.xPos;
            //destination.Y = player.yPos;
            Rectangle sourcerectangle = new Rectangle(0, 0, 1340, 1340);
            Rectangle destinationrectangle = new Rectangle((int)destination.X, (int)destination.Y, 50, 50);

            spriteBatch.Begin();

            //float scale = .5f; //50% smaller
            float rotation = .0f;
            spriteBatch.Draw(Texture, destinationrectangle, sourcerectangle, Color.White, rotation, new Vector2(100, 50), SpriteEffects.None, 0f);
            //spriteBatch.Draw(Texture, destinationrectangle, sourcerectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
        }

    }
}
