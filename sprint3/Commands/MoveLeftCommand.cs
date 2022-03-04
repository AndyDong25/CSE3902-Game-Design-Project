using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class MoveLeftCommand : ICommand
    {
        private Player myPlayer;
        public MoveLeftCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.MoveLeft();
        }
    }
}
