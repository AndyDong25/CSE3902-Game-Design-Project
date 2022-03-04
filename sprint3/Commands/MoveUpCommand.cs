using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class MoveUpCommand : ICommand
    {
        private Player myPlayer;
        public MoveUpCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.MoveUp();
        }
    }
}
