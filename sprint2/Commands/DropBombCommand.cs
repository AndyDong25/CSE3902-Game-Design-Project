using CSE3902_Sprint2.Objects.Player;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Commands
{
    class DropBombCommand : ICommand
    {
        private Player myPlayer;
        public DropBombCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.DropBomb();
        }
    }
}
