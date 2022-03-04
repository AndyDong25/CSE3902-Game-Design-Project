using CSE3902_Project.Objects.Bomb;

namespace CSE3902_Project.Collisions
{
    class BombExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            StaticBomb b = (StaticBomb)o;
            b.timer = 0;
        }
    }
}
