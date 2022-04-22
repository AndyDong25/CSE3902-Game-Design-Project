namespace CSE3902_CSE3902_Project.Commands
{
    class ChangeMapCommand: ICommand
    {
        private Game1 game;
        public ChangeMapCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
/*            if (!game.changedMap)
            {
                game.map_index = ++game.map_index % 5;
                game.Reset();
                game.changedMap = !game.changedMap;
            }
            else
            {
                game.changedMap = !game.changedMap;
            }*/
        }
    }
}
