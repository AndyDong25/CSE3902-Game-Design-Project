using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Commands;

namespace CSE3902_Project.Commands
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
            //game.currentMap.currEnemyIndex++;
        }
    }
}
