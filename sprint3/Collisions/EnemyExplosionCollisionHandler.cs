using sprint2.Collisions;
using sprint2.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class EnemyExplosionCollision
        : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Enemy e = (Enemy)o;
            e.currState = new EnemyDeathState(e);
            e.isDead = true;
        }
    }
}
