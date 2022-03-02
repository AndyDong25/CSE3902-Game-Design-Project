using sprint2.Collisions;
using sprint2.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Enemy e = (Enemy)o;
            e.xPos = e.previousXPos;
            e.yPos = e.previousYPos;
            e.UpdateCollider();
        }
    }
}
