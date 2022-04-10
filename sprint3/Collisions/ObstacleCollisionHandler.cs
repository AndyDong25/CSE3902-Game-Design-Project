using CSE3902_Project.Collisions;
using sprint3.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class ObstacleCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            IDynamicObject c = (IDynamicObject)o;
            c.GoBackToPrevPosition();
        }
    }
}
