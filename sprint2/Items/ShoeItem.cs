using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint2.Items
{
    class ShoeItem : BasicItem
    {
        
        public ShoeItem()
        {
            this.setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
            currentPlayer.speed += increaseAmount;
            

        }

        public override void Deactivate()
        {
            boostedPlayer.speed -= increaseAmount;
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getShoeItemSprite();
            this.sourceRec = SpriteConstants.SHOE_ITEM;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            setTexture();
            Rectangle destination = new Rectangle(150, 100, 35, 35);
            spriteBatch.Draw(texture, destination, sourceRec, Color.White);
        }

    }
}
