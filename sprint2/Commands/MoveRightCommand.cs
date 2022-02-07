using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Player;

namespace CSE3902_Sprint2.Commands
{
    class MoveRightCommand : ICommand
    {
        private Player myPlayer;
        public MoveRightCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.MoveRight();
        }
    }
}
