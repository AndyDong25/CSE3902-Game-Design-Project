using CSE3902_Project.Objects.NPC.Snake;

namespace CSE3902_Project.Collisions
{
    class SnakeExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Snake s = (Snake)o;
            s.currState = new SnakeDeathState(s);
            s.isDead = true;
        }
    }
}
