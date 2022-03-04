using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_Project.Collisions
{
    class PlayerExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player currentPlayer = (Player)o;
            currentPlayer.currState = new PlayerDeathState(currentPlayer);
            currentPlayer.isDead = true;
        }
    }
}
