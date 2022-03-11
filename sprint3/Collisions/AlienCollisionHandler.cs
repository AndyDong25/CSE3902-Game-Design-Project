using CSE3902_Project.Objects.NPC.Alien;

namespace CSE3902_Project.Collisions
{
    class AlienCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Alien a = (Alien)o;
            a.xPos = a.previousXPos;
            a.yPos = a.previousYPos;
            a.UpdateCollider();
        }
    }
}
