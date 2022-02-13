using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Objects.Items
{
    class ItemTextureStorage : ISpriteFactory
    {
        private static ItemTextureStorage instance = null;
        public static ItemTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemTextureStorage();
                }
                return instance;
            }
        }

        private static Texture2D ninjaStarTexture = null;
        // add other items

        private ItemTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            ninjaStarTexture = content.Load<Texture2D>("ninjaStarSprite");
            // load other item sprite sheets
        }
        public Texture2D getNinjaStarSprite()
        {
            return ninjaStarTexture;
        }
    }
}
