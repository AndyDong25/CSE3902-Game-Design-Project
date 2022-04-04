using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class UseLandmineItemCommand : ICommand
    {
        private Player myPlayer;
        public UseLandmineItemCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.UseLandmine();
        }
    }

}
