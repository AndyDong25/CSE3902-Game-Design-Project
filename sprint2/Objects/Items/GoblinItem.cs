using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Objects.Player;
using System.Text;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class GoblinItem : BasicItem
    {
        public GoblinItem()
        {
            this.setTexture();
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getGoblinItemSprite();
            this.sourceRec = SpriteConstants.GOBLIN_ITEM;
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
