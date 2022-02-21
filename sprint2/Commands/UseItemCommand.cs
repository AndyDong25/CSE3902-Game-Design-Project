using CSE3902_Sprint2.Objects.Player;

namespace CSE3902_Sprint2.Commands
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
