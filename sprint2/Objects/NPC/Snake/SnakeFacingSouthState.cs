using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Objects.NPC.Snake
{
    class SnakeFacingSouthState : IEnemyState
    {
        private int framesLeft;
        private int frameIndex;
        private int timeCounter;
        private Snake snake;

        private static List<Rectangle> mySources = SpriteConstants.SNAKE_SOUTH;

        public SnakeFacingSouthState(Snake snake)
        {
            timeCounter = snake.r.Next(2, 12) * 10;
            this.snake = snake;
            framesLeft = (int)snake.framePerStep;
            frameIndex = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = EnemyTextureStorage.Instance.getSnakeSprite();
            Rectangle source = mySources[frameIndex];
            snake.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
            snake.yPos += snake.speed;
        }

        public void MoveLeft()
        {
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
                snake.currState = new SnakeFacingWestState(snake);
            }
            else
            {
                framesLeft--;
                if (framesLeft == 0)
                {
                    frameIndex = (frameIndex + 1) % 3;
                    framesLeft = (int)snake.framePerStep;
                }
                MoveDown();
            }
        }
    }
}
