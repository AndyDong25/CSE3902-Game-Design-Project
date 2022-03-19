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

        private Yeti yeti;


        private static List<Rectangle> mySources = SpriteConstants.YETI_WEST;

        public YetiFacingWestState(Yeti yeti)
        {

            this.yeti = yeti;
            framesLeft = (int)yeti.framePerStep;
            frameIndex = 0;
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
            framesLeft--;
            if (frameIndex > 2 && frameIndex < 8)
            {
                //yeti.acceleration += 0.01f;
                yeti.speed += yeti.acceleration;
                MoveLeft();
            }
            else
            {
                yeti.speed = 0.0f;
            }

            if (framesLeft == 0)
            {
                frameIndex = (frameIndex + 1) % 9;
                framesLeft = (int)yeti.framePerStep;
            }
        }
        public void UpdatePreviousPosition()
        {
            yeti.UpdatePreviousPosition();
        }
    }
}
