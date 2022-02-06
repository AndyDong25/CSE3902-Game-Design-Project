using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
    class CommandExit: ICommand
    {
        public Game1 Game { get; set; }
        public CommandExit(Game1 game)
        {
            Game = game;

        }
        
        public void Execute() {
            Game.Exit();
        }
        

    }
}
