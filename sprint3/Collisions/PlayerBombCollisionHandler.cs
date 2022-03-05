using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_Project.Objects.Bomb;

namespace CSE3902_Project.Collisions
{
    class PlayerBombCollisionHandler : ICollisionHandler
    {
        StaticBomb bomb;
        public PlayerBombCollisionHandler(StaticBomb b)
        {
            bomb = b;
        }
        public void HandleCollision(object o)
        {
            Player p = (Player)o;
            if (!bomb.passable)
            {
                p.xPos = p.previousXPos;
                p.yPos = p.previousYPos;
                p.UpdateCollider();
            }
        }
    }
}
