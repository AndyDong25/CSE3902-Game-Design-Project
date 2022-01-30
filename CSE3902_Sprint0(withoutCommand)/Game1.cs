using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace CSE3902_Sprint0
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private ArrayList controllerList;
        private int presentSprite;
        public ISprite StaticMovingSprite { get; set; }
        public ISprite AnimatedMovingSprite { get; set; }
        public ISprite AnimatedSprite { get; set; }
        public ISprite StaticSprite { get; set; }
        public const int SPRITE_WIDTH = 256;
        public const int SPRITE_HEIGHT = 322;
        public enum MarioMovement { Nowhere, MovingAnimated, MovingStatic, NonMovingStatic, NonMovingAnimated };
        public MarioMovement marioMoves = MarioMovement.Nowhere;
        public Vector2 spriteposition;
        public Vector2 screeenSize;

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
            controllerList.Add(new MouseController(this));

            spriteposition = new Vector2(100, 100);

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("pngegg1");
            
            StaticSprite = new StaticSprite(texture, new Rectangle(0, 0, SPRITE_WIDTH, SPRITE_HEIGHT));
            StaticMovingSprite = new StaticMovingSprite(texture, new Rectangle(0, 0, SPRITE_WIDTH, SPRITE_HEIGHT), spriteposition, screeenSize);
            AnimatedMovingSprite = new AnimatedMovingSprite(texture, 2, 4, spriteposition, screeenSize);
            AnimatedSprite = new AnimatedSprite(texture, 2, 4);
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

            if (marioMoves == MarioMovement.NonMovingStatic)
            {
                StaticSprite.Update();
            }
            else if (marioMoves == MarioMovement.NonMovingAnimated)
            {
                AnimatedSprite.Update();
            }
            else if (marioMoves == MarioMovement.MovingStatic)
            {
                StaticMovingSprite.Update();
            }

            else if (marioMoves == MarioMovement.MovingAnimated)
            {
                AnimatedMovingSprite.Update();
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.IsMouseVisible = true;
            if (marioMoves == MarioMovement.NonMovingStatic)
            {
                StaticSprite.Draw(spriteBatch, spriteposition);
            }
            else if (marioMoves == MarioMovement.NonMovingAnimated)
            {
                AnimatedSprite.Draw(spriteBatch, spriteposition);
            }
            else if (marioMoves == MarioMovement.MovingStatic)
            {
                StaticMovingSprite.Draw(spriteBatch, spriteposition);
            }
            else if (marioMoves == MarioMovement.MovingAnimated)
            {
                AnimatedMovingSprite.Draw(spriteBatch, spriteposition);
            }

            base.Draw(gameTime);
        } 
    }
}
