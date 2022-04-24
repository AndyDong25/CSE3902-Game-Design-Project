using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_Project.Collisions
{
    class PlayerCoinCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player p = (Player)o;

            p.collect_coins++;
        }
    }
}