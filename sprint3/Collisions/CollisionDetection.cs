using System.Collections.Generic;
using System.Diagnostics;
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
using CSE3902_Project.Objects.NPC.Alien;
using sprint3.Collisions;
using sprint3.Objects.Bomb;
using sprint3.Objects.Decorations;
using CSE3902_Project.Objects.NPC.Yeti;
using CSE3902_Project.Objects.Torpedo;
using Microsoft.Xna.Framework;
using sprint3.Objects;
using CSE3902_CSE3902_Project.Commands;

namespace CSE3902_Project.Collisions
{

    public class CollisionDetection
    {
        private Game1 game;
        //private List<ICollisionChecker> checkerList;
        public Map1 map;
        public CollisionDetection(Map1 map)
        {
            this.map = map;
            //checkerList = new List<ICollisionChecker>();
        }

        private ICollisionHandler collisionHandler;
        internal NinjaStarBombCollisionHandler ICollisionHandler { get; private set; }
        
        public void Update()
        {

            /*checkerList.Add(new EnemyCollisionChecker(map));
            checkerList.Add(new ExplosionCollisionChecker(map));
            foreach (ICollisionChecker checker in checkerList)
            {
                checker.CheckCollision();
            }*/
            map.GetAllExplosions();

            CheckLandmineCollision();

            CheckTorpedoCollision();

            CheckTrapCollision();

            CheckCoinCollision();

            CheckBombCollision();

            CheckExplosionCrossCollision();

            CheckExplosionRangeCollision();

            CheckCurrentObstacleCollision();
         
            CheckEnemyCollision();

            CheckDestructableBlockCollision();
            
            CheckIndestructableBlockCollision();
            
            CheckBasicItemCollision();

            CheckExplosionCollision();

            CheckNinjaStarCollision();

            CheckPlayerPortalCollision();
        }

        private void CheckExplosionCollision()
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

        private void CheckBasicItemCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            List<BasicItem> currentItemList = map.currentItemList;
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
        }
      
        private void CheckIndestructableBlockCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            List<IndestructableBlockSprite> indestructibleBlockList = map.indestructibleBlockList;
            foreach (IndestructableBlockSprite b in indestructibleBlockList)
            {
                if (p1.collider2D.Intersects(b.collider2D))
                {
                    p1.collisionHandler = new PlayerBlockCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(b.collider2D))
                {
                    p2.collisionHandler = new PlayerBlockCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                }
            }
        }

        private void CheckDestructableBlockCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            List<DestructableBlockSprite> destructibleBlockList = map.destructibleBlockList;
            foreach (DestructableBlockSprite b in destructibleBlockList)
            {
                if (p1.collider2D.Intersects(b.collider2D))
                {
                    p1.collisionHandler = new PlayerBlockCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(b.collider2D))
                {
                    p2.collisionHandler = new PlayerBlockCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                }
            }
        }

        private void CheckEnemyCollision()
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

        private void CheckCurrentObstacleCollision()
        {
            List<ISprite> currentObstacleList = map.currentObstacleList;
            Player p1 = map.player1;
            Player p2 = map.player2;
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
                foreach (ICollideable c in map.currentEnemyList)
                {
                    if (s.collider2D.Intersects(c.GetCollider2D()))
                    {
                        collisionHandler = new ObstacleCollisionHandler();
                        collisionHandler.HandleCollision(c);
                    }
                }
            }
        }

        // explosion - bomb/obstacle interaction is complexed
        private void CheckExplosionCrossCollision() 
        {
            List<StaticBomb> staticBombList = map.staticBombList;
            List<ISprite> currentObstacleList = map.currentObstacleList;
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
                foreach (StaticBomb b in staticBombList)
                {
                    for (int i = 0; i < eCross.upExplosions.Count; i++)
                    {
                        Explosion e = eCross.upExplosions[i];
                        if (e.collider2D.Intersects(b.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.upExplosions);
                            b.collisionHandler = new BombExplosionCollisionHandler(1);
                            b.collisionHandler.HandleCollision(b);
                            break;
                        }
                    }
                    for (int i = 0; i < eCross.leftExplosions.Count; i++)
                    {
                        Explosion e = eCross.leftExplosions[i];
                        if (e.collider2D.Intersects(b.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.leftExplosions);
                            b.collisionHandler = new BombExplosionCollisionHandler(4);
                            b.collisionHandler.HandleCollision(b);
                            break;
                        }
                    }
                    for (int i = 0; i < eCross.rightExplosions.Count; i++)
                    {
                        Explosion e = eCross.rightExplosions[i];
                        if (e.collider2D.Intersects(b.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.rightExplosions);
                            b.collisionHandler = new BombExplosionCollisionHandler(2);
                            b.collisionHandler.HandleCollision(b);
                            break;
                        }
                    }
                    for (int i = 0; i < eCross.downExplosions.Count; i++)
                    {
                        Explosion e = eCross.downExplosions[i];
                        if (e.collider2D.Intersects(b.collider2D))
                        {
                            e.collisionHandler = new ExplosionObstacleCollisionHandler(i + 1);
                            e.collisionHandler.HandleCollision(eCross.downExplosions);
                            b.collisionHandler = new BombExplosionCollisionHandler(3);
                            b.collisionHandler.HandleCollision(b);
                            break;
                        }
                    }
                }
                eCross.SetAllEplosions();
            }
            map.GetAllExplosions();
        }

        private void CheckExplosionRangeCollision()
        {
            List<StaticBomb> staticBombList = map.staticBombList;
            List<ISprite> currentObstacleList = map.currentObstacleList;
            foreach (ExplosionRange eCross in map.explosionRangeList)
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
        }
        private void CheckBombCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            List<StaticBomb> staticBombList = map.staticBombList;
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
                foreach (ICollideable c in map.currentEnemyList)
                {
                    if (b.collider2D.Intersects(c.GetCollider2D()) && b.canHurtAI)
                    {
                        collisionHandler = new ObstacleCollisionHandler();
                        collisionHandler.HandleCollision(c);
                    }
                }
            }
        }

        /* Minecart functionality will be added later
        private void CheckMinecartCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            foreach (Minecart m in map.minecartList)
            {
                if (!m.playerOn)
                {
                    if (p1.collider2D.Intersects(m.collider2D))
                    {
                        p1.collisionHandler = new PlayerMinecartCollisionHandler();
                        p1.collisionHandler.HandleCollision(p1);
                    }
                    if (p2.collider2D.Intersects(m.collider2D))
                    {
                        p2.collisionHandler = new PlayerMinecartCollisionHandler();
                        p2.collisionHandler.HandleCollision(p1);
                    }
                }
                else
                {

                }
            }
        }
        */
        private void CheckTrapCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            foreach (Trap t in map.trapList)
            {
                if (!t.cooldown)
                {
                    if (p1.collider2D.Intersects(t.collider2D))
                    {
                        p1.collisionHandler = new PlayerTrapCollisionHandler();
                        p1.collisionHandler.HandleCollision(p1);
                    }
                    if (p2.collider2D.Intersects(t.collider2D))
                    {
                        p2.collisionHandler = new PlayerTrapCollisionHandler();
                        p2.collisionHandler.HandleCollision(p2);
                    }
                }
                
            }
        }

        private void CheckTorpedoCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            foreach (Torpedo t in map.torpedoList)
            {
                if (p1.collider2D.Intersects(t.collider2D) && p1 != t.player)
                {
                    p1.collisionHandler = new PlayerTorpedoCollisionHandler();
                    p1.collisionHandler.HandleCollision(t);
                    p1.collisionHandler = new PlayerTorpedoExplosionCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    map.torpedoExplosion.pos = new Vector2(p1.xPos - 30, p1.yPos - 30);
                    map.allObjects.Add(map.torpedoExplosion);
                }
                if (p2.collider2D.Intersects(t.collider2D) && p2 != t.player)
                {
                    p2.collisionHandler = new PlayerTorpedoCollisionHandler();
                    p2.collisionHandler.HandleCollision(t);
                    p2.collisionHandler = new PlayerTorpedoExplosionCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    map.torpedoExplosion.pos = new Vector2(p2.xPos - 30, p2.yPos - 30);
                    map.allObjects.Add(map.torpedoExplosion);
                }
            }
        }
        
        private void CheckLandmineCollision()
        {
            foreach (Landmine l in map.landmineList)
            {
                Player p1 = map.player1;
                Player p2 = map.player2;
                if (p1.collider2D.Intersects(l.collider2D) && p1 != l.player)
                {
                    p1.collisionHandler = new PlayerLandmineCollisionHandler();
                    p1.collisionHandler.HandleCollision(l);
                    p1.collisionHandler = new PlayerLandmineExplosionCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    map.landmineExplosion.pos = new Vector2(p1.xPos - 30, p1.yPos - 30);
                    map.allObjects.Add(map.landmineExplosion);
                }
                if (p2.collider2D.Intersects(l.collider2D) && p2 != l.player)
                {
                    p2.collisionHandler = new PlayerLandmineCollisionHandler();
                    p2.collisionHandler.HandleCollision(l);
                    p2.collisionHandler = new PlayerLandmineExplosionCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    map.landmineExplosion.pos = new Vector2(p2.xPos - 30, p2.yPos - 30);
                    map.allObjects.Add(map.landmineExplosion);
                }
            }
        }
        private void CheckCoinCollision()
        {
            foreach (Coin c in map.coinList)
            {
                Player p1 = map.player1;
                Player p2 = map.player2;
                if (p1.collider2D.Intersects(c.collider2D) )
                {
                    p1.collisionHandler = new PlayerCoinCollisionHandler();
                    p1.collisionHandler.HandleCollision(p1);
                    map.finishedCoin.Add(c);
                    Debug.WriteLine(p1.collect_coins);
                }
                if (p2.collider2D.Intersects(c.collider2D))
                {
                    p2.collisionHandler = new PlayerCoinCollisionHandler();
                    p2.collisionHandler.HandleCollision(p2);
                    map.finishedCoin.Add(c);
                }
            }
            
        }
        private void CheckNinjaStarCollision()
        {
            foreach (NinjaStar n in map.ninjaStarList)
            {
                foreach (StaticBomb b in map.staticBombList)
                {
                    if (n.collider2D.Intersects(b.collider2D))
                    {
                        ICollisionHandler = new NinjaStarBombCollisionHandler();
                        ICollisionHandler.HandleCollision2(n, b);
                    }
                }
                foreach (ISprite bl in map.currentObstacleList)
                {
                    if (n.collider2D.Intersects(bl.collider2D))
                    {
                        n.collisionHandler = new NinjaStarBlockCollisionHandler();
                        n.collisionHandler.HandleCollision(n);
                    }
                }
            }
        }
        private void CheckPlayerPortalCollision()
        {
            Player p1 = map.player1;
            Player p2 = map.player2;
            foreach (Portal p in map.portalList)
            {
                if (p1.collider2D.Intersects(p.collider2D))
                {
                    p1.collisionHandler = new PlayerPortalCollisionHandler(p);
                    p1.collisionHandler.HandleCollision(p1);
                }
                if (p2.collider2D.Intersects(p.collider2D))
                {
                    p2.collisionHandler = new PlayerPortalCollisionHandler(p);
                    p2.collisionHandler.HandleCollision(p2);
                }
            }
        }

    }
}
