using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Player;


namespace CSE3902_Sprint2.Items
{
    class ShoeItem : BasicItem
    {
        


        public override void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
            currentPlayer.speed += increaseAmount;
            

        }

        public override void Deactivate()
        {
            boostedPlayer.speed -= increaseAmount;
        }

        
    }
}
