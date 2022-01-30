using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace CSE3902_Sprint0
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        private ArrayList controllerList;
        public ICommand Sprite { get; set; }
        public const int SPRITE_WIDTH = 256;
        public const int SPRITE_HEIGHT = 322;
        public enum MarioMovement { Nowhere, MovingAnimated, MovingStatic, NonMovingStatic, NonMovingAnimated };
        public MarioMovement marioMoves = MarioMovement.Nowhere;
        public Vector2 spriteposition;
        public Vector2 screeenSize;
        public Texture2D spriteTexture;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            screeenSize = new Vector2(graphics.PreferredBackBufferWidth,
graphics.PreferredBackBufferHeight);

        }
        
        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            //controllerList.Add(new MouseController(this));
   
            spriteposition = new Vector2(100, 100);

            base.Initialize();
        }

       
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteTexture  = Content.Load<Texture2D>("pngegg1");
            
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {


            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.IsMouseVisible = true;
            
            base.Draw(gameTime);
        } 
    }
}
