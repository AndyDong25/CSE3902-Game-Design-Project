using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Collisions
{
    class PlayerBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player p = (Player) o;

            p.xPos = p.previousXPos;
            p.yPos = p.previousYPos;
            p.UpdateCollider();
        }
    }
}
