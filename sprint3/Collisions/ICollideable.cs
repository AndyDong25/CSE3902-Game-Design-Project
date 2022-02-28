using Microsoft.Xna.Framework;
using sprint2.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
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
    }
}
