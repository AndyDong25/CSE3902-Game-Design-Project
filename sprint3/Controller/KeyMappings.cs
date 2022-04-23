using CSE3902_CSE3902_Project.Commands;
using CSE3902_CSE3902_Project.Objects.Player;
using Microsoft.Xna.Framework.Input;
using CSE3902_Project.Commands;
using CSE3902_Project.Audio;
using System.Collections.Generic;
using sprint3.Commands;

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

            SetDefaults();
        }

        private void SetDefaults()
        {

            //Game Commands
            this.AddCommand(Keys.Q, new QuitCommand(myGame), true);
            this.AddCommand(Keys.R, new ResetCommand(myGame), true);

            //Player Commands
            this.AddCommand(Keys.W, new MoveUpCommand(player1), false);
            this.AddCommand(Keys.S, new MoveDownCommand(player1), false);
            this.AddCommand(Keys.D, new MoveRightCommand(player1), false);
            this.AddCommand(Keys.A, new MoveLeftCommand(player1), false);

            this.AddCommand(Keys.Up, new MoveUpCommand(player2), false);
            this.AddCommand(Keys.Down, new MoveDownCommand(player2), false);
            this.AddCommand(Keys.Right, new MoveRightCommand(player2), false);
            this.AddCommand(Keys.Left, new MoveLeftCommand(player2), false);

            this.AddCommand(Keys.O, new SwitchNPCCommand(myGame), true);
            this.AddCommand(Keys.T, new SwitchDecorationCommand(myGame), true);
            this.AddCommand(Keys.I, new SwitchItemCommand(myGame), true);
            this.AddCommand(Keys.Space, new DropBombCommand(player1), true);
            this.AddCommand(Keys.Enter, new DropBombCommand(player2), true);

            this.AddCommand(Keys.E, new ChangeCharacterCommand(player1, myGame), true);
            //this.AddCommand(Keys.P, new ChangeCharacterCommand(player2, myGame), true);

            this.AddCommand(Keys.G, new PlayerDeathCommand(player1), true);
            this.AddCommand(Keys.L, new PlayerDeathCommand(player2), true);

            // For ninja star
            this.AddCommand(Keys.D1, new UseItemCommand(player1), true);
            this.AddCommand(Keys.D0, new UseItemCommand(player2), true);

            // For torpedo
            this.AddCommand(Keys.D2, new UseTorpedoItemCommand(player1), true);
            this.AddCommand(Keys.D9, new UseTorpedoItemCommand(player2), true);

            //For landmine
            this.AddCommand(Keys.D3, new UseLandmineItemCommand(player1), true);
            this.AddCommand(Keys.D8, new UseLandmineItemCommand(player2), true);

            this.AddCommand(Keys.M, new MuteAudioCommand(AudioManager.Instance), true);
            this.AddCommand(Keys.P, new PauseGameCommand(myGame), true);
            
            //CheateMode 
            this.AddCommand(Keys.F10, new CheateGameCommand(player1), true);
        }

        public void AddCommand(Keys key, ICommand command, bool once)
        {
            mappings.Add(key, command);
            if (once)
            {
                oncePerActionStates.Add(key);
            }
            else
            {
                basicStates.Add(key);
            }
        }

        public void CallCommands(List<Keys> pressedKeys, List<Keys> previousKeys)
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
