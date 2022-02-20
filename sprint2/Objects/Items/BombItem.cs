using System;
using System.Collections.Generic;
using CSE3902_Sprint2.Objects.Player;
using sprint2.Objects.Bomb;
using CSE3902_Sprint2.Sprites;
using System.Text;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class BombItem : BasicItem
    {
        public BombItem()
        {
            this.setTexture();
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getBombItemSprite();
            this.sourceRec = SpriteConstants.BOMB_ITEM;
        }

        public override void Activate(Player currentPlayer)
        {
            /*TODO: bomb delay timer must be implemented in player class first
            * before this functionality can be added */
             

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            setTexture();
            Rectangle destination = new Rectangle(150, 100, 35, 35);
            spriteBatch.Draw(texture, destination, sourceRec, Color.White);
        }

    }
}
