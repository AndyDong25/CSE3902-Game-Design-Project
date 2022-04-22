using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Commands
{
    class PauseGameCommand : ICommand
    {
        private Game1 game;

        public PauseGameCommand(Game1 game)
        {
            this.game = game; ;
        }

        public void Execute()
        {
            game.gameState.ChangeToGamePause();
        }
    }
}
