using CSE3902_Project.Map;
using CSE3902_Project.Objects.Torpedo;

namespace CSE3902_Project.Collisions
{
    class PlayerLandmineCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Landmine l = (Landmine)o;
            l.exist = false;
            l.UpdateCollider();
        }
    }
}

