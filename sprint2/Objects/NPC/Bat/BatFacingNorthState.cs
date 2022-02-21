using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint2.Objects.NPC.Bat
{
    class BatFacingNorthState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;
        private int timeCounter;
        private Bat bat;

        private static List<Rectangle> mySources = SpriteConstants.BAT_NORTH;

        public BatFacingNorthState(Bat bat)
        {
            timeCounter = bat.timeCounter;
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
        }

        public void MoveUp()
        {
            bat.yPos -= bat.speed;
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            timeCounter--;
            if (timeCounter == 0)
            {
                bat.currState = new BatFacingSouthState(bat);
            }
            else
            {
                framesLeft--;
                if (framesLeft == 0)
                {
                    frameIndex = (frameIndex + 1) % 3;
                    framesLeft = (int)bat.framePerStep;
                }
                MoveUp();
            }
        }
    }
}
