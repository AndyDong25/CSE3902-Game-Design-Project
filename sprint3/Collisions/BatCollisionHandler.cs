using CSE3902_Project.Objects.NPC.Bat;

namespace CSE3902_Project.Collisions
{
    class BatCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Bat b = (Bat)o;
            b.xPos = b.previousXPos;
            b.yPos = b.previousYPos;
            b.UpdateCollider();
        }
    }
}
