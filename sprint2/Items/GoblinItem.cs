using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Objects.Player;
using System.Text;

namespace CSE3902_Sprint2.Items
{
    class GoblinItem : BasicItem
    {
        public override void Activate(Player currentPlayer)
        {
            currentPlayer.ChangeCharacter();
        }

        public override void Deactivate()
        {
            boostedPlayer.ChangeCharacter();
        }
    }
}
