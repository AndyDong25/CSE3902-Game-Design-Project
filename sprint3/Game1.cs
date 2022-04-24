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
        public SaveManager saver;
        public LogManager logger;
        public bool saved = false;
        public Camera camera;
        public Vector3 screenScale;
        public Matrix viewMatrix;
        public bool coinMode;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            string str = Environment.CurrentDirectory;
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(str)));
            string saveFolder = @path; // put your save folder name here
            string saveFile = "savedLog.html"; // put your save file name here
            string logFile = "log.html";
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            saver = new IsolatedStorageSaveManager(saveFolder, saveFile);
            logger = new IsolatedStorageSaveLogManager(saveFolder, logFile);
            coinMode = false;
        }

        protected  override void Initialize()
        {
            camera = new Camera();
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
                totalMaps = 6;

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
            gameState.Update(gameTime);
            logger.Save();
            camera.Update();
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            //spriteBatch.Begin();
            screenScale = new Vector3(1.0f, 1.0f, 1.0f);
            viewMatrix = camera.GetTransform();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
                                       null, null, null, null, viewMatrix * Matrix.CreateScale(screenScale));
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
            camera.Position = Vector2.Zero;
            camera.Zoom = 1;
            camera.Origin = Vector2.Zero;
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
