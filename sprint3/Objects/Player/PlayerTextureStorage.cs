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
    }
}
