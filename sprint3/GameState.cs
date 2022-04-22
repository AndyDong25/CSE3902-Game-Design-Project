﻿using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Controller;
using CSE3902_Project.Fonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace sprint3
{
    public class GameState
    {
        private MainMenu menuScreen;
        private Game1 game;
        private State currGameState;
        private float timer;

        enum State
        {
            GameMenu = 0,
            GamePlay = 1,
            GameOver = 2,
            GamePause = 3,
        }

        public GameState(Game1 game)
        {
            //currGameState = State.GameMenu;
            this.game = game;
            timer = 4;
            menuScreen = new MainMenu(game);
        }

        public void Update(GameTime gameTime)
        {
            switch (currGameState)
            {
                case State.GameMenu:
                    GameMenuUpdate();
                    break;

                case State.GamePause:
                    GamePauseUpdate();
                    break;

                case State.GameOver:
                    GameOverUpdate(gameTime);
                    break;

                case State.GamePlay:
                    GamePlayUpdate(gameTime);
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currGameState)
            {
                case State.GameMenu:
                    GameMenuDraw(spriteBatch);
                    break;

                case State.GamePause:
                    GamePauseDraw(spriteBatch);
                    break;

                case State.GameOver:
                    GameOverDraw(spriteBatch);
                    break;

                case State.GamePlay:
                    GamePlayDraw(spriteBatch);
                    break;
            }
        }

        private void GameMenuUpdate()
        {
            // mouse controller
            menuScreen.Update();
        }

        private void GamePauseUpdate()
        {
            // maybe resume game with mouse click?
            MouseState mouseState = Mouse.GetState();
            // detect left mouse clicks
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                ChangeToGamePlay();
            }
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                ChangeToGameMenu();
                game.Reset();
            }
        }

        private void GameOverUpdate(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0.0f)
            {
                timer = 4;
                if (game.currentMap.player1.isDead)
                {
                    game.p2Wins++;
                }
                else if (game.currentMap.player2.isDead)
                {
                    game.p1Wins++;
                }
                game.Reset();
            }
        }

        private void GamePlayUpdate(GameTime gameTime)
        {
            foreach (IController controller in game.controllerList)
            {
                controller.Update();
            }

            game.currentMap.Update(gameTime);

            if (game.currentMap.myTime.getTime() <= 0 || game.currentMap.player1.isDead || game.currentMap.player2.isDead || game.currentMap.player1.collect_coins == 10 || game.currentMap.player2.collect_coins == 10)
            {
                // try to implement something else instead of reseting map later
                GameOverUpdate(gameTime);
                // game.Reset();
            }
        }

        private void GameMenuDraw(SpriteBatch spriteBatch)
        {
            menuScreen.Draw(spriteBatch);
        }

        private void GamePauseDraw(SpriteBatch spriteBatch)
        {
            // do nothing - game is paused
            SpriteFont font = SpriteFontStorage.Instance.getHudFont();
            spriteBatch.DrawString(font, "LEFT CLICK TO RESUME", new Vector2(290, 250), Color.White);
            spriteBatch.DrawString(font, "RIGHT CLICK TO GO TO MAIN MENU", new Vector2(250, 280), Color.White);
        }

        private void GameOverDraw(SpriteBatch spriteBatch)
        {
            SpriteFont font = SpriteFontStorage.Instance.getHudFont();
            spriteBatch.DrawString(font, "RESETTING MAP...", new Vector2(300, 250), Color.White);
        }

        private void GamePlayDraw(SpriteBatch spriteBatch)
        {
            game.currentMap.Draw(spriteBatch);
            if (game.currentMap.myTime.getTime() <= 0 || game.currentMap.player1.isDead || game.currentMap.player2.isDead || game.currentMap.player1.collect_coins == 10 || game.currentMap.player2.collect_coins == 10)
            {
                // try to implement something else instead of reseting map later
                GameOverDraw(spriteBatch);
                // game.Reset();
            }
        }

        public void ChangeToGameMenu()
        {
            currGameState = State.GameMenu;
        }
        public void ChangeToGamePause()
        {
            currGameState = State.GamePause;
        }
        public void ChangeToGameOver()
        {
            currGameState = State.GameOver;
        }
        public void ChangeToGamePlay()
        {
            currGameState = State.GamePlay;
        }
    }
}