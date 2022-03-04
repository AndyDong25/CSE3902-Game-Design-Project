using sprint2.Collisions;
using sprint2.Objects.NPC.Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class SnakeExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Snake s = (Snake)o;
            s.currState = new SnakeDeathState(s);
            s.isDead = true;
        }
    }
}
