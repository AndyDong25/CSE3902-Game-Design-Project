using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class DropBombCommand : ICommand
    {
        private Player myPlayer;
        public DropBombCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.DropBomb();
        }
    }
}
