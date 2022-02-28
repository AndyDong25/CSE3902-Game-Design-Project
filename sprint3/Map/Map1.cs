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
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sprint2.Map
{
    public class Map1
    {
        private Game1 game;
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

        public List<ISprite> currentObstacleList;
        public int currObstacleIndex = 0;

        public List<IEnemyState> currentEnemyList;
        public int currEnemyIndex = 0;

        public Map1(Game1 game)
        {
            this.game = game;
            spriteBatch = game.spriteBatch;
            graphics = game.graphics;
        }
        public void Initialize()
        {

            //TODO change in the future
            //currentGameState = GameState.GamePlay;*/

            background = new Background1();
            player1 = new Player(new Vector2(30, 30), game);
            player2 = new Player(new Vector2(700, 30), game);

            explosionList = player1.staticBomb.explosionList;
            explosionList.AddRange(player2.staticBomb.explosionList);

            enemy = new Enemy(new Vector2(450, 300), game);
            verticalBat = new Bat(new Vector2(400, 240), game);
            horizontalBat = new Bat(new Vector2(400, 380), game);
            horizontalBat.currState = new BatFacingEastState(horizontalBat);
            snake = new Snake(new Vector2(60, 430), game);

            dBlock = new DestructableBlockSprite(new Vector2(250, 250));
            iBlock = new IndestructableBlockSprite(new Vector2(290, 250));
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
            currentObstacleList.Add(dBlock);
            currentObstacleList.Add(iBlock);
            currentObstacleList.Add(tree1);
            currentObstacleList.Add(tree2);

            currentEnemyList = new List<IEnemyState>();
            currentEnemyList.Add(enemy);
            currentEnemyList.Add(verticalBat);
            currentEnemyList.Add(horizontalBat);
            currentEnemyList.Add(snake);
        }

        public void Update()
        {
            background.Update();
            player1.Update();
            player2.Update();

            foreach (BasicItem i in currentItemList)
            {
                i.Update();
            }

            foreach (ISprite s in currentObstacleList)
            {
                s.Update();
            }

            foreach (IEnemyState e in currentEnemyList)
            {
                e.Update();
            }

            // CHECK FOR COLLISIONS - hard coded for now to test collisions
            if (player1.collider2D.Intersects(player2.collider2D))
            {
                player1.PlayerCollisionTest();
                player2.PlayerCollisionTest();
            }

            foreach (Explosion e in explosionList)
            {
                if (e.collider2D.Intersects(player1.collider2D))
                {
                    player1.currState = new PlayerDeathState(player1);
                }
                if (e.collider2D.Intersects(player2.collider2D))
                {
                    player2.currState = new PlayerDeathState(player2);
                }
            }

            // will need to clean up and move to CollisionDetection.cs class once fully implemented
            Rectangle enemyCollider = (currentEnemyList[0] as Enemy).collider2D;
            Rectangle batVerticalCollider = (currentEnemyList[1] as Bat).collider2D;
            Rectangle batHorizontalCollider = (currentEnemyList[2] as Bat).collider2D;
            Rectangle snakeCollider = (currentEnemyList[3] as Snake).collider2D;

            if (player1.collider2D.Intersects(enemyCollider) || player1.collider2D.Intersects(batVerticalCollider) || player1.collider2D.Intersects(batHorizontalCollider) || player1.collider2D.Intersects(snakeCollider))
            {
                player1.currState = new PlayerDeathState(player1);
            }
            if (player2.collider2D.Intersects(enemyCollider) || player2.collider2D.Intersects(batVerticalCollider) || player2.collider2D.Intersects(batHorizontalCollider) || player2.collider2D.Intersects(snakeCollider))
            {
                player2.currState = new PlayerDeathState(player2);
            }

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
    }
}
