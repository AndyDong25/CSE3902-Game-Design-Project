using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_CSE3902_Project.Sprites.BlockSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.NPC;
using CSE3902_Project.Objects.NPC.Bat;
using CSE3902_Project.Objects.NPC.Snake;
using CSE3902_Project.Sprites.Decorations;
using CSE3902_Project.Objects.NinjaStar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace CSE3902_Project.Map
{
    public class Map1
    {
        
        private Game1 game;
        public CollisionDetection collisionDetection;
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
        public Enemy enemy;
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

        public List<Explosion> explosionList;
        public List<Explosion> finishedExplosions;
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

        public List<Enemy> enemyList;
        public List<Snake> snakeList;
        public List<Bat> batList;
        public List<NinjaStar> ninjaStarList;
        public List<IEnemyState> currentEnemyList;
        public int currEnemyIndex = 0;

        static Random rnd = new Random();

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
            using (StreamReader file = File.OpenText(@"content\json_data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                m2 = (Map)serializer.Deserialize(file, typeof(Map));
            }
            
            collisionDetection = new CollisionDetection(this);

            background = new Background1();
            player1 = new Player(new Vector2(m2.player1[0], m2.player1[1]), game);
            player2 = new Player(new Vector2(m2.player2[0], m2.player2[1]), game);
            
            staticBombList = new List<StaticBomb>();
            explosionList = new List<Explosion>();
            ninjaStarList = new List<NinjaStar>();
            destructibleBlockList = new List<DestructableBlockSprite>();
            indestructibleBlockList = new List<IndestructableBlockSprite>();

/*            explosionList = player1.staticBomb.explosionList;
            explosionList.AddRange(player2.staticBomb.explosionList);*/

            enemy = new Enemy(new Vector2(450, 300), game);
            verticalBat = new Bat(new Vector2(400, 140), game);
            horizontalBat = new Bat(new Vector2(400, 380), game);
            horizontalBat.currState = new BatFacingEastState(horizontalBat);        
         
            tree1 = new Tree1(new Vector2(330, 250));
            tree2 = new Tree2(new Vector2(370, 250));

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

            enemyList = new List<Enemy>();
            enemyList.Add(enemy);
            snakeList = new List<Snake>();
            
            batList = new List<Bat>();
            batList.Add(horizontalBat);
            batList.Add(verticalBat);

            currentEnemyList = new List<IEnemyState>();
            currentEnemyList.Add(enemy);
            currentEnemyList.Add(verticalBat);
            currentEnemyList.Add(horizontalBat);
            

            foreach (List<int> pos in m2.destructableBlocks.Values){
                dBlock = (new DestructableBlockSprite(game, new Vector2(pos[0], pos[1])));
                destructibleBlockList.Add(dBlock);
                currentObstacleList.Add(dBlock);
            }


            //destructibleBlockList.Add(new DestructableBlockSprite(new Vector2(250, 290)));
            //destructibleBlockList.Add(new DestructableBlockSprite(new Vector2(250, 330)));
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
            //indestructibleBlockList.Add(new IndestructableBlockSprite(new Vector2(290, 290)));
            //indestructibleBlockList.Add(new IndestructableBlockSprite(new Vector2(290, 330)));
        }

        public void Update()
        {
            background.Update();
            player1.Update();
            player2.Update();

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

            finishedExplosions = new List<Explosion>();
            foreach (Explosion e in explosionList)
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
            foreach (Explosion e in finishedExplosions)
            {
                explosionList.Remove(e);
            }
            foreach (NinjaStar n in finishedNinjaStar)
            {
                ninjaStarList.Remove(n);
            }
            foreach (BasicItem i in finishedItems)
            {
                currentItemList.Remove(i);
            }
            foreach (StaticBomb s in finishedBombs)
            {
                staticBombList.Remove(s);
            }
            foreach (ISprite s in finishedObstacles)
            {
                destructibleBlockList.Remove(s as DestructableBlockSprite);
                currentObstacleList.Remove(s);
            }
            SpawnItems();

            // players kept getting stuck - update previous position after collision checks

            player1.UpdatePreviousPosition();
            player2.UpdatePreviousPosition();
            (currentEnemyList[0] as Enemy).UpdatePreviousPosition();
            (currentEnemyList[1] as Bat).UpdatePreviousPosition();
            (currentEnemyList[2] as Bat).UpdatePreviousPosition();
            (currentEnemyList[3] as Snake).UpdatePreviousPosition();
        }

        public void Draw()
        {
            //graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            background.Draw(spriteBatch, new Vector2(0, 0));
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);

            //currentItemList[currItemIndex % currentItemList.Count].Draw(spriteBatch, new Vector2(150, 100));
            foreach (BasicItem i in currentItemList)
            {
                i.Draw(spriteBatch, new Vector2(0, 0));
            }

            //currentObstacleList[currObstacleIndex % currentObstacleList.Count].Draw(spriteBatch, new Vector2(350, 350));
            foreach (ISprite s in currentObstacleList)
            {
                s.Draw(spriteBatch, new Vector2(0, 0));
            }

            //currentEnemyList[currEnemyIndex % currentEnemyList.Count].Draw(spriteBatch);
            foreach (IEnemyState e in currentEnemyList)
            {
                e.Draw(spriteBatch);
            }

            foreach (StaticBomb s in staticBombList)
            {
                s.Draw(spriteBatch, new Vector2(0, 0));
            }

            foreach (Explosion e in explosionList)
            {
                e.Draw(spriteBatch, new Vector2(0, 0));
            }
            foreach (NinjaStar n in ninjaStarList)
            {
                n.DrawSprite(spriteBatch);
            }
        }

        // different implementation for later sprints
        /* private Dictionary<Vector2, ISprite> Items { get; set; }
                private Vector2 Position { get; set; }
                public Game1 game { get; set; }
                public Map1(Dictionary<Vector2, ISprite> Items, Game1 game)
                {
                    this.game = game;
                    this.Items = Items;
                }
                public void Draw()
                {
                    foreach (var item in Items)
                    {
                        Position = item.Key;
                        item.Value.Draw(game.spriteBatch, Position);
                    }
                }*/

        /*  mapDir.Add(new Vector2(350, 350), destructableBlockSprite);
            mapDir.Add(new Vector2(380, 350), indestructableBlockSprite);
            mapDir.Add(new Vector2(4100, 350), destructableBlockSprite);
            mapDir.Add(new Vector2(430, 350), destructableBlockSprite);
            mapDir.Add(new Vector2(460, 350), destructableBlockSprite);
            mapDir.Add(new Vector2(490, 350), destructableBlockSprite);
            mapDir.Add(new Vector2(520, 350), destructableBlockSprite);*/
        //we can use a json file or something to load all the blocks here later
        //load other texture storages

        public void AddBomb(Player player, Vector2 pos)
        {
            if (staticBombList.Count < 10)
            {
                staticBombList.Add(new StaticBomb(game, player, pos));
            }
        }

        public void AddExplosions(Vector2 pos, int potionCount)
        {
            int xOffset = -12;
            int yOffset = -7;
            // origin
            explosionList.Add(new Explosion(game, new Vector2(pos.X + xOffset, pos.Y + yOffset)));
            int x = (int)pos.X;
            int y = (int)pos.Y;
            // radius in each direction
            for (int i = 1; i < potionCount; i++)
            {
                explosionList.Add(new Explosion(game, new Vector2(xOffset + 50 * i + x, yOffset + y)));
                explosionList.Add(new Explosion(game, new Vector2(xOffset + x - (50 * i), yOffset + y)));
                explosionList.Add(new Explosion(game, new Vector2(xOffset + x, yOffset + 50 * i + y)));
                explosionList.Add(new Explosion(game, new Vector2(xOffset + x, yOffset + y - (50 * i))));
            }
        }
        public void AddNinjaStar(Player p)
        {
            ninjaStarList.Add(new NinjaStar(p));
        }

        public void AddItem(Vector2 pos)
        {
            BasicItem newItem;
            int rand = rnd.Next(1, 10);
            // normal items (twice as frequent spawn)
            if (rand < 7)
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
                    case 7:
                        newItem = new GoblinItem(pos, game);
                        break;
                    case 8:
                        newItem = new KnightItem(pos, game);
                        break;
                    case 9:
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
            }
        }
    }
}
