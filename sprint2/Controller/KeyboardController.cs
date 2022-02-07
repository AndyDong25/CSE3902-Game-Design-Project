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
using CSE3902_Sprint2.Objects.Player;

namespace CSE3902_Sprint2.Controller
{
    class KeyboardController : IController
    {
        private List<Keys> currentState;
        private KeyMapping keyMap;

        public KeyboardController(Game1 game, Player player1, Player player2)
        {
            //currentState = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            keyMap = new KeyMapping(game, player1, player2);
        }

        public void Update()
        {
            currentState = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            keyMap.callCommands(currentState);
        }
    }
}
