﻿using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_Project.Objects.Torpedo;

namespace CSE3902_Project.Collisions
{
    class PlayerLandmineExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player currentPlayer = (Player)o;
            currentPlayer.currState = new PlayerDeathState(currentPlayer);
            currentPlayer.isDead = true;
            currentPlayer.UpdateCollider();
        }
    }
}

