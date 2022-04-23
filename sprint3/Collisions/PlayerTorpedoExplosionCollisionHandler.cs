using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_Project.Objects.Torpedo;

namespace CSE3902_Project.Collisions
{
    class PlayerTorpedoExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player currentPlayer = (Player)o;
            if (currentPlayer.CheateMode == false)
            {
                currentPlayer.currState = new PlayerDeathState(currentPlayer);
                currentPlayer.Die();
            }
            currentPlayer.UpdateCollider();
        }
    }
}
