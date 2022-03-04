using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.NPC.Snake
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
