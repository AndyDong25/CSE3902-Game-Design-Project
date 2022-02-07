using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Sprint2.Commands;

namespace CSE3902_Sprint2.Controller
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
          
            Dictionary<ICommand, bool[]> commandDirct = new Dictionary<ICommand, bool[]>();
            ICommand exitOption = new CommandExit(Game);
            commandDirct.Add(new CommandStaticSprite(Game), new bool[] { false, false });
            commandDirct.Add(new CommandAnimatedSprite(Game), new bool[] { true, false });
            commandDirct.Add(new CommandStaticMovingSprite(Game), new bool[] { false, true });
            commandDirct.Add(new CommandAnimatedMovingSprite(Game), new bool[] { true, true });
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (KeyValuePair<ICommand, bool[]> command in commandDirct)
                {
                    if (((mouseX > frameWidth / 2) == command.Value[0]) && ((mouseY > frameHeight / 2) == command.Value[1]))
                    {
                        command.Key.Execute();
                    }
                }
            }
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                exitOption.Execute();
            }
        }
    }
}
