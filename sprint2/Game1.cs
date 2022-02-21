using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using CSE3902_Sprint2.Controller;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Objects.Items;
using sprint2.Objects.NPC;
using Microsoft.Xna.Framework.Content;
using sprint2.Objects.Decorations;
using sprint2.Map;

namespace CSE3902_Sprint2
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
        private ArrayList controllerList;
        //private GameState currentGameState;
/*       enum GameState
        {
            GameMenu = 0,
            GamePlay = 1,
            GameOver = 2,
            GamePause = 3,
        }*/

        public Map map;
        public Vector2 screenSize;

        public Game1()
        {         
            graphics = new GraphicsDeviceManager(this);
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
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

            base.Initialize();

            map = new Map(this);
            map.Initialize();

            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this, map.player1, map.player2));
            //controllerList.Add(new MouseController(this));
        }

        protected override void LoadContent()
        {
            PlayerTextureStorage.Instance.LoadAllResources(Content);
            EnemyTextureStorage.Instance.LoadAllResources(Content);
            ItemTextureStorage.Instance.LoadAllResources(Content);
            DecorationTextureStorage.Instance.LoadAllResources(Content);
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
            map.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            this.IsMouseVisible = true;  

            map.Draw();
            spriteBatch.End();
                
            base.Draw(gameTime);
        } 

        public void Reset()
        {
            Initialize();
        }
    }
}
