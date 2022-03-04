using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;

namespace CSE3902_CSE3902_Project
{
    public interface IItem
    {
        void Activate(Player currentPlayer);

        void Update();
        
        public ISprite GetSprite();

        void Destroy();

       

        //void Draw(SpriteBatch spriteBatch);

    }
}
