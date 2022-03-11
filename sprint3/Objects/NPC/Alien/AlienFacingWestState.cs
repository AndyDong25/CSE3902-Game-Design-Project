using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CSE3902_Project.Objects.NPC.Alien
{
    class AlienFacingWestState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;
        private int timeCounter;
        private Alien alien;

        private static List<Rectangle> mySources = SpriteConstants.ALIEN_WEST;

        public AlienFacingWestState(Alien alien)
        {
            timeCounter = alien.timeCounter + 40;
            this.alien = alien;
            framesLeft = (int)alien.framePerStep;
            frameIndex = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = EnemyTextureStorage.Instance.getBatSprite();
            Rectangle source = mySources[frameIndex];
            alien.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
            alien.xPos -= alien.speed;
        }

        public void MoveRight()
        {
        }

        public void MoveUp()
        {
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            timeCounter--;
            if (timeCounter == 0)
            {
                alien.currState = new AlienFacingEastState(alien);
            }
            else
            {
                framesLeft--;
                if (framesLeft == 0)
                {
                    frameIndex = (frameIndex + 1) % 3;
                    framesLeft = (int)alien.framePerStep;
                }
                MoveLeft();
            }
        }
    }
}
