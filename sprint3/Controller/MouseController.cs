using CSE3902_CSE3902_Project.Commands;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CSE3902_CSE3902_Project.Controller
{
    class MouseController : IController
    {
        private Game1 game;
        private Boolean previousLeft;
        public MouseController(Game1 game)
        {
            this.game = game;
            previousLeft = true;
        }
        
        public void Update()
        {
            
           
            MouseState mouseState = Mouse.GetState();
          
            Dictionary<ICommand, bool[]> commandDirct = new Dictionary<ICommand, bool[]>();
            ICommand changeMap = new ChangeMapCommand(game);
            

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                if (!game.changedMap)
                {
                    changeMap.Execute();
                    previousLeft = true;
                }


                
            }
            else
            {
                game.changedMap = false;
            }          
             
        }
    }
}
