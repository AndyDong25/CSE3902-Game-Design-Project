using CSE3902_Sprint2.Objects.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Commands
{
    class ChangeCharacterCommand : ICommand
    {
        private Player myPlayer;
        public ChangeCharacterCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.ChangeCharacter();           
        }
    }
}
