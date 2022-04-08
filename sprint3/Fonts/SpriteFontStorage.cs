﻿using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Fonts
{
    class SpriteFontStorage : ISpriteFactory
    {
        private static SpriteFontStorage instance = null;
        public static SpriteFontStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SpriteFontStorage();
                }
                return instance;
            }
        }

        private static SpriteFont hudFont;

        private SpriteFontStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            hudFont = content.Load<SpriteFont>("hudFont");
        }

        public SpriteFont getHudFont()
        {
            return hudFont;
        }
    }
}