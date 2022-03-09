using System.Collections.Generic;
using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_CSE3902_Project.Sprites.BlockSprites;
using CSE3902_Project.Map;
using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.NinjaStar;
using CSE3902_Project.Objects.NPC;
using CSE3902_Project.Objects.NPC.Bat;
using CSE3902_Project.Objects.NPC.Snake;
using sprint3.Objects.Bomb;

namespace CSE3902_Project.Collisions
{
    public class CollisionDetection
    {

        public Map1 map;
        public CollisionDetection(Map1 map)
        {
            this.map = map;
        }

        internal NinjaStarBombCollisionHandler ICollisionHandler { get; private set; }

        public void Update()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            //List<Explosion> exList = map.explosionList;
            List<ExplosionCross> eCrossList = map.explosionCrossList;
            map.GetAllExplosions();
            List<Explosion> explosionList;
            List<ISprite> enemyList = map.currentEnemyList;
            List<StaticBomb> staticBombList = map.staticBombList;
            List<DestructableBlockSprite> destructibleBlockList = map.destructibleBlockList;
            List<IndestructableBlockSprite> indestructibleBlockList = map.indestructibleBlockList;
            List<ISprite> currentObstacleList = map.currentObstacleList;
            List<BasicItem> currentItemList = map.currentItemList;
            List<NinjaStar> currentNinjaStar = map.ninjaStarList;
            
            if (p1.collider2D.Intersects(p2.collider2D))
            {
                p1.collisionHandler = new PlayerBlockCollisionHandler();
                p1.collisionHandler.HandleCollision(p1);
                p2.collisionHandler = new PlayerBlockCollisionHandler();
                p2.collisionHandler.HandleCollision(p2);
            }

            foreach (StaticBomb b in staticBombList)
            {
                if (p1.collider2D.Intersects(b.collider2D))
                {
                    p1.collisionHandler = new PlayerBombCollisionHandler(b);
                    p1.collisionHandler.HandleCollision(p1);
                }

                if (p2.collider2D.Intersects(b.collider2D))
                {
                    p2.collisionHandler = new PlayerBombCollisionHandler(b);
                    p2.collisionHandler.HandleCollision(p2);
                }

                foreach (Bat bt in map.batList)
                {
                    if (b.collider2D.Intersects(bt.collider2D))
                    {
                        bt.collisionHandler = new BatCollisionHandler();
                        bt.collisionHandler.HandleCollision(bt);
                    }
                }

                foreach (Snake s in map.snakeList)
                {
                    if (b.collider2D.Intersects(s.collider2D))
                    {
                        s.collisionHandler = new SnakeCollisionHandler();
                        s.collisionHandler.HandleCollision(s);
                    }
                }
            }
            foreach (ExplosionCross eCross in map.explosionCrossList)
            {
                foreach (ISprite o in currentObstacleList)
                {
                    for (int i = 0; i < eCross.upExplosions.Count; i++)
                    {
                        Explosion e = eCross.upExplosions[i];
                        if (e.collider2D.Intersects(o.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.upExplosions);
                            break;
                        }
                    }
                    for (int i = 0; i < eCross.leftExplosions.Count; i++)
                    {
                        Explosion e = eCross.leftExplosions[i];
                        if (e.collider2D.Intersects(o.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.leftExplosions);
                            break;
                        }
                    }
                    for (int i = 0; i < eCross.rightExplosions.Count; i++)
                    {
                        Explosion e = eCross.rightExplosions[i];
                        if (e.collider2D.Intersects(o.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.rightExplosions);
                            break;
                        }
                    }
                    for (int i = 0; i < eCross.downExplosions.Count; i++)
                    {
                        Explosion e = eCross.downExplosions[i];
                        if (e.collider2D.Intersects(o.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.downExplosions);
                            break;
                        }
                    }
                }
                eCross.SetAllEplosions();
            }
            map.GetAllExplosions();
            explosionList = map.allExplosionsList;
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
                foreach (Bat b in map.batList)
                {
                    if (b.collider2D.Intersects(s.collider2D))
                    {
                        b.collisionHandler = new BatCollisionHandler();
                        b.collisionHandler.HandleCollision(b);
                    }
                }
                foreach (Snake sn in map.snakeList)
                {
                    if (sn.collider2D.Intersects(s.collider2D))
                    {
                        sn.collisionHandler = new SnakeCollisionHandler();
                        sn.collisionHandler.HandleCollision(sn);
                    }
                }
            }

            foreach(Bat b in map.batList)
            {
                if (p1.collider2D.Intersects(b.collider2D))
                {
                    p1.collisionHandler = new PlayerBlockCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    b.collisionHandler = new BatCollisionHandler();
                    b.collisionHandler.HandleCollision(b);                        
                   
                }

                if (p2.collider2D.Intersects(b.collider2D))
                {
                    p2.collisionHandler = new PlayerBlockCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    b.collisionHandler = new BatCollisionHandler();
                    b.collisionHandler.HandleCollision(b);
                }
            }

            foreach (Snake s in map.snakeList)
            {
                if (p1.collider2D.Intersects(s.collider2D))
                {
                    p1.collisionHandler = new PlayerBlockCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    s.collisionHandler = new SnakeCollisionHandler();
                    s.collisionHandler.HandleCollision(s);
                    p1.speed = p1.speed - 0.01f;
                }

                if (p2.collider2D.Intersects(s.collider2D))
                {
                    p2.collisionHandler = new PlayerBlockCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    s.collisionHandler = new SnakeCollisionHandler();
                    s.collisionHandler.HandleCollision(s);
                    p2.speed = p2.speed - 0.01f;
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
            
            foreach (BasicItem item in currentItemList)
            {
                if (p1.collider2D.Intersects(item.collider2D))
                {
                    p1.collisionHandler = new PlayerItemCollisionHandler();
                    p1.collisionHandler.HandleCollision(item);
                    item.collisionHandler = new ItemPlayerCollisionHandler(p1);
                    item.collisionHandler.HandleCollision(item);
                }
                if (p2.collider2D.Intersects(item.collider2D))
                {
                    p2.collisionHandler = new PlayerItemCollisionHandler();
                    p2.collisionHandler.HandleCollision(item);
                    item.collisionHandler = new ItemPlayerCollisionHandler(p2);
                    item.collisionHandler.HandleCollision(item);
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

            foreach (Explosion e in explosionList)
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
                foreach (Bat b in map.batList)
                {
                    if (e.collider2D.Intersects(b.collider2D))
                    {
                        b.collisionHandler = new BatExplosionCollisionHandler();
                        b.collisionHandler.HandleCollision(b);
                    }
                }
                foreach (Snake s in map.snakeList)
                {
                    if (e.collider2D.Intersects(s.collider2D))
                    {
                        s.collisionHandler = new SnakeExplosionCollisionHandler();
                        s.collisionHandler.HandleCollision(s);
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
            foreach (NinjaStar n in currentNinjaStar)
            {
                foreach (StaticBomb b in staticBombList)
                {
                    if (n.collider2D.Intersects(b.collider2D))
                    {
                        ICollisionHandler = new NinjaStarBombCollisionHandler();
                        ICollisionHandler.HandleCollision2(n, b);

                        //(e.collisionHandler as ExplosionBombCollisionHandler).HandleCollision(e);


                        //(b.collisionHandler as BombExplosionCollisionHandler).HandleCollision(b);
                    }
                }
                foreach (ISprite bl in currentObstacleList)
                {
                    if (n.collider2D.Intersects(bl.collider2D))
                    {
                        n.collisionHandler = new NinjaStarBlockCollisionHandler();
                        n.collisionHandler.HandleCollision(n);
                        //(p1.collisionHandler as PlayerBlockCollisionHandler).HandleCollision(p1);
                    }
                }
            }       
        }

    }
}
