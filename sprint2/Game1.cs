using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using CSE3902_Sprint2.Sprites.BlockSprites;
using CSE3902_Sprint2.Sprites;
using CSE3902_Sprint2.Controller;
using CSE3902_Sprint2.Objects.Player;
using sprint2.Objects.Bomb;

namespace CSE3902_Sprint2
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private ArrayList controllerList;
        public Player player1;
        public Player player2;
        private ISprite destructableBlockSprite { get; set; }
        private ISprite indestructableBlockSprite { get; set; }
        public Vector2 screenSize;
        public Texture2D destructableBlockTexture;
        public Texture2D indestructableBlockTexture;
        // Bomb
        public ISprite staticBomb { get; set; }
        public Texture2D bombTexture;
        public int testDrop = 0;
        public Vector2 testDropPos = new Vector2(0, 0);

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
            player1 = new Player(new Vector2(30, 30), this);
            player2 = new Player(new Vector2(700, 30), this);
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this, player1, player2));
            //controllerList.Add(new MouseController(this));

            base.Initialize();
        }

       
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            destructableBlockTexture = Content.Load<Texture2D>("DestructableCrate");
            indestructableBlockTexture = Content.Load<Texture2D>("Concrete_Block_2x2");
            bombTexture = Content.Load<Texture2D>("BigBomb");

            destructableBlockSprite = new DestructableBlockSprite(destructableBlockTexture);
            indestructableBlockSprite = new IndestructableBlockSprite(indestructableBlockTexture);
            staticBomb = new StaticBomb(bombTexture);

            PlayerTextureStorage.Instance.LoadAllResources(Content);
            //load other texture storages
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
            player1.Update();
            player2.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.IsMouseVisible = true;
            destructableBlockSprite.Draw(spriteBatch, new Vector2(250, 250));
            indestructableBlockSprite.Draw(spriteBatch, new Vector2(280, 250));
            // staticBomb.Draw(spriteBatch, new Vector2(100, 100));

            spriteBatch.Begin();
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            spriteBatch.End();
            if (testDrop == 1)
            {
                staticBomb.Draw(spriteBatch, testDropPos);
            }

            base.Draw(gameTime);
        } 

        public void Reset()
        {
            this.Initialize();
        }
    }
}
