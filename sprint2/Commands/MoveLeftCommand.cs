using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Player;

namespace CSE3902_Sprint2.Commands
{
    class MoveLeftCommand : ICommand
    {
        private Player myPlayer;
        public MoveLeftCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.MoveLeft();
        }
    }
}
