using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint0
{
    class CommandStaticSprite: ICommand
    {
        public Game1 Game { get; set; }
        public CommandStaticSprite(Game1 game)
        {
            Game = game;

        }
        
        public void Execute() {
            int mouseX, mouseY;
            Texture2D texture = Game.spriteTexture;
            Game.marioMoves = Game1.MarioMovement.NonMovingStatic;
            Game.sprite = new StaticSprite(texture, new Rectangle(0, 0, 240, 322));
        }
        

    }
}
