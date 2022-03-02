using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;

namespace CSE3902_Sprint2
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
