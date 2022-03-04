using CSE3902_Project.Objects.NPC.Snake;

namespace CSE3902_Project.Collisions
{
    class SnakeCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Snake s = (Snake)o;
            s.xPos = s.previousXPos;
            s.yPos = s.previousYPos;
            s.UpdateCollider();
        }
    }
}
