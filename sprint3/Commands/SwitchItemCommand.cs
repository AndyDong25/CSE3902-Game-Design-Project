namespace CSE3902_CSE3902_Project.Commands
{
    class SwitchItemCommand : ICommand
    {
        private Game1 game;
        public SwitchItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //game.currentMap.currItemIndex++;
        }
    }
}
