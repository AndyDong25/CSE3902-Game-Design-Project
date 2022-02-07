using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using CSE3902_Sprint2.Sprites.BlockSprites;
using CSE3902_Sprint2.Sprites;
using CSE3902_Sprint2.Controller;

namespace CSE3902_Sprint2
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ArrayList controllerList;
        private ISprite destructableBlockSprite { get; set; }
        private ISprite indestructableBlockSprite { get; set; }
        public Vector2 screenSize;
        public Texture2D destructableBlockTexture;
        public Texture2D indestructableBlockTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            screenSize = new Vector2(graphics.PreferredBackBufferWidth,
graphics.PreferredBackBufferHeight);

        }
        
        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            //controllerList.Add(new MouseController(this));

            base.Initialize();
        }

       
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            destructableBlockTexture = Content.Load<Texture2D>("DestructableCrate");
            indestructableBlockTexture = Content.Load<Texture2D>("Concrete_Block_2x2");

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
            destructableBlockSprite.Draw(spriteBatch, new Vector2(250, 250));
            indestructableBlockSprite.Draw(spriteBatch, new Vector2(280, 250));
            base.Draw(gameTime);
        } 
    }
}
