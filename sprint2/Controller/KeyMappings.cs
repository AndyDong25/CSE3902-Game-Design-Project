using CSE3902_Sprint2.Commands;
using CSE3902_Sprint2.Objects.Player;
using Microsoft.Xna.Framework.Input;
using sprint2.Commands;
using sprint2.Objects.NPC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSE3902_Sprint2.Controller
{
    class KeyMapping
    {
        private Game1 myGame;
        private Player player1;
        private Player player2;
        private Dictionary<Keys, ICommand> mappings;
        private List<Keys> acceptedStates;
        private List<Keys> oncePerActionStates;

        public KeyMapping(Game1 game, Player player1, Player player2)
        {
            myGame = game;
            this.player1 = player1;
            this.player2 = player2;

            mappings = new Dictionary<Keys, ICommand>();
            acceptedStates = new List<Keys>();
            oncePerActionStates = new List<Keys>();

            setDefaults();
        }

        private void setDefaults()
        {

            //Game Commands
            //this.addCommand(Keys.D0, new QuitCommand(myGame));
            this.addCommand(Keys.Q, new QuitCommand(myGame));
            this.addCommand(Keys.R, new ResetCommand(myGame));

            //Player Commands
            this.addCommand(Keys.W, new MoveUpCommand(player1));
            this.addCommand(Keys.S, new MoveDownCommand(player1));
            this.addCommand(Keys.D, new MoveRightCommand(player1));
            this.addCommand(Keys.A, new MoveLeftCommand(player1));

            this.addCommand(Keys.Up, new MoveUpCommand(player2));
            this.addCommand(Keys.Down, new MoveDownCommand(player2));
            this.addCommand(Keys.Right, new MoveRightCommand(player2));
            this.addCommand(Keys.Left, new MoveLeftCommand(player2));

            this.addCommand(Keys.T, new SwitchDecorationCommand(myGame));
            this.addCommand(Keys.I, new SwitchItemCommand(myGame));
            this.addCommand(Keys.Space, new DropBombCommand(player1));
            this.addCommand(Keys.Enter, new DropBombCommand(player2));

            this.addCommand(Keys.E, new ChangeCharacterCommand(player1));
            this.addCommand(Keys.P, new ChangeCharacterCommand(player2));

            this.addCommand(Keys.G, new PlayerDeathCommand(player1));
            this.addCommand(Keys.L, new PlayerDeathCommand(player2));

            this.addCommand(Keys.D1, new UseItemCommand(player1));
            this.addCommand(Keys.D0, new UseItemCommand(player2));
/*            this.addCommand(Keys.NumPad1, new UseItemCommand(player1));
            this.addCommand(Keys.NumPad0, new UseItemCommand(player2));*/

            // other commands when implemented

        }

        public void addCommand(Keys key, ICommand command)
        {
            mappings.Add(key, command);
            acceptedStates.Add(key);
            if (key == Keys.E || key == Keys.P || key == Keys.Space || key == Keys.Enter || key == Keys.I || key == Keys.T)
            {
                oncePerActionStates.Add(key);
            }
        }

        public void callCommands(List<Keys> pressedKeys, List<Keys> previousKeys)
        {
            foreach (Keys k in pressedKeys)
            {
                if (acceptedStates.Contains(k))
                {
                    if (oncePerActionStates.Contains(k))
                    {
                        if (!previousKeys.Contains(k)) {
                            mappings[k].Execute();
                        }
                    }
                    else {
                        mappings[k].Execute();
                    }
                }
            }
        }
    }
}
