using CSE3902_Sprint2;
using CSE3902_Sprint2.Commands;

namespace sprint2.Commands
{
    class SwitchNPCCommand : ICommand
    {
        private Game1 game;
        public SwitchNPCCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.map.currEnemyIndex++;
        }
    }
}
