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
        private static Texture2D explosionTexture = null;
        private static Texture2D bombItemTexture = null;
        private static Texture2D goblinItemTexture = null;
        private static Texture2D knightItemTexture = null;
        private static Texture2D ghostItemTexture = null;
        private static Texture2D potionItemTexture = null;
        private static Texture2D shoeItemTexture = null;
        

        // add other items

        private ItemTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            ninjaStarTexture = content.Load<Texture2D>("ninjaStarSprite");
            explosionTexture = content.Load<Texture2D>("ExplosionSpriteSheet");
            bombItemTexture = content.Load<Texture2D>("bombItemSprite");
            goblinItemTexture = content.Load<Texture2D>("goblinItemSprite");
            knightItemTexture = content.Load<Texture2D>("knightItemSprite");
            ghostItemTexture = content.Load<Texture2D>("ghostItemSprite");
            potionItemTexture = content.Load<Texture2D>("potionItemSprite");
            shoeItemTexture = content.Load<Texture2D>("shoeSprite");
            explosionTexture = content.Load<Texture2D>("ExplosionSpriteSheet");

            // load other item sprite sheets
        }
        public Texture2D getNinjaStarSprite()
        {
            return ninjaStarTexture;
        }

        public Texture2D getExplosionSprite()
        {
            return explosionTexture;
        }
        public Texture2D getBombItemSprite()
        {
            return bombItemTexture;
        }
        public Texture2D getGoblinItemSprite()
        {
            return goblinItemTexture;
        }
        public Texture2D getKnightItemSprite()
        {
            return knightItemTexture;
        }
        public Texture2D getGhostItemSprite()
        {
            return ghostItemTexture;
        }
        public Texture2D getPotionItemSprite()
        {
            return potionItemTexture;
        }
        public Texture2D getShoeItemSprite()
        {
            return shoeItemTexture;
        }
    }
}
