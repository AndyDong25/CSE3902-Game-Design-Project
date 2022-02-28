using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CSE3902_Sprint2.Sprites
{
    public interface ISprite
    {
        public Rectangle collider2D
        {
            get
            {
                return collider2D;
            }
        }
        public Texture2D texture {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 destination);
    }
}
