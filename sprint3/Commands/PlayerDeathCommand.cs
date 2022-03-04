using CSE3902_CSE3902_Project.Commands;
using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_Project.Commands
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
