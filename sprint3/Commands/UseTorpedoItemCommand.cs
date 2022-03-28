using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class UseTorpedoItemCommand : ICommand
    {
        private Player myPlayer;
        public UseTorpedoItemCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.UseTorpedo();
        }
    }

}
