using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_CSE3902_Project.Commands
{
    class ChangeCharacterCommand : ICommand
    {
        private Player myPlayer;
        public ChangeCharacterCommand(Player player)
        {
            myPlayer = player;
        }
        public void Execute()
        {
            myPlayer.ChangeCharacter();           
        }
    }
}
