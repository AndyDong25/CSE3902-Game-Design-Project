using sprint2.Collisions;
using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Objects.Player;
using System.Text;

namespace sprint3.Collisions
{
    class PlayerExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player currentPlayer = (Player)o;
            currentPlayer.currState = new PlayerDeathState(currentPlayer);
            currentPlayer.isDead = true;
        }
    }
}
