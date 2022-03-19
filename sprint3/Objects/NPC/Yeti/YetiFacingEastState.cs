using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace CSE3902_Project.Objects.NPC.Yeti
{
    class YetiFacingEastState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;


        private Yeti yeti;


        private static List<Rectangle> mySources = SpriteConstants.YETI_EAST;

        public YetiFacingEastState(Yeti yeti)
        {

            this.yeti = yeti;
            framesLeft = (int)yeti.framePerStep;
            frameIndex = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = EnemyTextureStorage.Instance.getYetiRightSprite();
            Rectangle source = mySources[frameIndex];
            yeti.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            yeti.xPos += yeti.speed;
        }

        public void MoveUp()
        {
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            if (frameIndex == 8) yeti.speed = 0;
            //yeti.acceleration += 0.01f;
            yeti.speed += yeti.acceleration;
            framesLeft--;
            MoveRight();
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
