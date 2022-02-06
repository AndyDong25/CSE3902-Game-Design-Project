using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace CSE3902_Sprint2
{

    public class Game1 : Game
    {
        // Commented out lines are sprint0 code for reference

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ArrayList controllerList;
        //public ISprite sprite { get; set; }
        //private ISprite text;
        private ISprite destructableBlockSprite { get; set; }
        private ISprite indestructableBlockSprite { get; set; }
        //public enum MarioMovement { Nowhere, MovingAnimated, MovingStatic, NonMovingStatic, NonMovingAnimated };
        //public MarioMovement marioMoves = MarioMovement.Nowhere;
        public Vector2 spriteposition;
        public Vector2 screeenSize;
        //public Texture2D spriteTexture;
        public Texture2D destructableBlockTexture;
        public Texture2D indestructableBlockTexture;

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
            //spriteTexture =  Content.Load<Texture2D>("pngegg1");
            destructableBlockTexture = Content.Load<Texture2D>("DestructableCrate");
            indestructableBlockTexture = Content.Load<Texture2D>("Concrete_Block_2x2");
            //sprite = new StaticSprite(spriteTexture, new Rectangle(0,0, 230,322));
            //text = new TextSprite(Content.Load<SpriteFont>("Score"));
            destructableBlockSprite = new DestructableBlockSprite(destructableBlockTexture);
            indestructableBlockSprite = new IndestructableBlockSprite(indestructableBlockTexture);
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
            
            //sprite.Update();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.IsMouseVisible = true;
            //sprite.Draw(spriteBatch, spriteposition);
            //text.Draw(spriteBatch, new Vector2(0,0));
            destructableBlockSprite.Draw(spriteBatch, new Vector2(250, 250));
            indestructableBlockSprite.Draw(spriteBatch, new Vector2(280, 250));
            base.Draw(gameTime);
        } 
    }
}
