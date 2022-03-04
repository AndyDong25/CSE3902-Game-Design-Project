using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites.BlockSprites;
using sprint2.Collisions;
using sprint2.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class EnemyBombCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            // TODO: implement collision responses
            Enemy e = (Enemy)o;

            e.xPos = e.previousXPos;
            e.yPos = e.previousYPos;
            e.UpdateCollider();
        }
    }
}
