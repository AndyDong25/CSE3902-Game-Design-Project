using CSE3902_Sprint2;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Sprites.Decorations
{
    class Tree2 : ISprite
    {
        public Texture2D Texture { get; set; }


        public Tree2()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            Texture = DecorationTextureStorage.Instance.getTree2Sprite();
            Rectangle sourceRectangle = SpriteConstants.TREE2;
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 40, 40);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }
    
    }
}

