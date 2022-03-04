using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class ShoeItem : BasicItem
    {
        
        public ShoeItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
            currentPlayer.speed += increaseAmount;
        }

        public override void Deactivate()
        {
            boostedPlayer.speed -= increaseAmount;
            base.Deactivate();
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getShoeItemSprite();
            this.sourceRec = SpriteConstants.SHOE_ITEM;
        }
    }
}
