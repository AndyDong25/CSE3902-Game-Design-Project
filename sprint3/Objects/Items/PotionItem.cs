﻿using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework;

namespace CSE3902_Sprint2.Items
{
    class PotionItem : BasicItem
    {

        public PotionItem(Vector2 position, Game1 game) : base(position, game)
        {
            setTexture();
        }

        public override void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
            currentPlayer.potionCount++;
            activated = true;
        }

        public void setTexture()
        {
            this.texture = ItemTextureStorage.Instance.getPotionItemSprite();
            this.sourceRec = SpriteConstants.POTION_ITEM;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            boostedPlayer.potionCount--; ;
        }
    }
}
