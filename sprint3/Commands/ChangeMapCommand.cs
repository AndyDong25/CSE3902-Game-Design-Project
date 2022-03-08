
using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Commands;
namespace CSE3902_Project.Commands
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
            game.map.map_index++;
        }
    }
}
