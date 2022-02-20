using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Objects.Player;
using sprint2.Objects.Bomb;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class PotionItem : BasicItem
    {

        public PotionItem()
        {
        }
        public override void Activate(Player currentPlayer)
        {
            /*TODO: This functionality cannot be implemented until
             * Bomb class is implemented
             */

        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getPotionItemSprite();
            this.sourceRec = SpriteConstants.POTION_ITEM;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            setTexture();
            Rectangle destination = new Rectangle(150, 100, 35, 35);
            spriteBatch.Draw(texture, destination, sourceRec, Color.White);
        }
    }
}
