using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class KnightItem : BasicItem
    {
        public KnightItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getKnightItemSprite();
            this.sourceRec = SpriteConstants.KNIGHT_ITEM;
        }
        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            boostedPlayer = currentPlayer;
            currentPlayer.boosted = true;
            currentPlayer.boostedTimer = 1200;
            currentPlayer.boostFadeAmount = 1.0f;
            currentPlayer.spriteIndex = 1;
            currentPlayer.ApplyAbilities();
        }

        public override void Deactivate()
        {
            boostedPlayer.ChangeCharacter();
            base.Deactivate();
        }
    }
}
