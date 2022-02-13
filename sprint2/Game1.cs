using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using CSE3902_Sprint2.Sprites.BlockSprites;
using CSE3902_Sprint2.Sprites;
using CSE3902_Sprint2.Controller;
using CSE3902_Sprint2.Objects.Player;
using sprint2.Objects.Bomb;
using System.Collections.Generic;
using sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Items;
using sprint2.Sprites.Decorations;

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
            tree1.Draw(spriteBatch, new Vector2(310, 250));
            tree2.Draw(spriteBatch, new Vector2(350, 250));

            spriteBatch.Begin();
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
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
