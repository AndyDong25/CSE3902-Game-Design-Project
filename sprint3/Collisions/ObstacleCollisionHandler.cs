using CSE3902_Project.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class ObstacleCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            ICollideable c = (ICollideable)o;
            c.UpdateCollider();
        }
    }
}
