using Microsoft.Xna.Framework;
using System;

namespace CSE3902_Project
{
    public interface IEnemy
    {
        bool CanUpdate { get; }
        bool Alive { get; set; }
        bool Moving { get; set; }
        Vector2 Velocity { get; set; }
        void Terminate(String direction);
        void ChangeDirection();
    }

}
