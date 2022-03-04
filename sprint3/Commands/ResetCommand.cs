namespace CSE3902_CSE3902_Project.Commands
{
    class ResetCommand : ICommand
    {
        Game1 game;

        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Reset();
        }
    }
}
