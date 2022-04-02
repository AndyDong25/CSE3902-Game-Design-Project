using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace CSE3902_Project.Objects.NPC.Alien
{
    class AlienFacingNorthState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;
        
        private Alien alien;

        Random actionSelect = new Random();
        int actionProba;


        private static List<Rectangle> mySources = SpriteConstants.ALIEN_NORTH;

        public AlienFacingNorthState(Alien alien)
        {
            
            this.alien = alien;
            framesLeft = (int)alien.framePerStep;
            frameIndex = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = EnemyTextureStorage.Instance.getAlienSprite();
            Rectangle source = mySources[frameIndex];
            alien.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
            alien.yPos -= alien.speed;
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            actionProba = actionSelect.Next(0, 10);
            if (actionProba <= 2)
            {
                alien.currState = new AlienFacingEastState(alien);
            }
            else if (actionProba > 2 && actionProba < 4)
            {
                alien.currState = new AlienFacingSouthState(alien);
            }
            else
            {
                framesLeft--;
                if (framesLeft == 0)
                {
                    frameIndex = (frameIndex + 1) % 3;
                    framesLeft = (int)alien.framePerStep;
                }
                MoveUp();
            }
        }
        public void UpdatePreviousPosition()
        {
            alien.UpdatePreviousPosition();
        }
        public bool IsDead()
        {
            return alien.isDead;
        }
    }
}
