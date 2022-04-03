using CSE3902_Project.Map;
using CSE3902_Project.Objects.Torpedo;

namespace CSE3902_Project.Collisions
{
    class PlayerTorpedoCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Torpedo t = (Torpedo)o;
            t.exist = false;
            t.UpdateCollider();
        }
    }
}
