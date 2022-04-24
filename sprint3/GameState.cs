using CSE3902_CSE3902_Project;
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

        private float gameOverTimer;
        private float displayWinTimer;
        private string WinCondition;
        
        enum State
        {
            GameMenu = 0,
            GamePlay = 1,
            PlayerWin = 2,
            GamePause = 3,
        }

        public GameState(Game1 game)
        {
            //currGameState = State.GameMenu;
            this.game = game;
            gameOverTimer = 6;
            displayWinTimer = 2;
            menuScreen = new MainMenu(game);
            WinCondition = "";
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

                case State.PlayerWin:
                    PlayerWinUpdate(gameTime);
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

                case State.PlayerWin:
                    PlayerWinDraw(spriteBatch);
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
            
            MouseState mouseState = Mouse.GetState();
            
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

        private void PlayerWinUpdate(GameTime gameTime)
        {
            
            
            gameOverTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            displayWinTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;


            bool displayWin = displayWinTimer <= 0.0f;
            bool reset = gameOverTimer <= 0.0f;


            bool player1Win = game.currentMap.player2.isDead || game.currentMap.player1.collect_coins == 10;

            float rate = 3.0f;
            Vector2 player1Pos = new Vector2(((int)game.currentMap.player1.xPos), ((int)game.currentMap.player1.yPos));
            Vector2 player2Pos = new Vector2(((int)game.currentMap.player2.xPos), ((int)game.currentMap.player2.yPos));

            if (player1Win)
            {
                 game.camera.Zoomin(rate);
                 game.camera.Move(player2Pos);
                 
            }
            else
             {
                    
                 game.camera.Zoomin(rate);
                 game.camera.Move(player1Pos);
                 
             }
            

            if (displayWin)
            {
                if (player1Win) {
                    game.camera.DisplayLocation(player1Pos);
                    WinCondition = "Player 1 has won the Round!";
                }
                else
                {

                    game.camera.DisplayLocation(player2Pos);
                    WinCondition = "Player 2 has won the Round!";
                    
                }
                


            }



            if (reset)
            {
                gameOverTimer = 4;
                if (game.currentMap.player1.isDead || game.currentMap.player2.collect_coins == 10)
                {
                    game.p2Wins++;
                }
                else if (game.currentMap.player2.isDead || game.currentMap.player1.collect_coins == 10)
                {
                    game.p1Wins++;
                }
                WinCondition = "";
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

            if (game.currentMap.myTime.getTime() <= 0 || game.currentMap.player1.isDead || game.currentMap.player2.isDead 
                || game.currentMap.player1.collect_coins == 10 || game.currentMap.player2.collect_coins == 10)
            {
                /*if (game.currentMap.player1.isDead || game.currentMap.player2.collect_coins == 10)
                {
                    game.camera.Zoomin(0.2f);
                    game.camera.Move(new Vector2(((int)game.currentMap.player1.xPos), ((int)game.currentMap.player1.yPos)));
                }
                if (game.currentMap.player2.isDead || game.currentMap.player1.collect_coins == 10)
                {
                    game.camera.Zoomin(0.2f);
                    game.camera.Move(new Vector2(((int)game.currentMap.player2.xPos), ((int)game.currentMap.player2.yPos)));
                }*/

                // try to implement something else instead of reseting map later
                PlayerWinUpdate(gameTime);
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

        private void PlayerWinDraw(SpriteBatch spriteBatch)
        {

            Vector2 camPosition = game.camera.direction;

            camPosition.X -= 100;

            Vector2 topTextLocation = camPosition;

            topTextLocation.Y += 25;

            Vector2 bottomTextLocation = camPosition;
            bottomTextLocation.Y += 50;
            bottomTextLocation.X += 20;

            SpriteFont font = SpriteFontStorage.Instance.getHudFont(); 
            spriteBatch.DrawString(font, "RESETTING MAP...", bottomTextLocation, Color.White);
            spriteBatch.DrawString(font, WinCondition, topTextLocation, Color.Blue);
            
        }

        private void GamePlayDraw(SpriteBatch spriteBatch)
        {
            game.currentMap.Draw(spriteBatch);
            if (game.currentMap.myTime.getTime() <= 0 || game.currentMap.player1.IsDead() || game.currentMap.player2.IsDead() || game.currentMap.player1.collect_coins == 10 || game.currentMap.player2.collect_coins == 10)
            {
                
                // try to implement something else instead of reseting map later
                PlayerWinDraw(spriteBatch);
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
            currGameState = State.PlayerWin;
        }



        public void ChangeToGamePlay()
        {
            currGameState = State.GamePlay;
        }
    }
}
