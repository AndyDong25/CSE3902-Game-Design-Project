using CSE3902_Project.Objects.NinjaStar;

namespace CSE3902_Project.Collisions
{
    class NinjaStarBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(object o)
        {
            NinjaStar n = (NinjaStar)o;
            n.exist = false;
        }
    }
}
