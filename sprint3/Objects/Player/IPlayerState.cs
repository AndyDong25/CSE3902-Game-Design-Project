using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_CSE3902_Project.Objects.Player
{
    public interface IPlayerState
    {
        void Draw(SpriteBatch spriteBatch);      
        void TakeDamage();
        void Update();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
