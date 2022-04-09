using sprint3.Objects.Decorations;

namespace CSE3902_Project.Collisions
{
    class CoinPlayerCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Coin c = (Coin)o;
            c.Collected();
        }
    }
}
