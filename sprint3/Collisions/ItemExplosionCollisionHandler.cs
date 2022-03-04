using sprint2.Collisions;
using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Items;
using CSE3902_Sprint2;
using System.Text;
using System.Diagnostics;

namespace sprint3.Collisions
{
    class ItemExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            //Debug.WriteLine("Item Explosion Collided");
            BasicItem item = (BasicItem)o;
            item.Destroy();
        }
    }
}
