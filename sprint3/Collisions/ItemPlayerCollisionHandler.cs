using sprint2.Collisions;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Player;

namespace sprint3.Collisions
{
    class ItemPlayerCollisionHandler : ICollisionHandler
    {

        public Player currentPlayer;

        //we can change this in the future if it is unecessary
        public ItemPlayerCollisionHandler(Player p)
        {
            currentPlayer = p;
        }

        public void HandleCollision(object o)
        {
            BasicItem item = (BasicItem)o;
            /* Make sure we are not giving a player an item that has already been used. */ 
            if (!item.activated)
            {
                item.Activate(currentPlayer);
            }
        }
    }
}
