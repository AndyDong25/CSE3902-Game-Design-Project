namespace CSE3902_CSE3902_Project.Commands
{
    class SaveGameCommand : ICommand
    {
        private Game1 game;
        public SaveGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.saver.Data.p1Wins = game.p1Wins;
            game.saver.Data.p2Wins = game.p2Wins;
            game.saver.Save();
        }
    }
}
