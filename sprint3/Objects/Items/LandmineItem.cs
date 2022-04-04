using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class LandmineItem : BasicItem
    {
        public LandmineItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            if (currentPlayer.inventory["landmine"] < 3)
            {
                currentPlayer.inventory["landmine"]++;
            }
        }
        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getLandmineItemSprite();
            this.sourceRec = SpriteConstants.LANDMINE;
        }


    }
}

