using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
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
