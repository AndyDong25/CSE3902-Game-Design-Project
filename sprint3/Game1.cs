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

namespace CSE3902_CSE3902_Project
{

    public class Game1 : Game
    {
/*        pqpublic int Timeplayed;
        public int score;
        Rectangle safeBounds;
        const float safeAreaPortion = 0.001f;*/

        public GraphicsDeviceManager graphics;
        public static ContentManager contentManager;
        public SpriteBatch spriteBatch;
        public ArrayList controllerList;
        //private GameState currentGameState;
/*       enum GameState
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
        public Game1()
        {         
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";      
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            /*            Viewport viewport = graphics.GraphicsDevice.Viewport;
                        safeBounds = new Rectangle(
                            (int)(viewport.Width * safeAreaPortion),
                            (int)(viewport.Height * safeAreaPortion),
                            (int)(viewport.Width * (1 - 2 * safeAreaPortion)),
                            (int)(viewport.Height * (1 - 2 * safeAreaPortion)));*/
            //TODO change in the future
            //currentGameState = GameState.GamePlay;

            // mapDir = new Dictionary<Vector2, ISprite> { };
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            graphics.ApplyChanges();
            base.Initialize();
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
            currentMap = mapList[map_index];
            currentMap.Initialize();
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this, currentMap.player1, currentMap.player2));
            controllerList.Add(new MouseController(this));
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
            // GameState functionality not implemented yet

/*            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            
            switch (currentGameState)
            {
                case GameState.GameMenu:

                    if (gamePad.Buttons.Back == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }
                    if (gamePad.Buttons.Start == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.Enter))
                    {

                        // Set the game state to play
                        currentGameState = GameState.GamePlay;

                        // Reset score
                        score = 0;
                    }
                    break;

                case GameState.GameOver:
                    // If game is over, the game allows return to main menu if key A is pressed 
                    if (gamePad.Buttons.A == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.GameMenu;
                    }
                    break;

                case GameState.GamePlay:
*//*                    if (keyboard.IsKeyDown(Keys.P))
                    {
                        isPaused = !isPaused;
                    }
                    if (!isPaused)
                    {   
                        TimeofGame += gameTime.ElapsedGameTime.Milliseconds;
                       
                        //code when the game isn't paused.
                    }
                    else
                    {
                        //code when the game is paused.
                        currentGameState = GameState.GamePause;
                    }*//*
                    // Press X or I during game play to return to main menu
*//*                    if (gamePad.Buttons.X == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.I))
                    {
                        currentGameState = GameState.GameMenu;
                    }*//*
                    // Press ESC to quit game during game play
*//*                    if (gamePad.Buttons.Back == ButtonState.Pressed ||
                keyboard.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }*//*
                    foreach (IController controller in controllerList)
                    {
                        controller.Update();
                    }
                    map.Update();
                    
                    break;
            }*/
                        
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            currentMap.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            this.IsMouseVisible = true;  

            currentMap.Draw(spriteBatch);
            spriteBatch.End();
                
            base.Draw(gameTime);
        } 

        public void Reset()
        {
            Initialize();
        }
    }
}
