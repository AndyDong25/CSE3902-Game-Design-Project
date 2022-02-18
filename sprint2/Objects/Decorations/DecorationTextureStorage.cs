﻿using CSE3902_Sprint2;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Objects.Decorations
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

        private static Texture2D redBoyTexture = null;
        private static Texture2D whiteGirlTexture = null;
        private static Texture2D greenBoyTexture = null;
        private static Texture2D brownBoyTexture = null;
        private static Texture2D deadPlayerTexture = null;

        private DecorationTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            redBoyTexture = content.Load<Texture2D>("redBoy");
            whiteGirlTexture = content.Load<Texture2D>("whiteGirl");
            greenBoyTexture = content.Load<Texture2D>("greenBoy");
            brownBoyTexture = content.Load<Texture2D>("brownBoy");
            deadPlayerTexture = content.Load<Texture2D>("TombstoneSprite");
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
    }
}
