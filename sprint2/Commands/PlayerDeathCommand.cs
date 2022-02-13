using CSE3902_Sprint2.Commands;
using CSE3902_Sprint2.Objects.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Commands
{
    class PlayerDeathCommand : ICommand
    {
        private Player myPlayer;
        public PlayerDeathCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.currState = new PlayerDeathState(myPlayer);
        }
    }
}
