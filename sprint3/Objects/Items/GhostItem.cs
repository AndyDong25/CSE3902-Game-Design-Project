using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using Microsoft.Xna.Framework;

namespace CSE3902_CSE3902_Project.Items
{
    class GhostItem : BasicItem
    {
        public GhostItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getGhostItemSprite();
            this.sourceRec = SpriteConstants.GHOST_ITEM;
        }
        public override void Activate(Player currentPlayer)
        {
            base.Activate(currentPlayer);
            boostedPlayer = currentPlayer;
            currentPlayer.spriteIndex = 3;
            currentPlayer.ApplyAbilities();
        }

        public override void Deactivate()
        {       
            boostedPlayer.ChangeCharacter();
            base.Deactivate();
        }
    }
}
