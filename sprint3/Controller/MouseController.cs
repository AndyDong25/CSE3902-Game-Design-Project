using CSE3902_CSE3902_Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CSE3902_CSE3902_Project.Controller
{
    class MouseController : IController
    {
        private Game1 game;
        private Boolean previousLeft = false;
        public MouseController(Game1 game)
        {
            this.game = game;      
            
        }
        
        public void Update()
        {
            int mouseX, mouseY;
           
            MouseState mouseState = Mouse.GetState();
          
            Dictionary<ICommand, bool[]> commandDirct = new Dictionary<ICommand, bool[]>();
            ICommand changeMap = new ChangeMapCommand(game);
            mouseX = mouseState.X;
            mouseY = mouseState.Y;

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                if (!previousLeft)
                {
                    changeMap.Execute();
                    previousLeft = true;
                }


                /*foreach (KeyValuePair<ICommand, bool[]> command in commandDirct)
                {
                    if (((mouseX > frameWidth / 2) == command.Value[0]) && ((mouseY > frameHeight / 2) == command.Value[1]))
                    {
                        command.Key.Execute();
                    }
                }*/
            }
            else
            {
                previousLeft = false;
            }
                
            //else if (mouseState.RightButton == ButtonState.Pressed)
            
            
        }
    }
}
