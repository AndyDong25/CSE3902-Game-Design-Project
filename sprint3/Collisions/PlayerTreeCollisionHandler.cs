using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_Project.Collisions
{
    class PlayerTreeCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            Player p = (Player)o;

            p.xPos = p.previousXPos;
            p.yPos = p.previousYPos;
            p.UpdateCollider();
        }
    }
}
