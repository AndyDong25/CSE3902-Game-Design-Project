using Microsoft.Xna.Framework;

namespace CSE3902_Project.Collisions
{
    public interface ICollideable
    {
        public Rectangle collider2D
        {
            get
            {
                return collider2D;
            }
        }
        public ICollisionHandler collisionHandler
        {
            get
            {
                return collisionHandler;
            }
            set
            {
                collisionHandler = value;
            }
        }

        void UpdateCollider();

        Rectangle GetCollider2D();
    }
}
