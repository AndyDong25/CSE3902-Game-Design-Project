using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Player;

namespace CSE3902_Sprint2.Commands
{
    class MoveUpCommand : ICommand
    {
        private Player myPlayer;
        public MoveUpCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.MoveUp();
        }
    }
}
