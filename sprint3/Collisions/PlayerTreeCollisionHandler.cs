using CSE3902_Sprint2.Objects.Player;
using sprint2.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class PlayerTreeCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player p = (Player)o;

            p.xPos = p.previousXPos;
            p.yPos = p.previousYPos;
            p.UpdateCollider();
        }
    }
}
