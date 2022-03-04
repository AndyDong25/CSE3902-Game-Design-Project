using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class MoveRightCommand : ICommand
    {
        private Player myPlayer;
        public MoveRightCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.MoveRight();
        }
    }
}
