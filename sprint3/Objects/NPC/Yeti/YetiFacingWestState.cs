using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace CSE3902_Project.Objects.NPC.Yeti
{
    class YetiFacingWestState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;
        private int delayTimer;
        private bool loopRollAnimation;
        private int numLoops;
        private Yeti yeti;
        Random r = new Random();

        private static List<Rectangle> mySources = SpriteConstants.YETI_WEST;

        public YetiFacingWestState(Yeti yeti)
        {
            this.yeti = yeti;
            framesLeft = (int)yeti.framePerStep;
            frameIndex = 0;
            loopRollAnimation = false;
            numLoops = 5;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = EnemyTextureStorage.Instance.getYetiLeftSprite();
            Rectangle source = mySources[frameIndex];
            yeti.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
            yeti.xPos -= yeti.speed;
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
            if (frameIndex > 2 && frameIndex < 8)
            {
                yeti.speed = 3.0f;
                //yeti.acceleration += 0.01f;
                //yeti.speed += yeti.acceleration;
                MoveLeft();
            }
            else
            {
                yeti.speed = 0.0f;
            }

            if (framesLeft <= 0)
            {
                frameIndex = (frameIndex + 1) % 9;
                if (frameIndex == 8)
                {
                    framesLeft = 60;
                }
                else
                {
                    framesLeft = (int)yeti.framePerStep;
                }
                if (frameIndex == 0 && r.Next(0, 2) == 1)
                {
                    yeti.currState = new YetiFacingEastState(yeti);
                }
            }
            framesLeft--;
        }
        public void UpdatePreviousPosition()
        {
            yeti.UpdatePreviousPosition();
        }

    }
}
