using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using CSE3902_CSE3902_Project.Controller;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_Project.Objects.NPC;
using Microsoft.Xna.Framework.Content;
using CSE3902_Project.Objects.Decorations;
using CSE3902_Project.Map;
using CSE3902_Project.Audio;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static CSE3902_Project.Map.Map1;
using CSE3902_Project.Fonts;
using System;
using Microsoft.Xna.Framework.Input;
using sprint3;

namespace CSE3902_CSE3902_Project
{

    public class Game1 : Game
    {

        public GraphicsDeviceManager graphics;
        public static ContentManager contentManager;
        public SpriteBatch spriteBatch;
        public ArrayList controllerList;
        //private GameState currentGameState;
        private Color backColor;

        public GameState gameState;

        Boolean isPaused;
/*        enum GameState
        {
            GameMenu = 0,
            GamePlay = 1,
            GameOver = 2,
            GamePause = 3,
        }*/

        public Map1 currentMap;
        public int totalMaps;
        public List<Map1> mapList;
        public Vector2 screenSize;
        public int map_index = 0;
        public bool changedMap = false;
        private bool mapsLoaded = false;
        public int p1Wins, p2Wins;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected  override void Initialize()
        {
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            isPaused = false;
            p1Wins = 0; 
            p2Wins = 0;

            //currentGameState = GameState.GameMenu;
/*            gameState = new GameState(this);
            gameState.ChangeToGameMenu();*/

            // mapDir = new Dictionary<Vector2, ISprite> { };
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.ApplyChanges();

            //base.Initialize();

            gameState = new GameState(this);
            gameState.ChangeToGameMenu();
            if (!mapsLoaded)
            {
                mapList = new List<Map1>();
                totalMaps = 5;

                for (int i = 0; i < totalMaps; i++)
                {
                    Map jsonMap = new Map();
                    string map_name = "content\\initial_map" + i + ".json";
                    using (StreamReader file = File.OpenText(map_name))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        jsonMap = (Map)serializer.Deserialize(file, typeof(Map));
                    }
                    Map1 m = new Map1(this, i, jsonMap);
                    m.Initialize();
                    mapList.Add(m);
                }
                mapsLoaded = true;
            }
            //currentMap = mapList[map_index];
            //SetUpCurrentMap();
        }

        protected override void LoadContent()
        {

            PlayerTextureStorage.Instance.LoadAllResources(Content);
            EnemyTextureStorage.Instance.LoadAllResources(Content);
            ItemTextureStorage.Instance.LoadAllResources(Content);
            DecorationTextureStorage.Instance.LoadAllResources(Content);
            SpriteFontStorage.Instance.LoadAllResources(Content);
            AudioManager.Instance.LoadAllResources(Content);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //base.Update(gameTime);

            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            gameState.Update(gameTime);
/*            switch (currentGameState)
            {
                case GameState.GameMenu:

                    *//*
                    *  For the gameMenu state, I think we need to have a picture instruction instead of the current map.
                    *  this area is the place to put the code.
                    *//*
                    Reset();
                    if (gamePad.Buttons.Back == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }
                    if (gamePad.Buttons.Start == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.GamePlay;

                        //May have score later.
                        // Reset score
                        //score = 0;
                    }
                    break;
                
                case GameState.GamePause:
                    if (keyboard.IsKeyDown(Keys.P))
                    {
                        isPaused = !isPaused;
                       
                    }
                    if (isPaused)
                    {
                        currentMap.PauseMusic();


                    }
                    else
                    {
                        currentMap.ResumeMusic();
                        currentGameState = GameState.GamePlay;
                    }
                    break;

                case GameState.GameOver:
                    // If game is over, the game allows return to main menu if key A is pressed 
                    // The gameOver state we will need a sound and a picture to tell the player that the game is over.
                    //This is the place to put the code
                    currentMap.GameOver();
                    if (gamePad.Buttons.A == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.GameMenu;
                    }
                    break;

                case GameState.GamePlay:

                    if (keyboard.IsKeyDown(Keys.P))
                    {
                        isPaused = !isPaused;
                    }
                    if (!isPaused)
                    {
                       
                        foreach (IController controller in controllerList)
                        {
                            controller.Update();

                        }

                        currentMap.Update(gameTime);
                        
                        
                        if (currentMap.myTime.getTime() == 0)
                        {
                            Reset();
                        }

                    }
                    else
                    {

                        currentGameState = GameState.GamePause;

                    }
                    // Press X or I during game play to return to main menu
                    if (gamePad.Buttons.X == ButtonState.Pressed ||
                         keyboard.IsKeyDown(Keys.I))
                    {
                        currentGameState = GameState.GameMenu;
                    }
                    if (gamePad.Buttons.X == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.B))
                    {
                        currentGameState = GameState.GameOver;
                    }
                    // Press ESC to quit game during game play
                    if (gamePad.Buttons.Back == ButtonState.Pressed ||
                         keyboard.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }
                    break;

            }*/

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
            this.IsMouseVisible = true;

            //currentMap.Draw(spriteBatch);
            gameState.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reset()
        {
            currentMap.Initialize();
            SetUpCurrentMap();
        }

        public void SetUpCurrentMap()
        {
            currentMap.InitializeAudioManager(Content);
            currentMap.Initialize();

            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this, currentMap.player1, currentMap.player2));
            controllerList.Add(new MouseController(this));
        }
    }
}
