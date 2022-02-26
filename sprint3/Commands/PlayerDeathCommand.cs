using CSE3902_Sprint2.Commands;
using CSE3902_Sprint2.Objects.Player;

namespace sprint2.Commands
{
    class PlayerDeathCommand : ICommand
    {
        private Player myPlayer;
        public PlayerDeathCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.currState = new PlayerDeathState(myPlayer);
        }
    }
}
