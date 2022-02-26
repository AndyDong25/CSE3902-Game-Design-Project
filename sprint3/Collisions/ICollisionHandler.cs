using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Collisions
{
    public interface ICollisionHandler
    {
        public void HandleCollision(object o);
    }
}
