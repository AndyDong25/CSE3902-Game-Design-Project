using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Fonts;
using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint3.Objects.Decorations;
using CSE3902_Project.Audio;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Objects.Items;

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
        private Texture2D randomMapTexture;
        private Texture2D goblinTexture;
        private Texture2D fogTexture;

        private Rectangle grassMapDestRec;
        private Rectangle iceMapDestRec;
        private Rectangle caveMapDestRec;
        private Rectangle waterMapDestRec;
        private Rectangle skyMapDestRec;
        private Rectangle randomMapDestRec;
        private Rectangle fogDestRec;
        private Vector2 explosionAssistancePos;
        private Rectangle expAssistanceDestRec;
        private SpriteFont font;
        private Vector2 textPos;
        private List<Rectangle> goblinSource;
        private Rectangle goblinDestRec;
        private bool coinMode;
        private bool helperMode;
        private Coin coin;
        private bool infiniteMode;
        private int idx = 0;
        private bool ifClicked = false;

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
            randomMapTexture  = DecorationTextureStorage.Instance.getQuestionMarkSprite();
            goblinTexture = PlayerTextureStorage.Instance.getGoblinSpriteSheet();
            fogTexture = ItemTextureStorage.Instance.getExplosionSprite();

            grassMapDestRec = new Rectangle(10, 30, 253, 220);
            iceMapDestRec = new Rectangle(273, 30, 253, 220);
            caveMapDestRec = new Rectangle(536, 30, 253, 220);
            waterMapDestRec = new Rectangle(10, 300, 253, 220);
            skyMapDestRec = new Rectangle(273, 300, 253, 220);
            randomMapDestRec = new Rectangle(536, 300, 253, 220);
            goblinDestRec = new Rectangle(540, 547, 40, 40);
            fogDestRec = new Rectangle(640, 547, 40, 40);

            explosionAssistancePos = new Vector2(310, 575);
            expAssistanceDestRec = new Rectangle(310, 575, 180, 20);
            textPos = new Vector2(340, 265);
            goblinSource = SpriteConstants.GOBLIN_SOUTH;
            AudioManager.Instance.PlayMapMusic(0);

            coinMode = game.coinMode;
            helperMode = game.HelperMode;
            coin = new Coin(new Vector2(440, 547), game);
            infiniteMode = game.infiniteMode;
            
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(menuBackgroundTexture, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.Draw(grassMapTexture, grassMapDestRec, Color.White);
            spriteBatch.Draw(iceMapTexture, iceMapDestRec, Color.White);
            spriteBatch.Draw(caveMapTexture, caveMapDestRec, Color.White);
            spriteBatch.Draw(waterMapTexture, waterMapDestRec, Color.White);
            spriteBatch.Draw(skyMapTexture, skyMapDestRec, Color.White);
            spriteBatch.Draw(randomMapTexture, randomMapDestRec, Color.White);
            
            spriteBatch.DrawString(font, "SELECT A MAP", textPos, Color.White);
            spriteBatch.DrawString(font, "COIN MODE?", new Vector2(330, 550), Color.White);

            coin.Draw(spriteBatch);
            if (game.fogMode)
            {
                spriteBatch.Draw(fogTexture, fogDestRec, SpriteConstants.EXPLOSION, Color.Red);
            }
            else
            {
                spriteBatch.Draw(fogTexture, fogDestRec, SpriteConstants.EXPLOSION, Color.Black);
            }
            
            if (!game.infiniteMode)
            {
                spriteBatch.Draw(goblinTexture, goblinDestRec,goblinSource[0], Color.White);
            }
            else
            {
                spriteBatch.Draw(goblinTexture, goblinDestRec, goblinSource[idx], Color.Red);
                idx = ((idx++ % 30) / 10);
            }


            if (game.HelperMode)
            {
                spriteBatch.DrawString(font, "Explosion Indictor: ON", explosionAssistancePos, Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, "Explosion Indictor: OFF", explosionAssistancePos, Color.White);
            }

        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            // detect left mouse clicks
            if (mouseState.LeftButton == ButtonState.Pressed && !ifClicked)
            {
                ifClicked = true;
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
                else if (randomMapDestRec.Contains(point))
                {
                    game.currentMap = game.mapList[6];
                    game.SetUpCurrentMap();
                    game.gameState.ChangeToGamePlay();
                }
                else if (coin.collider2D.Contains(point))
                {
                    game.coinMode = !game.coinMode;
                    coinMode = !coinMode;
                }
                else if (goblinDestRec.Contains(point))
                {
                    game.infiniteMode = !game.infiniteMode;
                    infiniteMode = !infiniteMode;
                }
                else if (fogDestRec.Contains(point))
                {
                    game.fogMode = !game.fogMode;
                }
                else if (expAssistanceDestRec.Contains(point))
                {
                    game.setHelperMode();
                }
            }
            else
            {
                ifClicked = mouseState.LeftButton == ButtonState.Pressed;
            }
            if (coinMode)
            {
                coin.Update();
            }
            
        }
    }
}
