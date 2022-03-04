using sprint2.Collisions;
using sprint2.Objects.Bomb;
using sprint2.Objects.NinjaStar;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class NinjaStarBombCollisionHandler : ICollisionHandler
    {
        public void HandleCollision2(NinjaStar n, StaticBomb b)
        {
            
            n.exist = false;
            b.timer = 0;
            
        }

        public void HandleCollision(object o)
        {
            throw new NotImplementedException();
        }
    }
}
