namespace CSE3902_CSE3902_Project.Commands
{
    class LoadGameCommand3 : ICommand
    {
        private Game1 game;
        public LoadGameCommand3(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.saver3.Load();
            game.p1Wins = game.saver3.Data.p1Wins;
            game.p2Wins = game.saver3.Data.p2Wins;
            game.currentMap.player1.inventory["bomb"] = game.saver3.Data.p1Bomb;
            game.currentMap.player2.inventory["bomb"] = game.saver3.Data.p2Bomb;
            game.currentMap.player1.inventory["potion"] = game.saver3.Data.p1Potion;
            game.currentMap.player2.inventory["potion"] = game.saver3.Data.p2Potion;
            game.currentMap.player1.inventory["shoe"] = game.saver3.Data.p1Shoe;
            game.currentMap.player2.inventory["shoe"] = game.saver3.Data.p2Shoe;
        }
    }
}
