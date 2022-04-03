using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_CSE3902_Project.Sprites.BlockSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Audio;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.NPC.Bat;
using CSE3902_Project.Objects.NPC.Snake;
using CSE3902_Project.Objects.NPC.Alien;
using CSE3902_Project.Sprites.Decorations;
using CSE3902_Project.Objects.NinjaStar;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using sprint3.Objects.Bomb;
using sprint3.Map;
using sprint3.Sprites.Decorations;
using System.Diagnostics;
using CSE3902_Project.Objects.NPC.Yeti;
using CSE3902_Project.Objects.NPC;
using sprint3.Objects.Decorations;
using CSE3902_Project.Objects.Torpedo;
namespace CSE3902_Project.Map
{
    public class Map1
    {
        
        private Game1 game;
        private Map m2;
        public int mapIndex;
        public CollisionDetection collisionDetection;
        public TileMap tileMap;
        public int Timeplayed;
        public int score;
        public CoinsController coinsController;
        //int TimeofGame = 0;
        //Boolean isPaused = false;

        private Background1 background;
        public Hud1 hud;
        public GraphicsDeviceManager graphics;

        public Player player1;
        public Player player2;
        public Bat horizontalBat;
        public Bat verticalBat;
        public Snake snake;
        public Yeti yeti;
        public Alien alien;

        public NinjaStar ninjastar;
        public DestructableBlockSprite dBlock;
        public IndestructableBlockSprite iBlock;
        public Tree1 tree1;
        public Tree2 tree2;
        public Mashroom1 mashroom1;
        public Torpedo torpedo;
        public TorpedoExplosion torpedoExplosion;
        public Trap trap;

        public BasicItem bombItem;
        public BasicItem ghostItem;
        public BasicItem goblinItem;
        public BasicItem knightItem;
        public BasicItem ninjasStarItem;
        public BasicItem potionItem;
        public BasicItem shoeItem;
        public BasicItem torpedoItem;

        public List<ExplosionCross> explosionCrossList;
        public List<ExplosionCross> finishedExplosionCross;
        public List<Explosion> allExplosionsList;
        public List<StaticBomb> staticBombList;
        public List<StaticBomb> finishedBombs;
        public List<NinjaStar> finishedNinjaStar;
        public List<ISprite> finishedObstacles;
        public List<Torpedo> finishedTorpedo;


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
        public List<BasicItem> finishedItems;

        public List<ISprite> currentObstacleList;

        public List<DestructableBlockSprite> destructibleBlockList;
        public List<IndestructableBlockSprite> indestructibleBlockList;

        public List<Snake> snakeList;
        public List<Bat> batList;
        public List<Yeti> yetiList;
        public List<Trap> trapList;
        public List<NinjaStar> ninjaStarList;
        public List<Torpedo> torpedoList;
        public List<ISprite> currentEnemyList;
       
        static Random rnd = new Random();

        public List<ISprite> allObjects;
        public List<ISprite> finishedObjects;

        public Portal portalA;
        public Portal portalB;
        public Minecart minecart;
        public Coin coin;
        public List<Portal> portalList;
        public List<Minecart> minecartList;
        public List<Vector2> coinPosList;
        public List<Coin> coinList;
        public Map1(Game1 game, int mapIndex, Map m2)
        {
            this.game = game;
            this.m2 = m2;
            this.mapIndex = mapIndex;
            graphics = game.graphics;
        }
        public class Map
        {
            public List<int> player1;
            public List<int> player2;
            public Dictionary<String,List<int>> destructableBlocks;
            public Dictionary<String, List<int>> indestructableBlocks;
            public Dictionary<String, List<int>> snakes;
            public Dictionary<String, List<int>> bats;
            public Dictionary<String, List<int>> aliens;
            public Dictionary<String, List<int>> yetis;
            public Dictionary<String, List<int>> portals;
            public Dictionary<String, List<int>> mushrooms;
            public Dictionary<String, List<int>> tree1;
            public Dictionary<String, List<int>> tree2;
            public Dictionary<String, List<int>> traps;
            public Dictionary<String, List<int>> minecarts;
            public Dictionary<String, List<int>> coins;
        }
        public void Initialize()
        {
            torpedoExplosion = new TorpedoExplosion(game, new Vector2(100, 100));
            //TODO change in the future
            //currentGameState = GameState.GamePlay;*/
            /*            Map m2;
                        string map_name =  "content\\initial_map" + game.map_index.ToString() + ".json";
                        using (StreamReader file = File.OpenText(map_name))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            m2 = (Map)serializer.Deserialize(file, typeof(Map));
                        }*/

            collisionDetection = new CollisionDetection(this);
            tileMap = new TileMap(game);
            coinsController = new CoinsController(game,this);
            background = new Background1(new Vector2(0, 0), mapIndex);
            hud = new Hud1(new Vector2(0, 480), this);
/*            player1 = new Player(new Vector2(m2.player1[0], m2.player1[1]), game);
            player2 = new Player(new Vector2(m2.player2[0], m2.player2[1]), game);*/

            staticBombList = new List<StaticBomb>();
            explosionCrossList = new List<ExplosionCross>();
            ninjaStarList = new List<NinjaStar>();
            torpedoList = new List<Torpedo>();
            destructibleBlockList = new List<DestructableBlockSprite>();
            indestructibleBlockList = new List<IndestructableBlockSprite>();
            portalList = new List<Portal>();
            minecartList = new List<Minecart>();
            coinList = new List<Coin>();
            coinPosList = new List<Vector2>();
            /*            verticalBat = new Bat(new Vector2(400, 140), game);
                        horizontalBat = new Bat(new Vector2(400, 380), game);
                        horizontalBat.currState = new BatFacingEastState(horizontalBat);     */

            // tree1 = new Tree1(new Vector2(330, 250));
            // tree2 = new Tree2(new Vector2(370, 250));
            mashroom1 = new Mashroom1(new Vector2(300, 300));

            // spawn all items initially for testing purposes
            bombItem = new BombItem(new Vector2(150, 400), game);
            ghostItem = new GhostItem(new Vector2(185, 400), game);
            goblinItem = new GoblinItem(new Vector2(220, 400), game);
            knightItem = new KnightItem(new Vector2(255, 400), game);
            ninjasStarItem = new NinjaStarItem(new Vector2(290, 400), game);
            potionItem = new PotionItem(new Vector2(325, 400), game);
            shoeItem = new ShoeItem(new Vector2(360, 400), game);
            torpedoItem = new TorpedoItem(new Vector2(405, 400), game);
            trap = new Trap(new Vector2(10, 10), game);
            currentItemList = new List<BasicItem>();
            currentItemList.Add(bombItem);
            currentItemList.Add(ghostItem);
            currentItemList.Add(goblinItem);
            currentItemList.Add(knightItem);
            currentItemList.Add(ninjasStarItem);
            currentItemList.Add(potionItem);
            currentItemList.Add(shoeItem);
            currentItemList.Add(torpedoItem);

            currentObstacleList = new List<ISprite>();
            
            //currentObstacleList.Add(tree1);
            //currentObstacleList.Add(tree2);
            currentObstacleList.Add(mashroom1);

            snakeList = new List<Snake>();
            
            batList = new List<Bat>();

            yetiList = new List<Yeti>();
            trapList = new List<Trap>();
            currentEnemyList = new List<ISprite>();
/*            currentEnemyList.Add(verticalBat);
            currentEnemyList.Add(horizontalBat);*/

            /*            portalA = new Portal(new Vector2(0, 240), game);
                        portalB = new Portal(new Vector2(770, 240), game);*/

            /*            foreach (List<int> pos in m2.tree1.Values)
                        {
                            tree1 = (new Tree1(new Vector2(pos[0], pos[1])));
                            currentObstacleList.Add(tree1);
                        }
                        foreach (List<int> pos in m2.tree2.Values)
                        {
                            tree2 = (new Tree2(new Vector2(pos[0], pos[1])));
                            currentObstacleList.Add(tree2);
                        }

                        foreach (List<int> pos in m2.destructableBlocks.Values){
                            dBlock = (new DestructableBlockSprite(game, mapIndex, new Vector2(pos[0], pos[1])));
                            destructibleBlockList.Add(dBlock);
                            currentObstacleList.Add(dBlock);
                        }
                        foreach (List<int> pos in m2.indestructableBlocks.Values)
                        {
                            iBlock = new IndestructableBlockSprite(new Vector2(pos[0], pos[1]), mapIndex);
                            currentObstacleList.Add(iBlock);
                            indestructibleBlockList.Add(iBlock);
                        }
                        foreach (List<int> pos in m2.snakes.Values)
                        {
                            snake = new Snake(new Vector2(pos[0], pos[1]), game);
                            snakeList.Add(snake);
                            currentEnemyList.Add(snake);
                        }
                        foreach (List<int> pos in m2.portals.Values)
                        {
                            portalA = new Portal(new Vector2(pos[0], pos[1]), game);
                            portalList.Add(portalA);
                        }*/
            LoadFromJson();
            // change some bats to move horizontally
            for (int i = 0; i < batList.Count; i++)
            {
                if (i % 2 == 1)
                {
                    batList[i].currState = new BatFacingEastState(batList[i]);
                }
            }
            // set "other" portal references
            if (portalList.Count != 0)
            {
                portalList[0].SetOtherPortal(portalList[1]);
                portalList[1].SetOtherPortal(portalList[0]);
            }
            
/*            Yeti yeti = new Yeti(new Vector2(700, 400), game);
            Yeti yeti2 = new Yeti(new Vector2(0, 200), game);
            yeti2.currState = new YetiFacingEastState(yeti2);*/
            //alien testing, can adjust later
            alien = new Alien(new Vector2(1100, 400), game);
/*            currentEnemyList.Add(yeti);
            currentEnemyList.Add(yeti2);*/
            currentEnemyList.Add(alien);

            GetAllExplosions();

            allObjects = new List<ISprite>();
            allObjects.Add(background);
            allObjects.Add(player1);
            allObjects.Add(player2);
            allObjects.AddRange(torpedoList);
            allObjects.AddRange(staticBombList);
            allObjects.AddRange(currentEnemyList);
            allObjects.AddRange(currentObstacleList);
            allObjects.AddRange(explosionCrossList);
            allObjects.AddRange(currentItemList);
            allObjects.AddRange(portalList);
            allObjects.AddRange(trapList);
            allObjects.AddRange(minecartList);
            allObjects.AddRange(coinList);

            AudioManager.Instance.PlayMainMusic();
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
            finishedTorpedo = new List<Torpedo>();
            coinsController.Update();
            for (int i = allObjects.Count - 1; i > -1; i--)
            {
                ISprite s = allObjects[i];
                s.Update();
            }
            hud.Update();
            collisionDetection.Update();

            RemoveFinishedItems();
            SpawnItems();

            // players kept getting stuck - update previous position after collision checks
            GetAllExplosions();
            player1.UpdatePreviousPosition();
            player2.UpdatePreviousPosition();
            foreach (IEnemyState e in currentEnemyList)
            {
                e.UpdatePreviousPosition();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite s in allObjects)
            {
                s.Draw(spriteBatch);
            }
            Debug.WriteLine(player1.inventory["bomb"]);
            hud.Draw(spriteBatch);
        }

        private void LoadFromJson()
        {
            player1 = new Player(new Vector2(m2.player1[0], m2.player1[1]), game);
            player2 = new Player(new Vector2(m2.player2[0], m2.player2[1]), game);
            foreach (List<int> pos in m2.tree1.Values)
            {
                tree1 = (new Tree1(new Vector2(pos[0], pos[1])));
                currentObstacleList.Add(tree1);
            }
            foreach (List<int> pos in m2.tree2.Values)
            {
                tree2 = (new Tree2(new Vector2(pos[0], pos[1])));
                currentObstacleList.Add(tree2);
            }

            foreach (List<int> pos in m2.destructableBlocks.Values)
            {
                dBlock = (new DestructableBlockSprite(game, mapIndex, new Vector2(pos[0], pos[1])));
                destructibleBlockList.Add(dBlock);
                currentObstacleList.Add(dBlock);
            }
            foreach (List<int> pos in m2.indestructableBlocks.Values)
            {
                iBlock = new IndestructableBlockSprite(new Vector2(pos[0], pos[1]), mapIndex);
                currentObstacleList.Add(iBlock);
                indestructibleBlockList.Add(iBlock);
            }
            foreach (List<int> pos in m2.snakes.Values)
            {
                snake = new Snake(new Vector2(pos[0], pos[1]), game);
                snakeList.Add(snake);
                currentEnemyList.Add(snake);
            }
            foreach (List<int> pos in m2.portals.Values)
            {
                portalA = new Portal(new Vector2(pos[0], pos[1]), game);
                portalList.Add(portalA);
            }
            foreach (List<int> pos in m2.bats.Values)
            {
                verticalBat = new Bat(new Vector2(pos[0], pos[1]), game);
                batList.Add(verticalBat);
                currentEnemyList.Add(verticalBat);
            }
            foreach (List<int> pos in m2.yetis.Values)
            {
                yeti = new Yeti(new Vector2(pos[0], pos[1]), game);
                yetiList.Add(yeti);
                currentEnemyList.Add(yeti);
            }
            foreach (List<int> pos in m2.traps.Values)
            {
                trap = new Trap(new Vector2(pos[0], pos[1]), game);
                trapList.Add(trap);
             }
            foreach (List<int> pos in m2.minecarts.Values)
            {
                minecart = new Minecart(new Vector2(pos[0], pos[1]), game);
                minecartList.Add(minecart);
            }
            foreach (List<int> pos in m2.coins.Values)
            {
                coin = new Coin(new Vector2(pos[0], pos[1]), game);
                coinList.Add(coin);
                coinPosList.Add(new Vector2(pos[0], pos[1]));
            }
        }

        public void AddBomb(Player player, Vector2 pos)
        {

            if (staticBombList.Count < 10)
            {
                AudioManager.Instance.PlayBombThrown();
                StaticBomb newBomb = new StaticBomb(game, player, pos);
                staticBombList.Add(newBomb);
                allObjects.Add(newBomb);
            }
        }

        public void AddExplosions(Vector2 pos, int potionCount, int direction)
        {
            ExplosionCross eCross = new ExplosionCross(game);
            AudioManager.Instance.PlayBombExplosion();
            int xOffset = 0;
            int yOffset = 0;
            int x = (int)pos.X;
            int y = (int)pos.Y;
            if (direction == 0) eCross.originExplosion.Add(new Explosion(game, new Vector2(x + xOffset, y + yOffset)));
            // radius in each direction
            for (int i = 1; i < potionCount; i++)
            {
                if (direction != 4) eCross.rightExplosions.Add(new Explosion(game, new Vector2(xOffset + 40 * i + x, yOffset + y)));
                if (direction != 2) eCross.leftExplosions.Add(new Explosion(game, new Vector2(xOffset + x - (40 * i), yOffset + y)));
                if (direction != 3) eCross.upExplosions.Add(new Explosion(game, new Vector2(xOffset + x, yOffset + 40 * i + y)));
                if (direction != 1) eCross.downExplosions.Add(new Explosion(game, new Vector2(xOffset + x, yOffset + y - (40 * i))));
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

        public void AddTorpedo(Player p)
        {
            Torpedo newTorpedo = new Torpedo(p);
            torpedoList.Add(newTorpedo);
            allObjects.Add(newTorpedo);
        }

        public void AddItem(Vector2 pos)
        {
            BasicItem newItem = null;
            int rand = rnd.Next(1, 15);
            // normal items (3x as frequent spawn)
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
                    case 13:
                        newItem = new NinjaStarItem(pos, game);
                        break;
                        // nothing spawns
                    case 14:
                        break;
                    default:
                        break;
                }
            }
            if (newItem != null) itemsToSpawn.Add(newItem);
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
  
        public void RemoveFinishedItems()
        {
            foreach (Torpedo t in finishedTorpedo)
            {
                torpedoList.Remove(t);
                finishedObjects.Add(t);
            }
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
        }
    }
}
