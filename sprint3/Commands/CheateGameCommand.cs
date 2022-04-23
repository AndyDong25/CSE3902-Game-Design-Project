using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Commands;
using CSE3902_CSE3902_Project.Objects.Player;
using System;
using System.Collections.Generic;
using System.Text;
namespace sprint3.Commands
{
    class CheateGameCommand : ICommand
    {
        private Player player;
        private bool flag = false;
        public CheateGameCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.CheateMode = !flag;
        }


    }
}
