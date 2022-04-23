using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_Project.Collisions
{
    class PlayerTrapCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player currentPlayer = (Player)o;
            if (currentPlayer.CheateMode == false)
            {
                currentPlayer.currState = new PlayerDeathState(currentPlayer);
                currentPlayer.Die();
            }
        }
        
    }
}
