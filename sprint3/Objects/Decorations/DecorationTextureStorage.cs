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

        private static Texture2D crateDBlock;
        private static Texture2D crateIBlock;
        private static Texture2D grassBackground;

        private static Texture2D iceBackground;
        private static Texture2D iceDBlock;
        private static Texture2D iceIBlock;

        private static Texture2D dirtBackground;
        private static Texture2D chestBlock;
        private static Texture2D mineralBlock;

        private static Texture2D waterBackground;
        private static Texture2D kelpBlock;
        private static Texture2D waterBlock;

        private static Texture2D mashroom1Texture;

        private static Texture2D portalTexture;

        private static Texture2D hudBackgroundTexture;
        private static Texture2D fireTexture;

        private DecorationTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            tree1Texture = content.Load<Texture2D>("tree1");
            tree2Texture = content.Load<Texture2D>("tree2");

            crateDBlock = content.Load<Texture2D>("DestructableCrate");
            crateIBlock = content.Load<Texture2D>("Concrete_Block_2x2");
            grassBackground = content.Load<Texture2D>("grass_template2");

            iceBackground = content.Load<Texture2D>("iceBackground");
            iceDBlock = content.Load<Texture2D>("IceBlockD");
            iceIBlock = content.Load<Texture2D>("IceBlockI");

            dirtBackground = content.Load<Texture2D>("dirtBackground");
            chestBlock = content.Load<Texture2D>("treasureBlock");
            mineralBlock = content.Load<Texture2D>("blueMineral");

            waterBackground = content.Load<Texture2D>("waterBackground");
            kelpBlock = content.Load<Texture2D>("kelpSprite");
            waterBlock = content.Load<Texture2D>("waterBlock");

            mashroom1Texture = content.Load<Texture2D>("mashroom1");
            portalTexture = content.Load<Texture2D>("portalSpritesheet");
            fireTexture = content.Load<Texture2D>("fire1_64");
            hudBackgroundTexture = content.Load<Texture2D>("hudBackground");
        }

        public Texture2D getTree1Sprite()
        {
            return tree1Texture;
        }
        public Texture2D getTree2Sprite()
        {
            return tree2Texture;
        }
        public Texture2D getCrateDBlock()
        {
            return crateDBlock;
        }
        public Texture2D getCrateIBlock()
        {
            return crateIBlock;
        }
        public Texture2D getIceDBlock()
        {
            return iceDBlock;
        }
        public Texture2D getIceIBlock()
        {
            return iceIBlock;
        }
        public Texture2D getChestBlock()
        {
            return chestBlock;
        }
        public Texture2D getMineralBlock()
        {
            return mineralBlock;
        }
        public Texture2D getKelpBlock()
        {
            return kelpBlock;
        }
        public Texture2D getWaterBlock()
        {
            return waterBlock;
        }
        public Texture2D getGrassBackgroundSprite()
        {
            return grassBackground;
        }
        public Texture2D getIceBackGroundSprite()
        {
            return iceBackground;
        }
        public Texture2D getDirtBackgroundSprite()
        {
            return dirtBackground;
        }
        public Texture2D getWaterBackgrounSprite()
        {
            return waterBackground;
        }
        public Texture2D getMashroom1Sprite()
        {
            return mashroom1Texture;
        }
        public Texture2D getPortalSprite()
        {
            return portalTexture;
        }
        public Texture2D getHudBackgroundSprite()
        {
            return hudBackgroundTexture;
        }
        public Texture2D getFireSprite()
        {
            return fireTexture;
        }
    }
}
