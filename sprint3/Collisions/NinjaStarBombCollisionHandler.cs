using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.NinjaStar;
using System;

namespace CSE3902_Project.Collisions
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
