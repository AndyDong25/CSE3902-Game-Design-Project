using CSE3902_Project.Objects.Bomb;
using sprint3.Objects.Bomb;
using System.Collections.Generic;

namespace CSE3902_Project.Collisions
{
    class ExplosionRangeHandler : ICollisionHandler
    {
        int index;
        public ExplosionRangeHandler(int index)
        {
            this.index = index;
        }
        public void HandleCollision(object o)
        {
            List<ExplosionRange> l = (List<ExplosionRange>)o;
            l.RemoveRange(index, l.Count - index);
        }
    }
}
