using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;
using Microsoft.Xna.Framework;
using System.Diagnostics;

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
            if (currentPlayer.inventory["bomb"] < currentPlayer.maxBombs)
            {
                currentPlayer.inventory["bomb"]++;
                currentPlayer.bombCount++;
            }
        }


        public override void Deactivate()
        {
            base.Deactivate();
            boostedPlayer.maxBombs--;
            
        }
    }
}
