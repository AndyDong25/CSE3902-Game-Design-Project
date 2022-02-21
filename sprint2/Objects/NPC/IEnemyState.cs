using Microsoft.Xna.Framework.Graphics;

namespace sprint2.Objects.NPC
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
    }
}
