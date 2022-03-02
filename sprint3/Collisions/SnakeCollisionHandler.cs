using sprint2.Collisions;
using sprint2.Objects.NPC.Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class SnakeCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Snake s = (Snake)o;
            s.xPos = s.previousXPos;
            s.yPos = s.previousYPos;
            s.UpdateCollider();
        }
    }
}
