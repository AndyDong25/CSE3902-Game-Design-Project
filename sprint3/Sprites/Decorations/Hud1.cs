using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Fonts;
using CSE3902_Project.Map;
using CSE3902_Project.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace sprint3.Sprites.Decorations
{
    public class Hud1 : ISprite
    {
        public Texture2D hudBackgroundTexture { get; set; }
        private Texture2D bombIconTexture;
        private Texture2D potionIconTexture;
        private Texture2D shoeIconTexture;
        private Texture2D coinIconTexture;

        private Rectangle backgroundDestRec;

        private Rectangle p1BombDestRec;
        private Rectangle p1PotionDestRec;
        private Rectangle p1ShoeDestRec;
        private Rectangle p1CoinDestRec;

        private Rectangle p2BombDestRec;
        private Rectangle p2PotionDestRec;
        private Rectangle p2ShoeDestRec;
        private Rectangle p2CoinDestRec;

        private Map1 map;
        private Game1 game;

        private SpriteFont font;
        private SpriteFont scoreFont;

        private Vector2 p1ScorePos;
        private Vector2 p2ScorePos;

        public Vector2 pos;
        public Hud1(Vector2 pos, Game1 game, Map1 map)
        {
            this.map = map;
            this.game = game;
            this.pos = pos;

            font = SpriteFontStorage.Instance.getHudFont();
            scoreFont = SpriteFontStorage.Instance.getScoreFont();

            hudBackgroundTexture = DecorationTextureStorage.Instance.getHudBackgroundSprite();
            bombIconTexture = ItemTextureStorage.Instance.getBombItemSprite();
            potionIconTexture = ItemTextureStorage.Instance.getPotionItemSprite();
            shoeIconTexture = ItemTextureStorage.Instance.getShoeItemSprite();
            coinIconTexture = ItemTextureStorage.Instance.getCoinItemSprite();

            backgroundDestRec = new Rectangle((int)pos.X, (int)pos.Y, 800, 120);
            p1BombDestRec = new Rectangle(100, 500, 20, 20);
            p1PotionDestRec = new Rectangle(100, 530, 20, 20);
            p1ShoeDestRec = new Rectangle(100, 560, 20, 20);
            p1CoinDestRec = new Rectangle(160, 530, 20, 20);

            p2BombDestRec = new Rectangle(650, 500, 20, 20);
            p2PotionDestRec = new Rectangle(650, 530, 20, 20);
            p2ShoeDestRec = new Rectangle(650, 560, 20, 20);
            p2CoinDestRec = new Rectangle(590, 530, 20, 20);

            p1ScorePos = new Vector2(370, 530);
            p2ScorePos = new Vector2(410, 530);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hudBackgroundTexture, backgroundDestRec, Color.White);
            spriteBatch.Draw(bombIconTexture, p1BombDestRec, SpriteConstants.BOMB_ITEM, Color.White);
            spriteBatch.DrawString(font, "X" + map.player1.inventory["bomb"], new Vector2(p1BombDestRec.X + 20, p1BombDestRec.Y), Color.White);
            spriteBatch.Draw(potionIconTexture, p1PotionDestRec, SpriteConstants.POTION_ITEM, Color.White);
            spriteBatch.DrawString(font, "X" + map.player1.inventory["potion"], new Vector2(p1PotionDestRec.X + 20, p1PotionDestRec.Y), Color.White);
            spriteBatch.Draw(shoeIconTexture, p1ShoeDestRec, SpriteConstants.SHOE_ITEM, Color.White);
            spriteBatch.DrawString(font, "X" + map.player1.inventory["shoe"], new Vector2(p1ShoeDestRec.X + 20, p1ShoeDestRec.Y), Color.White);
            if (game.coinMode)
            {
                spriteBatch.Draw(coinIconTexture, p1CoinDestRec, SpriteConstants.COIN, Color.White);
                spriteBatch.DrawString(font, "X" + map.player1.collect_coins, new Vector2(p1CoinDestRec.X + 20, p1CoinDestRec.Y), Color.White);
            }

            spriteBatch.Draw(bombIconTexture, p2BombDestRec, SpriteConstants.BOMB_ITEM, Color.White);
            spriteBatch.DrawString(font, "X" + map.player2.inventory["bomb"], new Vector2(p2BombDestRec.X + 20, p1BombDestRec.Y), Color.White);
            spriteBatch.Draw(potionIconTexture, p2PotionDestRec, SpriteConstants.POTION_ITEM, Color.White);
            spriteBatch.DrawString(font, "X" + map.player2.inventory["potion"], new Vector2(p2PotionDestRec.X + 20, p2PotionDestRec.Y), Color.White);
            spriteBatch.Draw(shoeIconTexture, p2ShoeDestRec, SpriteConstants.SHOE_ITEM, Color.White);
            spriteBatch.DrawString(font, "X" + map.player2.inventory["shoe"], new Vector2(p2ShoeDestRec.X + 20, p2ShoeDestRec.Y), Color.White);
            if (game.coinMode)
            {
                spriteBatch.Draw(coinIconTexture, p2CoinDestRec, SpriteConstants.COIN, Color.White);
                spriteBatch.DrawString(font, "X" + map.player2.collect_coins, new Vector2(p2CoinDestRec.X + 20, p2CoinDestRec.Y), Color.White);
            }

            spriteBatch.DrawString(scoreFont, game.p1Wins.ToString(), p1ScorePos, Color.White);
            spriteBatch.DrawString(scoreFont, "-", new Vector2(393, 527), Color.White);
            spriteBatch.DrawString(scoreFont, game.p2Wins.ToString(), p2ScorePos, Color.White);
        }

        public void Update()
        {
        }
    }
}
