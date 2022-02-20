using CSE3902_Sprint2;
using CSE3902_Sprint2.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using CSE3902_Sprint2.Sprites.BlockSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.NPC;
using sprint2.Sprites.Decorations;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Map
{
    public class Map
    {
        private Game1 game;
        public int Timeplayed;
        public int score;
        Rectangle safeBounds;
        const float safeAreaPortion = 0.001f;
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
        public Map(Game1 game)
        {
            this.game = game;
            spriteBatch = game.spriteBatch;
            graphics = game.graphics;
        }
        public void Initialize()
        {
/*            Viewport viewport = graphics.GraphicsDevice.Viewport;
            safeBounds = new Rectangle(
                (int)(viewport.Width * safeAreaPortion),
                (int)(viewport.Height * safeAreaPortion),
                (int)(viewport.Width * (1 - 2 * safeAreaPortion)),
                (int)(viewport.Height * (1 - 2 * safeAreaPortion)));
            //TODO change in the future
            currentGameState = GameState.GamePlay;*/

            background = new Background1();
            player1 = new Player(new Vector2(30, 30), game);
            player2 = new Player(new Vector2(700, 30), game);
            npc = new Enemy(new Vector2(450, 300), game);
            currentItemList = new List<BasicItem>();
            currentItemList.Add(new BombItem());
            currentItemList.Add(new PotionItem());
            currentItemList.Add(new ShoeItem());
            currentItemList.Add(new NinjaStarItem());
            currentItemList.Add(new GhostItem());
            currentItemList.Add(new KnightItem());
            currentItemList.Add(new GoblinItem());

            currentObstacleList = new List<ISprite>();
            currentObstacleList.Add(new DestructableBlockSprite());
            currentObstacleList.Add(new IndestructableBlockSprite());
            currentObstacleList.Add(new Tree1());
            currentObstacleList.Add(new Tree2());
        }

        public void Update()
        {
            background.Update();
            player1.Update();
            player2.Update();
            npc.Update();
            // unimplemented for sprint2
            //currentItemList[currItemIndex % 7].Update();
            // does nothing for sprint2
            currentObstacleList[currObstacleIndex % 4].Update();
        }

        public void Draw()
        {
            background.Draw(spriteBatch, new Vector2(0, 0));
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            npc.Draw(spriteBatch);
            currentItemList[currItemIndex % 7].Draw(spriteBatch);
            currentObstacleList[currObstacleIndex % 4].Draw(spriteBatch, new Vector2(350, 350));
        }
    }
}
