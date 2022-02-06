using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
    class CommandAnimatedMovingSprite: ICommand
    {
        public Game1 Game { get; set; }
        public CommandAnimatedMovingSprite(Game1 game)
        {
            Game = game;

        }
        
        public void Execute() { 
            Texture2D texture = Game.spriteTexture;
            Vector2 position = Game.spriteposition;
            Vector2 screenSize = Game.screeenSize;
            Game.marioMoves = Game1.MarioMovement.MovingAnimated;
            Game.sprite = new AnimatedMovingSprite(texture, 2, 4, position, screenSize);
        }
        

    }
}
