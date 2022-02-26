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
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sprint2.Map
{
    public class Map
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
        public Enemy npc;

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

        public Map(Game1 game)
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

            currentItemList = new List<BasicItem>();
            currentItemList.Add(new BombItem(new Vector2(150, 100), game));
            currentItemList.Add(new PotionItem(new Vector2(150, 100), game));
            currentItemList.Add(new ShoeItem(new Vector2(150, 100), game));
            currentItemList.Add(new NinjaStarItem(new Vector2(150, 100), game));
            currentItemList.Add(new GhostItem(new Vector2(150, 100), game));
            currentItemList.Add(new KnightItem(new Vector2(150, 100), game));
            currentItemList.Add(new GoblinItem(new Vector2(150, 100), game));

            currentObstacleList = new List<ISprite>();
            currentObstacleList.Add(new DestructableBlockSprite());
            currentObstacleList.Add(new IndestructableBlockSprite());
            currentObstacleList.Add(new Tree1());
            currentObstacleList.Add(new Tree2());

            currentEnemyList = new List<IEnemyState>();
            currentEnemyList.Add(new Enemy(new Vector2(450, 300), game));
            currentEnemyList.Add(new Bat(new Vector2(400, 240), game));

            Bat sideWaysBat = new Bat(new Vector2(400, 380), game);
            sideWaysBat.currState = new BatFacingEastState(sideWaysBat);
            currentEnemyList.Add(sideWaysBat);

            currentEnemyList.Add(new Snake(new Vector2(60, 430), game));
        }

        public void Update()
        {
            background.Update();
            player1.Update();
            player2.Update();

            currentItemList[currItemIndex % currentItemList.Count].Update();
            currentObstacleList[currObstacleIndex % currentObstacleList.Count].Update();
            currentEnemyList[currEnemyIndex % currentEnemyList.Count].Update();

            // CHECK FOR COLLISIONS
            if (player1.collider2D.Intersects(player2.collider2D))
            {
                player1.PlayerCollisionTest();
                player2.PlayerCollisionTest();
            }

            // players kept getting stuck - update previous position after collision checks
            player1.UpdatePreviousPosition();
            player2.UpdatePreviousPosition();
        }

        public void Draw()
        {
            //graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            background.Draw(spriteBatch, new Vector2(0, 0));
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            //npc.Draw(spriteBatch);
            currentItemList[currItemIndex % currentItemList.Count].Draw(spriteBatch, new Vector2(150, 100));
            currentObstacleList[currObstacleIndex % currentObstacleList.Count].Draw(spriteBatch, new Vector2(350, 350));
            currentEnemyList[currEnemyIndex % currentEnemyList.Count].Draw(spriteBatch);
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
