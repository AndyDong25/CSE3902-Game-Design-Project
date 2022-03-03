using sprint2.Collisions;
using sprint2.Objects.NinjaStar;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class NinjaStarBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            NinjaStar n = (NinjaStar)o;
            n.exist = false;
        }
    }
}
