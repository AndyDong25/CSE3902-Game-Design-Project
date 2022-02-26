using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class NinjaStarItem : BasicItem
    {
        public NinjaStarItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            currentPlayer.hasNinjaStar = true;
        }
        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getNinjaStarSprite();
            this.sourceRec = SpriteConstants.NINJA_STAR;
        }
    }
}
