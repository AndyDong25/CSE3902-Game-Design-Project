using CSE3902_Sprint2.Sprites.BlockSprites;
using sprint2.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class BlockPlayerCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            DestructableBlockSprite b = (DestructableBlockSprite) o;

            // TODO: implement collision responses
        }
    }
}
