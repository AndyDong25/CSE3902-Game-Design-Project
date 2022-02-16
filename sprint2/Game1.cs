using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using CSE3902_Sprint2.Sprites.BlockSprites;
using CSE3902_Sprint2.Sprites;
using CSE3902_Sprint2.Controller;
using CSE3902_Sprint2.Objects.Player;
using sprint2.Objects.Bomb;
using CSE3902_Sprint2.Items;
using System.Collections.Generic;
using sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Items;
using sprint2.Sprites.Decorations;
using System;
using sprint2.Objects.NPC;
using Microsoft.Xna.Framework.Content;

namespace CSE3902_Sprint2
{

    public class Game1 : Game
    {
        public int Timeplayed;
        public int score;
        Rectangle safeBounds;
        const float safeAreaPortion = 0.001f;
        int TimeofGame = 0;
        Boolean isPaused = false;

        public GraphicsDeviceManager graphics;
        public static ContentManager contentManager;
        public SpriteBatch spriteBatch;
        private ArrayList controllerList;
        public Player player1;
        public Player player2;
        //public Player npcPlayer;
        public Enemy enemy;
        GameState currentGameState;
        

       enum GameState
        {
            GameMenu = 0,
            GamePlay = 1,
            GameOver = 2,
            GamePause = 3,
        }


        private ISprite destructableBlockSprite { get; set; }
        private ISprite indestructableBlockSprite { get; set; }
        private ISprite tree1 { get; set; }
        private ISprite tree2 { get; set; }

        public Vector2 screenSize;
        public Texture2D destructableBlockTexture;
        public Texture2D indestructableBlockTexture;
        public Texture2D tree1Texture;
        public Texture2D tree2Texture;

        public Texture2D bombTexture;
        public Dictionary<Vector2,int> staticBombList = new Dictionary<Vector2,int>();
        public Dictionary<Vector2, int> staticExplosionList = new Dictionary<Vector2, int>();
        
        public ISprite staticBomb { get; set; }
        private StaticBomb temp;

        public List<BasicItem> currentItemList;
        public int currItemIndex = 0;
        private SpriteFont font;

        public Game1()
        {         
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.ApplyChanges();
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            Viewport viewport = graphics.GraphicsDevice.Viewport;
            safeBounds = new Rectangle(
                (int)(viewport.Width * safeAreaPortion),
                (int)(viewport.Height * safeAreaPortion),
                (int)(viewport.Width * (1 - 2 * safeAreaPortion)),
                (int)(viewport.Height * (1 - 2 * safeAreaPortion)));
            //TODO change in the future
            currentGameState = GameState.GamePlay;
            


            player1 = new Player(new Vector2(30, 30), this);
            player2 = new Player(new Vector2(700, 30), this);
            //npcPlayer = new NPCPlayer(new Vector2(450, 300), this, randomNum); 
            enemy = new Enemy(new Vector2(450, 300), this);

            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this, player1, player2, enemy));
            //controllerList.Add(new MouseController(this));

            currentItemList = new List<BasicItem>();
            currentItemList.Add(new BombItem());
            currentItemList.Add(new PotionItem());
            currentItemList.Add(new ShoeItem());
            currentItemList.Add(new NinjaStarItem());
            currentItemList.Add(new GhostItem());
            currentItemList.Add(new KnightItem());
            currentItemList.Add(new GoblinItem());

            base.Initialize();
        }

       
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont font = Content.Load<SpriteFont>("Score");

            destructableBlockTexture = Content.Load<Texture2D>("DestructableCrate");
            indestructableBlockTexture = Content.Load<Texture2D>("Concrete_Block_2x2");
            tree1Texture = Content.Load<Texture2D>("Tree1");
            tree2Texture = Content.Load<Texture2D>("Tree2");
            bombTexture = Content.Load<Texture2D>("BigBomb");

            destructableBlockSprite = new DestructableBlockSprite(destructableBlockTexture);
            indestructableBlockSprite = new IndestructableBlockSprite(indestructableBlockTexture);
            tree1 = new Tree1(tree1Texture);
            tree2 = new Tree2(tree2Texture);

            staticBomb = new StaticBomb(bombTexture);
            temp = (StaticBomb)staticBomb;

            PlayerTextureStorage.Instance.LoadAllResources(Content);
            ItemTextureStorage.Instance.LoadAllResources(Content);
            //load other texture storages
        }


        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
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
                    if (keyboard.IsKeyDown(Keys.P))
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
                    }
                    // Press X or I during game play to return to main menu
                    if (gamePad.Buttons.X == ButtonState.Pressed ||
                        keyboard.IsKeyDown(Keys.I))
                    {
                        currentGameState = GameState.GameMenu;
                    }
                    // Press ESC to quit game during game play
                    if (gamePad.Buttons.Back == ButtonState.Pressed ||
                keyboard.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }
                    foreach (IController controller in controllerList)
                    {
                        controller.Update();
                    }
                    player1.Update();
                    player2.Update();
                    enemy.Update();

                    
                    break;


                    base.Update(gameTime);



            }
        }

        protected override void Draw(GameTime gameTime)
        {
                        
            this.IsMouseVisible = true;
            destructableBlockSprite.Draw(spriteBatch, new Vector2(250, 250));
            indestructableBlockSprite.Draw(spriteBatch, new Vector2(280, 250));
            tree1.Draw(spriteBatch, new Vector2(310, 250));
            tree2.Draw(spriteBatch, new Vector2(350, 250));
            spriteBatch.Begin();
            

            Texture2D background = Content.Load<Texture2D>("background2"); ;
            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(background, safeBounds, Color.White);

            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);

            enemy.Draw(spriteBatch);

            currItemIndex %= 7;
            currentItemList[currItemIndex].Draw(spriteBatch);

            spriteBatch.End();
                
            List<Vector2> bombList = new List<Vector2>(staticBombList.Keys);
            foreach (Vector2 bomb in bombList)
            {
                staticBombList[bomb]--;
                if (staticBombList[bomb] < 0)
                {
                    staticBombList.Remove(bomb);
                    staticExplosionList.Add(bomb, 20);
                }
            }
            foreach (Vector2 bomb in bombList)
            {
                staticBomb.Draw(spriteBatch, bomb);
            }
            List<Vector2> explosionList = new List<Vector2>(staticExplosionList.Keys);
            foreach (Vector2 explosion in explosionList)
            {
                int timer = staticExplosionList[explosion]--;
                if (timer != 0) { 
                    temp.Explode(spriteBatch, explosion); 
                }
                else {
                    staticExplosionList.Remove(explosion);
                }
            }
            base.Draw(gameTime);
        } 

        public void Reset()
        {
            this.Initialize();
        }
    }
}
