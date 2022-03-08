using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class NinjaStarItem : BasicItem
    {
        public NinjaStarItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            currentPlayer.inventory["ninjaStar"]++;
        }
        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getNinjaStarSprite();
            this.sourceRec = SpriteConstants.NINJA_STAR;
        }


    }
}
