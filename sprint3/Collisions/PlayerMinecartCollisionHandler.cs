using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_Project.Collisions
{
    class PlayerMinecartCollisionHandler : ICollisionHandler
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
