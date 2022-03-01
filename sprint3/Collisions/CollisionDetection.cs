using CSE3902_Sprint2;
using CSE3902_Sprint2.Controller;
using CSE3902_Sprint2.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using CSE3902_Sprint2.Sprites.BlockSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint2.Objects.NPC;
using sprint2.Objects.NPC.Bat;
using sprint2.Objects.NPC.Snake;
using sprint2.Sprites.Decorations;
using sprint3.Objects.Bomb;
using sprint2.Map;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using sprint3.Collisions;
using sprint2.Objects.Bomb;

namespace sprint2.Collisions
{
    public class CollisionDetection
    {

        public Map1 map;
        public CollisionDetection(Map1 map)
        {
            this.map = map;
        }
        public void Update()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            Enemy e1 = map.enemy;
            List<Explosion> exList = map.explosionList;
            List<IEnemyState> enemyList = map.currentEnemyList;
            List<StaticBomb> staticBombList = map.staticBombList;
            List<DestructableBlockSprite> destructibleBlockList = map.destructibleBlockList;
            List<IndestructableBlockSprite> indestructibleBlockList = map.indestructibleBlockList;
            List<ISprite> currentObstacleList = map.currentObstacleList;
            //List<Tree1> tree1List = map.tree1List;
            //Tree1 tree1 = map.tree1;
            //if (p1.collider2D.Intersects(tree1.collider2D))
            //{
            //    p1.collisionHandler = new PlayerBlockCollisionHandler();
            //    p1.collisionHandler.HandleCollision(p1);

            //}

            if (p1.collider2D.Intersects(p2.collider2D))
            {
                p1.collisionHandler = new PlayerBlockCollisionHandler();
                p1.collisionHandler.HandleCollision(p1);
                p2.collisionHandler = new PlayerBlockCollisionHandler();
                p2.collisionHandler.HandleCollision(p2);
            }

            foreach (ISprite s in currentObstacleList)
            {
                if (p1.collider2D.Intersects(s.collider2D))
                {
                    p1.collisionHandler = new PlayerBlockCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(s.collider2D))
                {
                    p2.collisionHandler = new PlayerBlockCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                }
                if (e1.collider2D.Intersects(s.collider2D))
                {
                    e1.collisionHandler = new EnemyBlockCollisionHandler();
                    e1.collisionHandler.HandleCollision(e1);
                }
            }

            foreach (DestructableBlockSprite b in destructibleBlockList)
            {
                if (p1.collider2D.Intersects(b.collider2D))
                {
                    p1.collisionHandler = new PlayerBlockCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    //(p1.collisionHandler as PlayerBlockCollisionHandler).HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(b.collider2D))
                {
                    p2.collisionHandler = new PlayerBlockCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    //(p2.collisionHandler as PlayerBlockCollisionHandler).HandleCollision(p2);
                }
            }
            foreach (IndestructableBlockSprite b in indestructibleBlockList)
            {
                if (p1.collider2D.Intersects(b.collider2D))
                {
                    p1.collisionHandler = new PlayerBlockCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    //(p1.collisionHandler as PlayerBlockCollisionHandler).HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(b.collider2D))
                {
                    p2.collisionHandler = new PlayerBlockCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    //(p2.collisionHandler as PlayerBlockCollisionHandler).HandleCollision(p2);
                }
            }

            // will need to separate obstacles into different list so we can properly cast the CollisionHandler
            foreach (ISprite s in map.currentObstacleList)
            {
                // no responses for blocks needed
/*                if (p1.collider2D.Intersects(s.collider2D))
                {
                    (p1.collisionHandler as PlayerBlockCollisionHandler).HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(s.collider2D))
                {
                    (p2.collisionHandler as PlayerBlockCollisionHandler).HandleCollision(p2);
                }

                foreach (Explosion e in exList)
                {
                    if (e.collider2D.Intersects(s.collider2D))
                    {
                        // doesn't really matter which explosion collision handler we choose: will have same functionality
                        (e.collisionHandler as ExplosionDBlockCollisionHandler).HandleCollision(e);

                        // add destructible block collision response
                    }
                }*/

                foreach (IEnemyState e in enemyList)
                {
                    // need to adjust IEnemyState...
                }
            }

            foreach (Explosion e in exList)
            {
                if (p1.collider2D.Intersects(e.collider2D))
                {
                    p1.collisionHandler = new PlayerExplosionCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    //(p1.collisionHandler as PlayerExplosionCollisionHandler).HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(e.collider2D))
                {
                    p2.collisionHandler = new PlayerExplosionCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    //(p2.collisionHandler as PlayerExplosionCollisionHandler).HandleCollision(p2);
                }
                // bomb-explosion interactions below
                // enemy-explosion interactions below
                foreach (IEnemyState enemy in enemyList)
                {
                }

                foreach (StaticBomb b in staticBombList)
                {
                    if (e.collider2D.Intersects(b.collider2D))
                    {
                        e.collisionHandler = new ExplosionBombCollisionHandler();
                        e.collisionHandler.HandleCollision(e);
                        //(e.collisionHandler as ExplosionBombCollisionHandler).HandleCollision(e);
                        b.collisionHandler = new BombExplosionCollisionHandler();
                        b.collisionHandler.HandleCollision(b);
                        //(b.collisionHandler as BombExplosionCollisionHandler).HandleCollision(b);
                    }
                }
            }
        }

    }
}
