using sprint2.Collisions;
using sprint2.Objects.NPC.Bat;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class BatCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Bat b = (Bat)o;
            b.xPos = b.previousXPos;
            b.yPos = b.previousYPos;
            b.UpdateCollider();
        }
    }
}
