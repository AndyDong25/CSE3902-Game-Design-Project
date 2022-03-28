using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Sprites.Decorations
{
    public class Hud1 : ISprite
    {
        public Texture2D hudBackgroundTexture { get; set; }
        private Texture2D bombIconTexture;
        private Texture2D potionIconTexture;
        private Texture2D shoeIconTexture;
        private Texture2D itemIconTexture;

        private Rectangle backgroundDestRec;

        private Rectangle p1BombDestRec;
        private Rectangle p1PotionDestRec;
        private Rectangle p1ShoeDestRec;

        private Rectangle p2BombDestRec;
        private Rectangle p2PotionDestRec;
        private Rectangle p2ShoeDestRec;


        public Vector2 pos;
        public Hud1(Vector2 pos)
        {
            this.pos = pos;

            hudBackgroundTexture = DecorationTextureStorage.Instance.getHudBackgroundSprite();
            bombIconTexture = ItemTextureStorage.Instance.getBombItemSprite();
            potionIconTexture = ItemTextureStorage.Instance.getPotionItemSprite();
            shoeIconTexture = ItemTextureStorage.Instance.getShoeItemSprite();
            itemIconTexture = ItemTextureStorage.Instance.getNinjaStarSprite();

            backgroundDestRec = new Rectangle((int)pos.X, (int)pos.Y, 800, 120);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hudBackgroundTexture, backgroundDestRec, Color.White);
        }

        public void Update()
        {
        }
    }
}
