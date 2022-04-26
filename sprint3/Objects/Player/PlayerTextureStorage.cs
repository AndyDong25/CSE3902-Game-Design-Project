using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_CSE3902_Project.Objects.Player
{
    class PlayerTextureStorage : ISpriteFactory
    {
        private static PlayerTextureStorage instance = null;
        public static PlayerTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D bombermanTexture = null;
        private static Texture2D goblinTexture = null;
        private static Texture2D knightTexture = null;
        private static Texture2D ghostTexture = null;
        private static Texture2D deadPlayerTexture = null;
        private static Texture2D redBoyTexture = null;
        private static Texture2D whiteGirlTexture = null;
        private static Texture2D greenBoyTexture = null;
        private static Texture2D brownBoyTexture = null;

        private PlayerTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            bombermanTexture = content.Load<Texture2D>("bomberSpritesheet");
            goblinTexture = content.Load<Texture2D>("goblinSpriteSheet");
            knightTexture = content.Load<Texture2D>("knightSprite");
            ghostTexture = content.Load<Texture2D>("GhostPacmanSpriteSheet");
            deadPlayerTexture = content.Load<Texture2D>("TombstoneSprite");
            redBoyTexture = content.Load<Texture2D>("redBoy");
            whiteGirlTexture = content.Load<Texture2D>("whiteGirl");
            greenBoyTexture = content.Load<Texture2D>("greenBoy");
            brownBoyTexture = content.Load<Texture2D>("brownBoy");
        }

        public Texture2D getBomberSpriteSheet()
        {
            return bombermanTexture;
        }
        public Texture2D getGoblinSpriteSheet()
        {
            return goblinTexture;
        }
        public Texture2D getKnightSpriteSheet()
        {
            return knightTexture;
        }
        public Texture2D getGhostSpriteSheet()
        {
            return ghostTexture;
        }
        public Texture2D getTombstoneSprite()
        {
            return deadPlayerTexture;
        }
        public Texture2D getRedBoySpriteSheet()
        {
            return redBoyTexture;
        }
        public Texture2D getWhiteGirlSpriteSheet()
        {
            return whiteGirlTexture;
        }
        public Texture2D getGreenBoySpriteSheet()
        {
            return greenBoyTexture;
        }
        public Texture2D getBrownBoySpriteSheet()
        {
            return brownBoyTexture;
        }
    }
}
