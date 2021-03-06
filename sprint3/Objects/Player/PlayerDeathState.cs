using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Audio;

namespace CSE3902_CSE3902_Project.Objects.Player
{
    class PlayerDeathState : IPlayerState
    {
        private Player player;
        private static Rectangle sourceRec;
        private Texture2D texture;
        public PlayerDeathState(Player player)
        {
            
            this.player = player;
            player.maxBombs = 0;
            //if (!player.IsDead() && player.CheateMode==false)
                if (!player.IsDead() && player.CheateMode == false)
                {
                AudioManager.Instance.PlayPlayerEliminated();
                player.isDead = true;
            }
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
