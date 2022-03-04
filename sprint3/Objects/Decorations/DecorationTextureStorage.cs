using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.Decorations
{
    class DecorationTextureStorage : ISpriteFactory
    {
        private static DecorationTextureStorage instance = null;
        public static DecorationTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DecorationTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D tree1Texture;
        private static Texture2D tree2Texture;
        private static Texture2D destructibleBlockTexture;
        private static Texture2D indestructibleBlockTexture;
        private static Texture2D background1;

        private DecorationTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            tree1Texture = content.Load<Texture2D>("tree1");
            tree2Texture = content.Load<Texture2D>("tree2");
            destructibleBlockTexture = content.Load<Texture2D>("DestructableCrate");
            indestructibleBlockTexture = content.Load<Texture2D>("Concrete_Block_2x2");
            background1 = content.Load<Texture2D>("background2");
    }

    public Texture2D getTree1Sprite()
        {
            return tree1Texture;
        }
        public Texture2D getTree2Sprite()
        {
            return tree2Texture;
        }
        public Texture2D getDestructibleBlockSprite()
        {
            return destructibleBlockTexture;
        }
        public Texture2D getIndestructibleBlockSprite()
        {
            return indestructibleBlockTexture;
        }
        public Texture2D getBackground1Sprite()
        {
            return background1;
        }
    }
}
