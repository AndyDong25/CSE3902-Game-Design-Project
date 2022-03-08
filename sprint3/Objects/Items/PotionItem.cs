using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class PotionItem : BasicItem
    {

        public PotionItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            if (currentPlayer.inventory["potion"] < currentPlayer.maxPotions)
            {
                boostedPlayer = currentPlayer;
                currentPlayer.inventory["potion"]++;
                currentPlayer.potionCount++;
            }
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getPotionItemSprite();
            this.sourceRec = SpriteConstants.POTION_ITEM;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            boostedPlayer.potionCount--; ;
        }
    }
}
