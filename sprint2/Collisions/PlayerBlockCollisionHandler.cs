using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Collisions
{
    class PlayerBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o1, object o2)
        {
            Player p = (Player)o1;
            DestructableBlockSprite b = (DestructableBlockSprite)o2;

            // TODO: implement collision responses
        }
    }
}
