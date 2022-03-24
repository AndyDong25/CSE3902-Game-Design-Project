using CSE3902_Project.Objects.Bomb;

namespace CSE3902_Project.Collisions
{
    class BombExplosionCollisionHandler : ICollisionHandler
    {
        private int direction;
        public BombExplosionCollisionHandler(int direction)
        {
            this.direction = direction;
        }
        public void HandleCollision(object o)
        {
            StaticBomb b = (StaticBomb)o;
            b.timer = 0;
            b.directionChained = direction;
        }
    }
}
