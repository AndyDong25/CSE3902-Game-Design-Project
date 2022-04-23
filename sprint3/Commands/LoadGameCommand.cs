namespace CSE3902_CSE3902_Project.Commands
{
    class LoadGameCommand : ICommand
    {
        private Game1 game;
        public LoadGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.saver.Load();
            game.p1Wins = game.saver.Data.p1Wins;
            game.p2Wins = game.saver.Data.p2Wins;
        }
    }
}
