using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_Project.Objects.NPC;

namespace CSE3902_Project.Collisions
{
    class PlayerEnemyCollisionHandler : ICollisionHandler
    {
        IEnemyState e;
        public PlayerEnemyCollisionHandler(IEnemyState e)
        {
            this.e = e;
        }
        public void HandleCollision(object o)
        {
            Player p = (Player)o;
            if (!e.IsDead() && p.CheateMode == false)
            {
                p.currState = new PlayerDeathState(p);
            }
        }
    }
}
