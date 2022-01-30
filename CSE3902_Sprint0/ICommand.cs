using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint0
{
        public interface ICommand
        {
        void Update() { }
            void Execute(SpriteBatch spriteBatch, Texture2D texture, Rectangle SourceRectangle, Vector2 screenSize);
        }
    }

    

