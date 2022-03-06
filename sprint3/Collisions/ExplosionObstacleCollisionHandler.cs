using CSE3902_Project.Objects.Bomb;
using System.Collections.Generic;

namespace CSE3902_Project.Collisions
{
    class ExplosionObstacleCollisionHandler : ICollisionHandler
    {
        int index;
        public ExplosionObstacleCollisionHandler(int index)
        {
            this.index = index;
        }
        public void HandleCollision(object o)
        {
            List<Explosion> l = (List<Explosion>)o;
            l.RemoveRange(index, l.Count - index);
        }
    }
}
