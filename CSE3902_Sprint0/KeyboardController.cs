using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint0
{
    class KeyboardController : IController
    {
        public Game1 Game { get; set; }

        public KeyboardController(Game1 game)
        {
            Game = game;
        }

        public void Update()
        {
            Texture2D texture = Game.spriteTexture;
            SpriteBatch spriteBatch = Game.spriteBatch;
            Vector2 position = Game.spriteposition;
            Vector2 screenSize = Game.screeenSize;
            KeyboardState keyboardState = Keyboard.GetState();
            ICommand staticMoving = new StaticMovingSprite();
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                Game.Exit();
            }

            else if (keyboardState.IsKeyDown(Keys.E))
            {
                staticMoving.Execute(spriteBatch, texture, new Rectangle(0, 0, 256, 322), screenSize);
                
            }
            else if (keyboardState.IsKeyDown(Keys.R))
            {

               
            }
        }
    }
}
