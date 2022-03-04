using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.NPC
{
    class EnemyDeathState : IEnemyState
    {
        private Enemy enemy;
        private static Rectangle sourceRec;
        private Texture2D texture;

        public EnemyDeathState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = EnemyTextureStorage.Instance.getTombstoneSprite();
            sourceRec = SpriteConstants.TOMBSTONE;
            enemy.DrawSprite(spriteBatch, texture, sourceRec);
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
