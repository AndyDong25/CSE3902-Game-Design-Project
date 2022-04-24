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
            game.saver.Data.p1Bomb = game.currentMap.player1.bombCount;
            game.saver.Data.p2Bomb = game.currentMap.player2.bombCount;
            game.saver.Data.p1Potion = game.currentMap.player1.potionCount;
            game.saver.Data.p2Potion = game.currentMap.player2.potionCount;
            game.saver.Data.p1Shoe = game.currentMap.player1.inventory["shoe"];
            game.saver.Data.p2Shoe = game.currentMap.player2.inventory["shoe"];
            game.saver.Data.p1Wins = game.p1Wins;
            game.saver.Data.p2Wins = game.p2Wins;
            game.saver.Save();
        }
    }
}
