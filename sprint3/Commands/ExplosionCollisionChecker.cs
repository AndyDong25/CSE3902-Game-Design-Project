using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites.BlockSprites;
using CSE3902_Project.Collisions;
using CSE3902_Project.Map;
using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.NPC;
using sprint3.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_CSE3902_Project.Commands
{
    class ExplosionCollisionChecker : ICollisionChecker
    {
        private Map1 map;
        private ICollisionHandler collisionHandler;
        public ExplosionCollisionChecker(Map1 map)
        {
            this.map = map;
        }
        public void CheckCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            List<BasicItem> currentItemList = map.currentItemList;
            List<Explosion> explosionList = map.allExplosionsList;
            List<DestructableBlockSprite> destructibleBlockList = map.destructibleBlockList;
            foreach (Explosion e in explosionList)
            {
                if (p1.collider2D.Intersects(e.collider2D))
                {
                    p1.collisionHandler = new PlayerExplosionCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(e.collider2D))
                {
                    p2.collisionHandler = new PlayerExplosionCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                }
                foreach (ICollideable c in map.currentEnemyList)
                {
                    if (e.collider2D.Intersects(c.GetCollider2D()) && e.canHurtAI)
                    {
                        collisionHandler = new DynamicObjExplosionCollisionHandler();
                        collisionHandler.HandleCollision(c);
                    }
                }
                foreach (BasicItem item in currentItemList)
                {
                    if (e.collider2D.Intersects(item.collider2D))
                    {
                        e.collisionHandler = new ItemExplosionCollisionHandler();
                        e.collisionHandler.HandleCollision(item);
                    }
                }
                foreach (DestructableBlockSprite b in destructibleBlockList)
                {
                    if (e.collider2D.Intersects(b.collider2D))
                    {
                        // stop explosion range
                        b.collisionHandler = new DBlockExplosionCollisionHandler();
                        b.collisionHandler.HandleCollision(b);
                    }
                }
            }
        }
    }
}
