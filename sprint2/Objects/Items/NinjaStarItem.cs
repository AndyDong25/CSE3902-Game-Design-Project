using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Objects.Player;
using System.Text;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class NinjaStarItem : BasicItem
    {
        public NinjaStarItem()
        {
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
        public override void Draw(SpriteBatch spriteBatch)
        {
            setTexture();
            Rectangle destination = new Rectangle(150, 100, 35, 35);
            spriteBatch.Draw(texture, destination, sourceRec, Color.White);
        }
    }
}
