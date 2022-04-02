using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CSE3902_Project.Objects.NPC.Bat
{
    class BatFacingEastState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;
        private int timeCounter;
        private Bat bat;

        private static List<Rectangle> mySources = SpriteConstants.BAT_EAST;

        public BatFacingEastState(Bat bat)
        {
            timeCounter = bat.timeCounter + 40;
            this.bat = bat;
            framesLeft = (int)bat.framePerStep;
            frameIndex = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = EnemyTextureStorage.Instance.getBatSprite();
            Rectangle source = mySources[frameIndex];
            bat.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            bat.xPos += bat.speed;
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
                bat.currState = new BatFacingWestState(bat);
            }
            else
            {
                framesLeft--;
                if (framesLeft == 0)
                {
                    frameIndex = (frameIndex + 1) % 3;
                    framesLeft = (int)bat.framePerStep;
                }
                MoveRight();
            }
        }
        public void UpdatePreviousPosition()
        {
            bat.UpdatePreviousPosition();
        }
        public bool IsDead()
        {
            return bat.isDead;
        }
    }
}
