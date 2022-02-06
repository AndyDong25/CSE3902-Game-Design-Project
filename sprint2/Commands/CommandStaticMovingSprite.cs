using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
   
        class CommandStaticMovingSprite : ICommand
        {
            public Game1 Game { get; set; }
            public CommandStaticMovingSprite(Game1 game)
            {
                Game = game;

            }
            public void Execute()
            {
/*                int mouseX, mouseY;
                Texture2D texture = Game.spriteTexture;
                Vector2 position = Game.spriteposition;
                Vector2 screenSize = Game.screeenSize;
                Game.marioMoves = Game1.MarioMovement.MovingStatic;
                Game.sprite = new StaticMovingSprite(texture, new Rectangle(0, 0, 240, 322), position, screenSize);*/
            }
        }
   
}
