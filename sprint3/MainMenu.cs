using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Fonts;
using CSE3902_Project.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint3.Objects.Decorations;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3
{
    public class MainMenu : ISprite
    {
        private Game1 game;

        private Texture2D menuBackgroundTexture;
        private Texture2D grassMapTexture;
        private Texture2D iceMapTexture;
        private Texture2D caveMapTexture;
        private Texture2D waterMapTexture;
        private Texture2D skyMapTexture;

        private Rectangle grassMapDestRec;
        private Rectangle iceMapDestRec;
        private Rectangle caveMapDestRec;
        private Rectangle waterMapDestRec;
        private Rectangle skyMapDestRec;

        private SpriteFont font;
        private Vector2 textPos;

        private bool coinMode;
        private Coin coin;



        public MainMenu(Game1 game)
        {
            this.game = game;
            font = SpriteFontStorage.Instance.getHudFont();
            menuBackgroundTexture = DecorationTextureStorage.Instance.getMenuBackgroundSprite();
            grassMapTexture = DecorationTextureStorage.Instance.getGrassBackgroundSprite();
            iceMapTexture = DecorationTextureStorage.Instance.getIceBackGroundSprite();
            caveMapTexture = DecorationTextureStorage.Instance.getDirtBackgroundSprite();
            waterMapTexture = DecorationTextureStorage.Instance.getWaterBackgroundSprite();
            skyMapTexture = DecorationTextureStorage.Instance.getSkyBackgroundSprite();

            grassMapDestRec = new Rectangle(10, 30, 253, 220);
            iceMapDestRec = new Rectangle(273, 30, 253, 220);
            caveMapDestRec = new Rectangle(536, 30, 253, 220);
            waterMapDestRec = new Rectangle(130, 300, 253, 220);
            skyMapDestRec = new Rectangle(450, 300, 253, 220);

            textPos = new Vector2(340, 265);

            coinMode = game.coinMode;
            coin = new Coin(new Vector2(440, 547), game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuBackgroundTexture, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.Draw(grassMapTexture, grassMapDestRec, Color.White);
            spriteBatch.Draw(iceMapTexture, iceMapDestRec, Color.White);
            spriteBatch.Draw(caveMapTexture, caveMapDestRec, Color.White);
            spriteBatch.Draw(waterMapTexture, waterMapDestRec, Color.White);
            spriteBatch.Draw(skyMapTexture, skyMapDestRec, Color.White);
            spriteBatch.DrawString(font, "SELECT A MAP", textPos, Color.White);
            spriteBatch.DrawString(font, "COIN MODE?", new Vector2(330, 550), Color.White);
            coin.Draw(spriteBatch);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            // detect left mouse clicks
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Point point = new Point(mouseState.X, mouseState.Y);
                // go to gameplay state for corresponding map
                if (grassMapDestRec.Contains(point))
                {
                    game.currentMap = game.mapList[0];
                    game.SetUpCurrentMap();
                    game.gameState.ChangeToGamePlay();
                }
                else if (iceMapDestRec.Contains(point))
                {
                    game.currentMap = game.mapList[1];
                    game.SetUpCurrentMap();
                    game.gameState.ChangeToGamePlay();
                }
                else if (caveMapDestRec.Contains(point))
                {
                    game.currentMap = game.mapList[2];
                    game.SetUpCurrentMap();
                    game.gameState.ChangeToGamePlay();
                }
                else if (waterMapDestRec.Contains(point))
                {
                    game.currentMap = game.mapList[3];
                    game.SetUpCurrentMap();
                    game.gameState.ChangeToGamePlay();
                }
                else if (skyMapDestRec.Contains(point))
                {
                    game.currentMap = game.mapList[5];
                    game.SetUpCurrentMap();
                    game.gameState.ChangeToGamePlay();
                }
                else if (coin.collider2D.Contains(point))
                {
                    game.coinMode = !game.coinMode;
                    coinMode = !coinMode;
                }
            }
            if (coinMode)
            {
                coin.Update();
            }
        }
    }
}
