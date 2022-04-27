namespace CSE3902_CSE3902_Project.Commands
{
    class LoadGameCommand2 : ICommand
    {
        private Game1 game;
        public LoadGameCommand2(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.saver2.Load();
            game.p1Wins = game.saver2.Data.p1Wins;
            game.p2Wins = game.saver2.Data.p2Wins;
            game.currentMap.player1.inventory["bomb"] = game.saver2.Data.p1Bomb;
            game.currentMap.player2.inventory["bomb"] = game.saver2.Data.p2Bomb;
            game.currentMap.player1.inventory["potion"] = game.saver2.Data.p1Potion;
            game.currentMap.player2.inventory["potion"] = game.saver2.Data.p2Potion;
            game.currentMap.player1.inventory["shoe"] = game.saver2.Data.p1Shoe;
            game.currentMap.player2.inventory["shoe"] = game.saver2.Data.p2Shoe;
        }
    }
}
