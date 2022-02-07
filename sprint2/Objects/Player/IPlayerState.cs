using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Objects.Player
{
    public interface IPlayerState
    {
        void Draw(SpriteBatch spriteBatch);
        void setTextureIndex(int index);
        void TakeDamage();
        void Update();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();

    }
}
