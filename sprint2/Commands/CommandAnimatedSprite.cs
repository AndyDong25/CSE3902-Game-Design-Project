using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
    class CommandAnimatedSprite: ICommand
    {
        public Game1 Game { get; set; }
        public CommandAnimatedSprite(Game1 game)
        {
            Game = game;

        }
        
        public void Execute() {
/*            int mouseX, mouseY;
            Texture2D texture = Game.spriteTexture;
 
            Game.marioMoves = Game1.MarioMovement.NonMovingAnimated;
            Game.sprite = new AnimatedSprite(texture, 2, 4);*/
        }
        

    }
}
