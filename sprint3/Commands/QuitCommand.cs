namespace CSE3902_CSE3902_Project.Commands
{
    class QuitCommand : ICommand
    {
        private Game1 game;
        public QuitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
