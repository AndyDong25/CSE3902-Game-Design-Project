using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Items
{
    class GhostItem : BasicItem
    {
        public GhostItem()
        {
            this.setTexture();
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getGhostItemSprite();
            this.sourceRec = SpriteConstants.GHOST_ITEM;
        }
        public override void Activate(Player currentPlayer)
        {
            currentPlayer.ChangeCharacter();

        }

        public override void Deactivate()
        {
            boostedPlayer.ChangeCharacter();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            setTexture();
            Rectangle destination = new Rectangle(150, 100, 35, 35);
            spriteBatch.Draw(texture, destination, sourceRec, Color.White);
        }
    }
}
