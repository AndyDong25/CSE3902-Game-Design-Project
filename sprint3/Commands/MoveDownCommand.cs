using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class MoveDownCommand : ICommand
    {
        private Player myPlayer;
        public MoveDownCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.MoveDown();
        }
    }
}
