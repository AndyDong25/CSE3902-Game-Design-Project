using CSE3902_Project.Objects.NPC;

namespace CSE3902_Project.Collisions
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Enemy e = (Enemy)o;
            e.xPos = e.previousXPos;
            e.yPos = e.previousYPos;
            e.UpdateCollider();
        }
    }
}
