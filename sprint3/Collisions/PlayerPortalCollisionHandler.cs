using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_Project.Collisions;
using sprint3.Objects.Decorations;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Collisions
{
    class PlayerPortalCollisionHandler : ICollisionHandler
    {
        private Portal p;
        public PlayerPortalCollisionHandler(Portal p)
        {
            this.p = p;
        }
        public void HandleCollision(object o)
        {
            Player pl = (Player)o;
            if (!p.cooldown)
            {
                pl.xPos = p.otherPortal.position.X;
                pl.yPos = p.otherPortal.position.Y;
                p.cooldown = true;
                p.otherPortal.cooldown = true;
            }
        }
    }
}
