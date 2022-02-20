using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Player;

namespace CSE3902_Sprint2.Commands
{
    class SwitchItemCommand : ICommand
    {
        private Game1 game;
        public SwitchItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.map.currItemIndex++;
        }
    }
}
