using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class ChangeCharacterCommand : ICommand
    {
        private Player myPlayer;
        private Game1 game;

        public ChangeCharacterCommand(Player player, Game1 game)
        {
            myPlayer = player;
            this.game = game;
        }

        public ChangeCharacterCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.currentMap.GameOver();     

        }
    }
}
