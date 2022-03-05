using CSE3902_CSE3902_Project;

namespace CSE3902_Project.Collisions
{
    class ItemExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            //Debug.WriteLine("Item Explosion Collided");
            BasicItem item = (BasicItem)o;
            if (!item.invincible)
            {
                item.Destroy();
            }
        }
    }
}
