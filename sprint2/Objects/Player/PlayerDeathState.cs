using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint2.Objects.Player
{
    class PlayerDeathState : IPlayerState
    {
        private Player player;
        private static Rectangle sourceRec;
        private Texture2D texture;

        public PlayerDeathState(Player player)
        {
            this.player = player;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = PlayerTextureStorage.Instance.getTombstoneSprite();
            sourceRec = SpriteConstants.TOMBSTONE;
            player.DrawSprite(spriteBatch, texture, sourceRec);
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
