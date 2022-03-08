using CSE3902_CSE3902_Project;
using CSE3902_Project.Objects.Bomb;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Objects.Bomb
{
    public class ExplosionCross
    {
        public Explosion originExplosion;
        public List<Explosion> upExplosions;
        public List<Explosion> downExplosions;
        public List<Explosion> rightExplosions;
        public List<Explosion> leftExplosions;
        public List<Explosion> allExplosions;
        public int timer;
        private Game1 game;

        public ExplosionCross(Game1 game)
        {
            timer = 20;
            this.game = game;
            upExplosions = new List<Explosion>();
            downExplosions = new List<Explosion>();
            leftExplosions = new List<Explosion>();
            rightExplosions = new List<Explosion>();
            allExplosions = new List<Explosion>();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            originExplosion.Draw(spriteBatch, new Vector2(0, 0));
            foreach (Explosion e in upExplosions)
            {
                e.Draw(spriteBatch, new Vector2(0, 0));
            }
            foreach (Explosion e in downExplosions)
            {
                e.Draw(spriteBatch, new Vector2(0, 0));
            }
            foreach (Explosion e in leftExplosions)
            {
                e.Draw(spriteBatch, new Vector2(0, 0));
            }
            foreach (Explosion e in rightExplosions)
            {
                e.Draw(spriteBatch, new Vector2(0, 0));
            }
        }

        public void Update()
        {
            timer--;
            if (timer <= 0)
            {
                game.map.finishedExplosionCross.Add(this);
                //game.map.finishedExplosions.Add(this);
            }
        }

        public void SetAllEplosions()
        {
            allExplosions = new List<Explosion>();
            allExplosions.Add(originExplosion);
            allExplosions.AddRange(upExplosions);
            allExplosions.AddRange(downExplosions);
            allExplosions.AddRange(leftExplosions);
            allExplosions.AddRange(rightExplosions);
        }
    }
}
