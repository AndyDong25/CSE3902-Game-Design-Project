using CSE3902_CSE3902_Project.Commands;
using CSE3902_CSE3902_Project.Objects.Player;
using Microsoft.Xna.Framework.Input;
using CSE3902_Project.Commands;
using System.Collections.Generic;

namespace CSE3902_CSE3902_Project.Controller
{
    class KeyMapping
    {
        private Game1 myGame;
        private Player player1;
        private Player player2;
        private Dictionary<Keys, ICommand> mappings;
        private List<Keys> basicStates;
        private List<Keys> oncePerActionStates;

        public KeyMapping(Game1 game, Player player1, Player player2)
        {
            myGame = game;
            this.player1 = player1;
            this.player2 = player2;

            mappings = new Dictionary<Keys, ICommand>();
            basicStates = new List<Keys>();
            oncePerActionStates = new List<Keys>();

            setDefaults();
        }

        private void setDefaults()
        {

            //Game Commands
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

            this.addCommand(Keys.O, new SwitchNPCCommand(myGame));
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

            // For torpedo
            this.addCommand(Keys.D2, new UseTorpedoItemCommand(player1));
            this.addCommand(Keys.D9, new UseTorpedoItemCommand(player2));

            //For landmine
            this.addCommand(Keys.D3, new UseLandmineItemCommand(player1));
            this.addCommand(Keys.D8, new UseLandmineItemCommand(player2));
        }

        public void addCommand(Keys key, ICommand command)
        {
            mappings.Add(key, command);
            //acceptedStates.Add(key);
            if (key == Keys.E || key == Keys.P || key == Keys.Space || key == Keys.Enter || key == Keys.I || key == Keys.T || key == Keys.O ||key == Keys.D0 || key == Keys.D1 || key == Keys.D2 || key == Keys.D9
                || key == Keys.D3 || key == Keys.D8)
            {
                oncePerActionStates.Add(key);
            }
            else
            {
                basicStates.Add(key);
            }
        }

        public void callCommands(List<Keys> pressedKeys, List<Keys> previousKeys)
        {
            foreach (Keys k in pressedKeys)
            {
                if (basicStates.Contains(k))
                {
                    mappings[k].Execute();
                }
                else if (oncePerActionStates.Contains(k) && !previousKeys.Contains(k))
                {
                    mappings[k].Execute();
                }
            }
        }
    }
}
