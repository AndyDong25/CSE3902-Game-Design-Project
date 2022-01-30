using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902_Sprint0
{
    class KeyboardController : IController
    {
        public Game1 Game { get; set; }

        public KeyboardController(Game1 game)
        {
            Game = game;
        }

        public void Update()
        {

            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.Q)) {
                Game.Exit();
            }
            else if(keyboardState.IsKeyDown(Keys.W))
            {
               
                Game.marioMoves = Game1.MarioMovement.Nowhere;
            }
            else if(keyboardState.IsKeyDown(Keys.E))
            {
                Game.marioMoves = Game1.MarioMovement.NonMovingStatic;
            }
            else if(keyboardState.IsKeyDown(Keys.R))
            {
                Game.marioMoves = Game1.MarioMovement.MovingStatic;
            }
            else if(keyboardState.IsKeyDown(Keys.T))
            {
                
                Game.marioMoves = Game1.MarioMovement.NonMovingAnimated;
            }
            else if (keyboardState.IsKeyDown(Keys.Y))
            {

                Game.marioMoves = Game1.MarioMovement.MovingAnimated;
            }
        }
    }
}
