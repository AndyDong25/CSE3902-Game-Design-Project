using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class ChangeCharacterCommand : ICommand
    {
        private Player myPlayer;
        private Game1 game;

        public ChangeCharacterCommand(Player player)
        {
            myPlayer = player;
        }

        public ChangeCharacterCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            myPlayer.ChangeCharacter();     

        }
    }
}
