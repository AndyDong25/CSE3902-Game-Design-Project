using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Objects.Bomb;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;

namespace sprint3.Objects.Bomb
{
    public class ExplosionRange : ISprite
    {
        public List<Explosion> originExplosion;
        public List<Explosion> upExplosions;
        public List<Explosion> downExplosions;
        public List<Explosion> rightExplosions;
        public List<Explosion> leftExplosions;
        public List<Explosion> allExplosions;
        public int timer;
        private Game1 game;

        public ExplosionRange(Game1 game)
        {
            timer = 20;
            this.game = game;
            originExplosion = new List<Explosion>();
            upExplosions = new List<Explosion>();
            downExplosions = new List<Explosion>();
            leftExplosions = new List<Explosion>();
            rightExplosions = new List<Explosion>();
            allExplosions = new List<Explosion>();
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (Explosion e in upExplosions)
            {
                e.DrawRange(spriteBatch);
            }
            foreach (Explosion e in downExplosions)
            {
                e.DrawRange(spriteBatch);
            }
            foreach (Explosion e in leftExplosions)
            {
                e.DrawRange(spriteBatch);
            }
            foreach (Explosion e in rightExplosions)
            {
                e.DrawRange(spriteBatch);
            }

        }

        public void Update()
        {
            timer--;
            if (timer <= 0)
            {
                game.currentMap.finishedExplosionRange.Add(this);

            }
        }

        public void SetAllEplosions()
        {
            allExplosions = new List<Explosion>();
            allExplosions.AddRange(originExplosion);
            allExplosions.AddRange(upExplosions);
            allExplosions.AddRange(downExplosions);
            allExplosions.AddRange(leftExplosions);
            allExplosions.AddRange(rightExplosions);
        }
    }
}
