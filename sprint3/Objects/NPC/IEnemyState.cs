using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Project.Objects.NPC
{
    public interface IEnemyState
    {
        void Draw(SpriteBatch spriteBatch);
        void TakeDamage();
        void Update();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void UpdatePreviousPosition();
        bool IsDead();
    }
}
