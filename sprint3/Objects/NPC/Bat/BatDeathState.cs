using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.NPC.Bat
{
    class BatDeathState : IEnemyState
    {
        private Bat bat;
        private static Rectangle sourceRec;
        private Texture2D texture;

        public BatDeathState(Bat bat)
        {
            this.bat = bat;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = EnemyTextureStorage.Instance.getTombstoneSprite();
            sourceRec = SpriteConstants.TOMBSTONE;
            bat.DrawSprite(spriteBatch, texture, sourceRec);
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
            return bat.isDead;
        }
    }
}
