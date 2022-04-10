using CSE3902_Project.Collisions;
using sprint3.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class DynamicObjExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            IDynamicObject d = (IDynamicObject)o;
            d.Die();
        }
    }
}
