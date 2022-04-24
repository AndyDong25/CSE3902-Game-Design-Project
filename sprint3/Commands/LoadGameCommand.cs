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
            game.currentMap.player1.inventory["bomb"] = game.saver.Data.p1Bomb;
            game.currentMap.player2.inventory["bomb"] = game.saver.Data.p2Bomb;
            game.currentMap.player1.inventory["potion"] = game.saver.Data.p1Potion;
            game.currentMap.player2.inventory["potion"] = game.saver.Data.p2Potion;
            game.currentMap.player1.inventory["shoe"] = game.saver.Data.p1Shoe;
            game.currentMap.player2.inventory["shoe"] = game.saver.Data.p2Shoe;
        }
    }
}
