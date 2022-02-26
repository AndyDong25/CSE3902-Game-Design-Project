using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class GoblinItem : BasicItem
    {
        public GoblinItem(Vector2 position, Game1 game) : base(position, game)
        {
            this.setTexture();
        }

        public void setTexture()
        {
            texture = ItemTextureStorage.Instance.getGoblinItemSprite();
            this.sourceRec = SpriteConstants.GOBLIN_ITEM;
        }

        public override void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
            currentPlayer.spriteIndex = 2;
            currentPlayer.ApplyAbilities();
        }

        public override void Deactivate()
        {
            
        }
    }
}
