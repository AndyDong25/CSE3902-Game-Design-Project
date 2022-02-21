using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
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
            /*TODO: bomb delay timer must be implemented in player class first
            * before this functionality can be added */
        }
    }
}
