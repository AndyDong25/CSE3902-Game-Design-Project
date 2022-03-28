using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class TorpedoItem : BasicItem
    {
        public TorpedoItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            if (currentPlayer.inventory["torpedo"] < 3)
            {
                currentPlayer.inventory["torpedo"]++;
            }
        }
        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getTorpedoItemSprite();
            this.sourceRec = SpriteConstants.TORPEDO;
        }


    }
}

