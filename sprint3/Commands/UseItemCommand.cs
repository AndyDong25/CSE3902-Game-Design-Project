using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class UseItemCommand : ICommand
    {
        private Player myPlayer;
        public UseItemCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.UseItem();
        }
    }

}
