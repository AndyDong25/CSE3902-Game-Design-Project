using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.NPC.Yeti
{
    class YetiDeathState : IEnemyState
    {
        private Yeti yeti;
        private static Rectangle sourceRec;
        private Texture2D texture;

        public YetiDeathState(Yeti yeti)
        {
            this.yeti = yeti;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = EnemyTextureStorage.Instance.getTombstoneSprite();
            sourceRec = SpriteConstants.TOMBSTONE;
            yeti.DrawSprite(spriteBatch, texture, sourceRec);
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
        public void UpdatePreviousPosition()
        {
        }
        public bool IsDead()
        {
            return yeti.isDead;
        }
    }
}
