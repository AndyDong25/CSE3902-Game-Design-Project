using CSE3902_CSE3902_Project.Sprites.BlockSprites;

namespace CSE3902_Project.Collisions
{
    class DBlockExplosionCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            DestructableBlockSprite b = (DestructableBlockSprite)o;
            b.Remove();
        }
    }
}
