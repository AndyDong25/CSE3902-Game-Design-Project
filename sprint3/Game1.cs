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
using sprint3.Objects.Bomb;
using CSE3902_Project.Objects.Bomb;
using System.Diagnostics;

namespace CSE3902_CSE3902_Project
{

    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public static ContentManager contentManager;
        public SpriteBatch spriteBatch;
        public ArrayList controllerList;
        private Color backColor;
       
        public GameState gameState;

        Boolean isPaused;

        public Map1 currentMap;
        public int totalMaps;
        public List<Map1> mapList;
        public Vector2 screenSize;
        public int map_index = 0;
        public bool changedMap = false;
        private bool mapsLoaded = false;
        public int p1Wins, p2Wins;
        public SaveManager saver1;
        public SaveManager saver2;
        public SaveManager saver3;
        public LogManager logger;
        public bool saved = false;
        public Camera camera;
        public Vector3 screenScale;
        public Matrix viewMatrix;
        public bool coinMode;
        public bool HelperMode;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            string str = Environment.CurrentDirectory;
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(str)));
            string saveFolder = @path; // put your save folder name here
            string saveFile1 = "savedLog1.html"; // put your save file name here
            string saveFile2 = "savedLog2.html";
            string saveFile3 = "savedLog3.html";
            string logFile = "log.html";
            Content.RootDirectory = "Content";

            saver1 = new IsolatedStorageSaveManager(saveFolder, saveFile1);
            saver2 = new IsolatedStorageSaveManager(saveFolder, saveFile2);
            saver3 = new IsolatedStorageSaveManager(saveFolder, saveFile3);

            //saver = new IsolatedStorageSaveManager(saveFolder, saveFile);
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
            HelperMode = false;

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.ApplyChanges();

            gameState = new GameState(this);
            gameState.ChangeToGameMenu();

            if (!mapsLoaded)
            {
                mapList = new List<Map1>();
                totalMaps = 6;
                Map jsonMap = new Map();
                for (int i = 0; i < totalMaps; i++)
                {
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
   
                Map1 mRandom = new Map1(this, 6, jsonMap);
                mRandom.isMapRandom = true;
                mRandom.Initialize();
                mapList.Add(mRandom);
                mapsLoaded = true;
            }
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
            screenScale = new Vector3(1.0f, 1.0f, 1.0f);
            viewMatrix = camera.GetTransform();
            
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
                                      null, null, null, null, viewMatrix * Matrix.CreateScale(screenScale));
            /*
             * The mode above has ignored the depth, which makes the predict range unable to been covered by player, 
             * if we want to fix it, we have to change to the mode below and give everything a depth 0-1 float
             * Format:
             * spriteBatch.Draw(Rangetexture, destinationRec, sourceRec, Color.Gray, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, (float)0.0000000000000001);
             */
            
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, null,null,
            //                        DepthStencilState.DepthRead, null, null, viewMatrix * Matrix.CreateScale(screenScale));

            this.IsMouseVisible = true;

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
            AudioManager.Instance.Reset();
        }

        public void SetUpCurrentMap()
        {
            currentMap.InitializeAudioManager(Content);
            currentMap.Initialize();

            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this, currentMap.player1, currentMap.player2));
            controllerList.Add(new MouseController(this));
        }
        public void setHelperMode()
        {
            StaticBomb sb = new StaticBomb(this);
            sb.setHelperMode();
        }
    }
}
