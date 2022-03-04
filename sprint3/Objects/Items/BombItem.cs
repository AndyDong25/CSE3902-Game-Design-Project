using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class BombItem : BasicItem
    {
        public BombItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getBombItemSprite();
            this.sourceRec = SpriteConstants.BOMB_ITEM;
        }

        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            currentPlayer.maxBombs++;
        }


        public override void Deactivate()
        {
            base.Deactivate();
            boostedPlayer.maxBombs--;
            
        }
    }
}
