using CSE3902_Project.Objects.NPC;

namespace CSE3902_Project.Collisions
{
    class EnemyExplosionCollision
        : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Enemy e = (Enemy)o;
            e.currState = new EnemyDeathState(e);
            e.isDead = true;
        }
    }
}
