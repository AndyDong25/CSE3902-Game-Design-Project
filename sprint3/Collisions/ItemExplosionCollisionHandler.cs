using sprint2.Collisions;
using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Items;
using CSE3902_Sprint2;
using System.Text;

namespace sprint3.Collisions
{
    class ItemExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            BasicItem item = (BasicItem)o;
            item.Destroy();
        }
    }
}
