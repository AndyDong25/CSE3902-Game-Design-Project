using CSE3902_Project.Objects.NPC.Bat;

namespace CSE3902_Project.Collisions
{
    class BatExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Bat b = (Bat)o;
            b.currState = new BatDeathState(b);
            b.isDead = true;
        }
    }
}
