using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Sprint2.Commands;

namespace CSE3902_Sprint2.Controller
{
    class KeyboardController : IController
    {
        public Game1 Game { get; set; }
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController(Game1 game)
        {
            Game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                controllerMappings[key].Execute();
            }


        }
    }
}
