using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.NPC
{
    class EnemyTextureStorage : ISpriteFactory
    {
        private static EnemyTextureStorage instance = null;
        public static EnemyTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D redBoyTexture;
        private static Texture2D whiteGirlTexture;
        private static Texture2D greenBoyTexture;
        private static Texture2D brownBoyTexture;
        private static Texture2D deadPlayerTexture;

        private static Texture2D batTexture;
        private static Texture2D snakeTexture;
        private static Texture2D alienTexture;

        private static Texture2D yetiLeftTexture;
        private static Texture2D yetiRightTexture;


        private EnemyTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            redBoyTexture = content.Load<Texture2D>("redBoy");
            whiteGirlTexture = content.Load<Texture2D>("whiteGirl");
            greenBoyTexture = content.Load<Texture2D>("greenBoy");
            brownBoyTexture = content.Load<Texture2D>("brownBoy");
            deadPlayerTexture = content.Load<Texture2D>("TombstoneSprite");
            batTexture = content.Load<Texture2D>("batSpriteSheet");
            snakeTexture = content.Load<Texture2D>("snakeSpriteSheet");
            alienTexture = content.Load<Texture2D>("alien");
            yetiLeftTexture = content.Load<Texture2D>("yetiLeftSpritesheet");
            yetiRightTexture = content.Load<Texture2D>("yetiRightSpritesheet");

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
        public Texture2D getTombstoneSprite()
        {
            return deadPlayerTexture;
        }
        public Texture2D getBatSprite()
        {
            return batTexture;
        }
        public Texture2D getSnakeSprite()
        {
            return snakeTexture;
        }
        public Texture2D getAlienSprite()
        {
            return alienTexture;
        }
        public Texture2D getYetiLeftSprite()
        {
            return yetiLeftTexture;
        }
        public Texture2D getYetiRightSprite()
        {
            return yetiRightTexture;
        }

    }
}
