using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_CSE3902_Project.Sprites.BlockSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.NPC.Bat;
using CSE3902_Project.Objects.NPC.Snake;
using CSE3902_Project.Sprites.Decorations;
using CSE3902_Project.Objects.NinjaStar;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using sprint3.Objects.Bomb;
using sprint3.Map;

namespace CSE3902_Project.Map
{
    public class Map1
    {
        
        private Game1 game;
        public CollisionDetection collisionDetection;
        public TileMap tileMap;
        public int Timeplayed;
        public int score;              
        //int TimeofGame = 0;
        //Boolean isPaused = false;

        private Background1 background;
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public Player player1;
        public Player player2;
        public Bat horizontalBat;
        public Bat verticalBat;
        public Snake snake;
        public NinjaStar ninjastar;
        public DestructableBlockSprite dBlock;
        public IndestructableBlockSprite iBlock;
        public Tree1 tree1;
        public Tree2 tree2;

        public BasicItem bombItem;
        public BasicItem ghostItem;
        public BasicItem goblinItem;
        public BasicItem knightItem;
        public BasicItem ninjasStarItem;
        public BasicItem potionItem;
        public BasicItem shoeItem;

        public List<ExplosionCross> explosionCrossList;
        public List<ExplosionCross> finishedExplosionCross;
        public List<Explosion> allExplosionsList;
        public List<StaticBomb> staticBombList;
        public List<StaticBomb> finishedBombs;
        public List<NinjaStar> finishedNinjaStar;
        public List<ISprite> finishedObstacles;

        public List<BasicItem> itemsToSpawn;
        /*        GameState currentGameState;
                enum GameState
                {
                    GameMenu = 0,
                    GamePlay = 1,
                    GameOver = 2,
                    GamePause = 3,
                }*/

        //private Vector2 screenSize;

        public List<BasicItem> currentItemList;
        public int currItemIndex = 0;
        public List<BasicItem> finishedItems;

        public List<ISprite> currentObstacleList;
        public int currObstacleIndex = 0;

        public List<DestructableBlockSprite> destructibleBlockList;
        public List<IndestructableBlockSprite> indestructibleBlockList;

        public List<Snake> snakeList;
        public List<Bat> batList;
        public List<NinjaStar> ninjaStarList;
        public List<ISprite> currentEnemyList;
        public int currEnemyIndex = 0;
        static Random rnd = new Random();

        public List<ISprite> allObjects;
        public List<ISprite> finishedObjects;
        public ISprite testBat;
        public Map1(Game1 game)
        {
            this.game = game;
            spriteBatch = game.spriteBatch;
            graphics = game.graphics;
        }
        public class Map
        {
            public List<int> player1;
            public List<int> player2;
            public Dictionary<String,List<int>> destructableBlocks;
            public Dictionary<String, List<int>> indestructableBlocks;
            public Dictionary<String, List<int>> snakes;
        }
        public void Initialize()
        {
            //TODO change in the future
            //currentGameState = GameState.GamePlay;*/
            Map m2;
            string map_name =  "content\\initial_map" + game.map_index.ToString() + ".json";
            using (StreamReader file = File.OpenText(map_name))
            {
                JsonSerializer serializer = new JsonSerializer();
                m2 = (Map)serializer.Deserialize(file, typeof(Map));
            }
            
            collisionDetection = new CollisionDetection(this);
            tileMap = new TileMap(game);

            background = new Background1(new Vector2(0, 0));
            player1 = new Player(new Vector2(m2.player1[0], m2.player1[1]), game);
            player2 = new Player(new Vector2(m2.player2[0], m2.player2[1]), game);

            staticBombList = new List<StaticBomb>();
            explosionCrossList = new List<ExplosionCross>();
            ninjaStarList = new List<NinjaStar>();
            destructibleBlockList = new List<DestructableBlockSprite>();
            indestructibleBlockList = new List<IndestructableBlockSprite>();

            verticalBat = new Bat(new Vector2(400, 140), game);
            horizontalBat = new Bat(new Vector2(400, 380), game);
            horizontalBat.currState = new BatFacingEastState(horizontalBat);        
         
            tree1 = new Tree1(new Vector2(330, 250));
            tree2 = new Tree2(new Vector2(370, 250));

            // spawn all items initially for testing purposes
            bombItem = new BombItem(new Vector2(150, 100), game);
            ghostItem = new GhostItem(new Vector2(185, 100), game);
            goblinItem = new GoblinItem(new Vector2(220, 100), game);
            knightItem = new KnightItem(new Vector2(255, 100), game);
            ninjasStarItem = new NinjaStarItem(new Vector2(290, 100), game);
            potionItem = new PotionItem(new Vector2(325, 100), game);
            shoeItem = new ShoeItem(new Vector2(360, 100), game);

            currentItemList = new List<BasicItem>();
            currentItemList.Add(bombItem);
            currentItemList.Add(ghostItem);
            currentItemList.Add(goblinItem);
            currentItemList.Add(knightItem);
            currentItemList.Add(ninjasStarItem);
            currentItemList.Add(potionItem);
            currentItemList.Add(shoeItem);

            currentObstacleList = new List<ISprite>();
            
            currentObstacleList.Add(tree1);
            currentObstacleList.Add(tree2);

            snakeList = new List<Snake>();
            
            batList = new List<Bat>();
            batList.Add(horizontalBat);
            batList.Add(verticalBat);

            currentEnemyList = new List<ISprite>();
            currentEnemyList.Add(verticalBat);
            currentEnemyList.Add(horizontalBat);
            

            foreach (List<int> pos in m2.destructableBlocks.Values){
                dBlock = (new DestructableBlockSprite(game, new Vector2(pos[0], pos[1])));
                destructibleBlockList.Add(dBlock);
                currentObstacleList.Add(dBlock);
            }

            foreach (List<int> pos in m2.indestructableBlocks.Values)
            {
                iBlock = new IndestructableBlockSprite(new Vector2(pos[0], pos[1]));
                currentObstacleList.Add(iBlock);
                indestructibleBlockList.Add(iBlock);
            }
            foreach (List<int> pos in m2.snakes.Values)
            {
                snake = new Snake(new Vector2(pos[0], pos[1]), game);
                snakeList.Add(snake);
                currentEnemyList.Add(snake);
            }
            GetAllExplosions();

            allObjects = new List<ISprite>();
            allObjects.Add(background);
            allObjects.Add(player1);
            allObjects.Add(player2);
            allObjects.AddRange(staticBombList);
            allObjects.AddRange(currentEnemyList);
            allObjects.AddRange(currentObstacleList);
            allObjects.AddRange(explosionCrossList);
            allObjects.AddRange(currentItemList);
        }

        public void Update()
        {
            finishedObjects = new List<ISprite>();
            finishedBombs = new List<StaticBomb>();
            finishedExplosionCross = new List<ExplosionCross>();
            finishedItems = new List<BasicItem>();
            finishedNinjaStar = new List<NinjaStar>();
            finishedObstacles = new List<ISprite>();
            itemsToSpawn = new List<BasicItem>();

            for (int i = allObjects.Count - 1; i > -1; i--)
            {
                ISprite s = allObjects[i];
                s.Update();
            }
            /*            background.Update();
                        player1.Update();
                        player2.Update();
                        foreach (ISprite s in allObjects)
                        {
                            s.Update();
                        }
                        finishedItems = new List<BasicItem>();
                        itemsToSpawn = new List<BasicItem>();
                        foreach (BasicItem i in currentItemList)
                        {
                            i.Update();
                        }
                        finishedObstacles = new List<ISprite>();
                        foreach (ISprite s in currentObstacleList)
                        {
                            s.Update();
                        }

                        foreach (IEnemyState e in currentEnemyList)
                        {
                            e.Update();
                        }

                        finishedBombs = new List<StaticBomb>();
                        foreach (StaticBomb s in staticBombList)
                        {
                            s.Update();
                        }

                        finishedExplosionCross = new List<ExplosionCross>();

                        foreach (ExplosionCross e in explosionCrossList)
                        {
                            e.Update();
                        }

                        finishedNinjaStar = new List<NinjaStar>();

                        foreach (NinjaStar n in ninjaStarList)
                        {
                            n.Update();
                            if (!n.exist)
                            {
                                finishedNinjaStar.Add(n);
                            }
                        }

                        collisionDetection.Update();
            *//*            foreach (Explosion e in finishedExplosions)
                        {
                            explosionList.Remove(e);
                        }*//* */
            collisionDetection.Update();

            foreach (ExplosionCross e in finishedExplosionCross)
            {
                explosionCrossList.Remove(e);
                finishedObjects.Add(e);
            }
            foreach (NinjaStar n in finishedNinjaStar)
            {
                ninjaStarList.Remove(n);
                finishedObjects.Add(n);
            }
            foreach (BasicItem i in finishedItems)
            {
                currentItemList.Remove(i);
                finishedObjects.Add(i);
            }
            foreach (StaticBomb s in finishedBombs)
            {
                staticBombList.Remove(s);
                finishedObjects.Add(s);
            }
            foreach (ISprite s in finishedObstacles)
            {
                destructibleBlockList.Remove(s as DestructableBlockSprite);
                currentObstacleList.Remove(s);
                finishedObjects.Add(s);
            }
            foreach (ExplosionCross e in explosionCrossList)
            {
                e.SetAllEplosions();
            }
            foreach (ISprite s in finishedObjects)
            {
                allObjects.Remove(s);
            }

            SpawnItems();

            // players kept getting stuck - update previous position after collision checks
            GetAllExplosions();
            player1.UpdatePreviousPosition();
            player2.UpdatePreviousPosition();
            (currentEnemyList[0] as Bat).UpdatePreviousPosition();
            (currentEnemyList[1] as Bat).UpdatePreviousPosition();
            (currentEnemyList[2] as Snake).UpdatePreviousPosition();
        }

        public void Draw()
        {
            /*            background.Draw(spriteBatch);
                        player1.Draw(spriteBatch);
                        player2.Draw(spriteBatch);
                        foreach (ISprite s in allObjects)
                        {
                            s.Draw(spriteBatch);
                        }
                        foreach (BasicItem i in currentItemList)
                        {
                            i.Draw(spriteBatch);
                        }

                        foreach (ISprite s in currentObstacleList)
                        {
                            s.Draw(spriteBatch);
                        }

                        foreach (IEnemyState e in currentEnemyList)
                        {
                            e.Draw(spriteBatch);
                        }

                        foreach (StaticBomb s in staticBombList)
                        {
                            s.Draw(spriteBatch);
                        }

                        foreach (ExplosionCross e in explosionCrossList)
                        {
                            e.Draw(spriteBatch);
                        }
                        foreach (NinjaStar n in ninjaStarList)
                        {
                            n.DrawSprite(spriteBatch);
                        }*/
            foreach (ISprite s in allObjects)
            {
                s.Draw(spriteBatch);
            }
        }

        public void AddBomb(Player player, Vector2 pos)
        {
            if (staticBombList.Count < 10)
            {
                StaticBomb newBomb = new StaticBomb(game, player, pos);
                staticBombList.Add(newBomb);
                allObjects.Add(newBomb);
            }
        }

        public void AddExplosions(Vector2 pos, int potionCount)
        {
            ExplosionCross eCross = new ExplosionCross(game);

            int xOffset = 0;
            int yOffset = 0;
            int x = (int)pos.X;
            int y = (int)pos.Y;
            eCross.originExplosion = new Explosion(game, new Vector2(x + xOffset, y + yOffset));
            // radius in each direction
            for (int i = 1; i < potionCount; i++)
            {
                eCross.rightExplosions.Add(new Explosion(game, new Vector2(xOffset + 40 * i + x, yOffset + y)));
                eCross.leftExplosions.Add(new Explosion(game, new Vector2(xOffset + x - (40 * i), yOffset + y)));
                eCross.upExplosions.Add(new Explosion(game, new Vector2(xOffset + x, yOffset + 40 * i + y)));
                eCross.downExplosions.Add(new Explosion(game, new Vector2(xOffset + x, yOffset + y - (40 * i))));
            }
            eCross.SetAllEplosions();
            explosionCrossList.Add(eCross);
            allObjects.Add(eCross);
        }
        public void AddNinjaStar(Player p)
        {
            NinjaStar newStar = new NinjaStar(p);
            ninjaStarList.Add(newStar);
            allObjects.Add(newStar);
        }

        public void AddItem(Vector2 pos)
        {
            BasicItem newItem;
            int rand = rnd.Next(1, 13);
            // normal items (twice as frequent spawn)
            if (rand < 10)
            {
                switch (rand % 3)
                {
                    case 0:
                        newItem = new BombItem(pos, game);
                        break;
                    case 1:
                        newItem = new PotionItem(pos, game);
                        break;
                    case 2:
                        newItem = new ShoeItem(pos, game);
                        break;
                    default:
                        newItem = new BombItem(pos, game);
                        break;
                }
            }
            // special items (changes character sprite)
            else
            {
                switch (rand)
                {
                    case 10:
                        newItem = new GoblinItem(pos, game);
                        break;
                    case 11:
                        newItem = new KnightItem(pos, game);
                        break;
                    case 12:
                        newItem = new GhostItem(pos, game);
                        break;
                    default:
                        newItem = new BombItem(pos, game);
                        break;
                }
            }
            itemsToSpawn.Add(newItem);
        }

        public void SpawnItems()
        {
            foreach (BasicItem i in itemsToSpawn)
            {
                currentItemList.Add(i);
                allObjects.Add(i);
            }
        }

        public void GetAllExplosions()
        {
            allExplosionsList = new List<Explosion>();
            foreach (ExplosionCross e in explosionCrossList)
            {
                allExplosionsList.AddRange(e.allExplosions);
            }
        }
    }
}
