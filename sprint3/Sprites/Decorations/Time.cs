using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Fonts;
using CSE3902_Project.Map;
using CSE3902_Project.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace sprint3.Sprites.Decorations
{
    public class Time : ISprite
    {
        private Map1 map;

        private SpriteFont font;
        public Vector2 pos;
        public float time;
        
        public Time(Vector2 pos, Map1 map, int time)
        {
            this.map = map;
            this.pos = pos;
            this.time = time;

            font = SpriteFontStorage.Instance.getTimeFont();

        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "TIME: " + time.ToString("0"), pos, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            time -= (float) gameTime.ElapsedGameTime.TotalSeconds;
        }
        public int getTime()
        {
            return (int)time;
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
