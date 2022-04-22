using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Controller
{
    class KeyboardController : IController
    {
        private List<Keys> currentState;
        private List<Keys> previousState;
        private KeyMapping keyMap;

        public KeyboardController(Game1 game, Player player1, Player player2)
        {
            previousState = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            keyMap = new KeyMapping(game, player1, player2);
        }

        public void Update()
        {
            currentState = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            keyMap.CallCommands(currentState, previousState);
            previousState = currentState;
        }
    }
}
