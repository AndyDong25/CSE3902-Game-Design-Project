using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Commands;

namespace CSE3902_Project.Commands
{
    class SwitchDecorationCommand : ICommand
    {
        private Game1 game;
        public SwitchDecorationCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.map.currObstacleIndex++;
        }
    }
}
