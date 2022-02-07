using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace CSE3902_Sprint2.Sprites
{
    class TextSprite: ISprite
    {

        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        private SpriteFont Font;
        private string mes = "Program made by: Tianle Chen (chen.9471) \n Sprites from: https://www.pngegg.com/en/png-yxgdo";
        public TextSprite(SpriteFont font)
        {
            Font = font;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {

            spriteBatch.Begin();
            spriteBatch.DrawString(Font, mes, new Vector2(400, 400), Color.Black);
            spriteBatch.End();
        }
        public void Update() {
        }
        
    }
}
