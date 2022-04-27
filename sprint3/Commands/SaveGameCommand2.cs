namespace CSE3902_CSE3902_Project.Commands
{
    class SaveGameCommand2 : ICommand
    {
        private Game1 game;
        public SaveGameCommand2(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.saver2.Data.PRE = "Player1 won: " + game.p1Wins + "\n" +
                "Player2 won: " + game.p2Wins + "\n" +
                "Player1 bombs: " + game.currentMap.player1.bombCount + "\n" +
                "Player2 bombs: " + game.currentMap.player2.bombCount + "\n" +
                "Player1 potions: " + game.currentMap.player1.potionCount + "\n" +
                "Player2 potions: " + game.currentMap.player2.potionCount + "\n" +
                "Player1 shoes: " + game.currentMap.player1.inventory["shoe"] + "\n" +
                "Player2 shoes: " + game.currentMap.player2.inventory["shoe"];
            
            game.saver2.Data.p1Bomb = game.currentMap.player1.bombCount;
            game.saver2.Data.p2Bomb = game.currentMap.player2.bombCount;
            game.saver2.Data.p1Potion = game.currentMap.player1.potionCount;
            game.saver2.Data.p2Potion = game.currentMap.player2.potionCount;
            game.saver2.Data.p1Shoe = game.currentMap.player1.inventory["shoe"];
            game.saver2.Data.p2Shoe = game.currentMap.player2.inventory["shoe"];
            ////game.saver.Data.br = " ";
            ////game.saver.Data.p1WinsString = "Player1 wins: ";
            game.saver2.Data.p1Wins = game.p1Wins;
            game.saver2.Data.p2Wins = game.p2Wins;
            //game.saver.Data.br = " ";
            //game.saver.Data.p = "  ";
            //game.saver.Data.p1 = "  ";
            //game.saver.Data.p2 = "  ";
            //game.saver.Data.p3 = "  ";
            //game.saver.Data.p4 = "  ";
            //game.saver.Data.p5 = "  ";
            //game.saver.Data.p1WinsString = "Player1 won: ";
            //game.saver.Data.p2WinsString = "Player2 won: ";
            //game.saver.Data.p1BombString = "Player1 bombs: ";
            //game.saver.Data.p2BombString = "Player2 bombs: ";
            //game.saver.Data.p1PotionString = "Player1 potions: ";
            //game.saver.Data.p2PotionString = "Player2 potions: ";
            //game.saver.Data.p1ShoeString = "Player1 shoes: ";
            //game.saver.Data.p2ShoeString = "Player2 shoes: ";
            game.saver2.Save();
        }
    }
}
