using CSE3902_Sprint2.Objects.Player;

namespace CSE3902_Sprint2.Commands
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
