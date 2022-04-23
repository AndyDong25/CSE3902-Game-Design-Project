using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.NPC.AIPlayer
{
    class AIPlayerDeathState : IEnemyState
    {
        private AIPlayer aiplayer;
        private static Rectangle sourceRec;
        private Texture2D texture;

        public AIPlayerDeathState(AIPlayer aiplayer)
        {
            this.aiplayer = aiplayer;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = EnemyTextureStorage.Instance.getTombstoneSprite();
            sourceRec = SpriteConstants.TOMBSTONE;
            aiplayer.DrawSprite(spriteBatch, texture, sourceRec);
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
            return aiplayer.isDead;
        }
    }
}

