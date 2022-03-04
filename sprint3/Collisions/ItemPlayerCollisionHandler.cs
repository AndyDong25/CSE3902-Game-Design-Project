using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Player;

namespace CSE3902_Project.Collisions
{
    class ItemPlayerCollisionHandler : ICollisionHandler
    {

        public Player currentPlayer;

        //we can change this in the future if it is unecessary
        public ItemPlayerCollisionHandler(Player p)
        {
            currentPlayer = p;
        }

        public void HandleCollision(object o)
        {
            BasicItem item = (BasicItem)o;
            /* Make sure we are not giving a player an item that has already been used. */ 
            if (!item.activated)
            {
                item.Activate(currentPlayer);
            }
        }
    }
}
