using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902_Sprint0
{
    class MouseController : IController
    {
        public Game1 Game { get; set; }

        public MouseController(Game1 game)
        {
            Game = game;
           
        }
        
        public void Update()
        {
            int mouseX, mouseY;
            int frameHeight = Game.GraphicsDevice.PresentationParameters.BackBufferHeight;
            int frameWidth = Game.GraphicsDevice.PresentationParameters.BackBufferWidth;
            MouseState mouseState = Mouse.GetState();

            // Update our sprites position to the current cursor 
           
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            
            // Check if Right Mouse Button pressed, if so, exit
            if (mouseState.RightButton == ButtonState.Pressed) { 
               Game.Exit();
            }

            else if (mouseState.LeftButton == ButtonState.Pressed){
                if (mouseX > frameWidth / 2)
                {
                    if (mouseY > frameHeight / 2)
                    {
                        Game.marioMoves = Game1.MarioMovement.MovingAnimated;
                    }
                    else
                    {
                        Game.marioMoves = Game1.MarioMovement.MovingStatic;
                    }
                }
                else
                {
                    if (mouseY > frameHeight / 2)
                    {
                        Game.marioMoves = Game1.MarioMovement.NonMovingAnimated;
                    }
                    else
                    {
                        Game.marioMoves = Game1.MarioMovement.NonMovingStatic;
                    }
                }
            }

        }
    }
}
