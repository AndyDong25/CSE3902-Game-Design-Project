using CSE3902_Project.Audio;


namespace CSE3902_CSE3902_Project.Commands
{
    class GameOverCommand : ICommand
    {
        private Game1 game;
        public GameOverCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            AudioManager.Instance.PlayRoundOver(true);
        }
    }
}
