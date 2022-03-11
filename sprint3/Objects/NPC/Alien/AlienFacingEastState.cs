using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CSE3902_Project.Objects.NPC.Alien
{
    class AlienFacingEastState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;
        private int timeCounter;
        private Alien alien;

        private static List<Rectangle> mySources = SpriteConstants.BAT_EAST;

        public AlienFacingEastState(Alien alien)
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
        }

        public void MoveRight()
        {
            alien.xPos += alien.speed;
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
                alien.currState = new AlienFacingWestState(alien);
            }
            else
            {
                framesLeft--;
                if (framesLeft == 0)
                {
                    frameIndex = (frameIndex + 1) % 3;
                    framesLeft = (int)alien.framePerStep;
                }
                MoveRight();
            }
        }
    }
}
