using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Objects.NPC.Snake
{
    class SnakeDeathState : IEnemyState
    {
        private Snake snake;
        private static Rectangle sourceRec;
        private Texture2D texture;

        public SnakeDeathState(Snake snake)
        {
            this.snake = snake;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = EnemyTextureStorage.Instance.getTombstoneSprite();
            sourceRec = SpriteConstants.TOMBSTONE;
            snake.DrawSprite(spriteBatch, texture, sourceRec);
        }

        public void Update()
        {
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
        }

        public void TakeDamage()
        {


        }
    }
}
