using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class ShoeItem : BasicItem
    {
        
        public ShoeItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            if (currentPlayer.inventory["shoe"] < currentPlayer.maxShoes)
            {
                boostedPlayer = currentPlayer;
                currentPlayer.inventory["shoe"]++;
                currentPlayer.speed++;
            }
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
