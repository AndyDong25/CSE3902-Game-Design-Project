using sprint2.Collisions;
using sprint2.Objects.Bomb;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class BombExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            StaticBomb b = (StaticBomb)o;
            b.timer = 0;
        }
    }
}
