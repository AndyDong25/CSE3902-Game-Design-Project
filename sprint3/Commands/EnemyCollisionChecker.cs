using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_Project.Collisions;
using CSE3902_Project.Map;
using CSE3902_Project.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_CSE3902_Project.Commands
{
    class EnemyCollisionChecker: ICollisionChecker
    {
        private Map1 map;
        public EnemyCollisionChecker( Map1 map)
        {
            this.map = map;
        }
        public void CheckCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            foreach (ICollideable e in map.currentEnemyList)
            {
                if (p1.collider2D.Intersects(e.GetCollider2D()))
                {
                    p1.collisionHandler = new PlayerEnemyCollisionHandler((IEnemyState)e);
                    p1.collisionHandler.HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(e.GetCollider2D()))
                {
                    p2.collisionHandler = new PlayerEnemyCollisionHandler((IEnemyState)e);
                    p2.collisionHandler.HandleCollision(p2);
                }
            }
        }
    }
}
