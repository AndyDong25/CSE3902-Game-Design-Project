using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CSE3902_CSE3902_Project.Sprites
{
    public interface ISprite
    {

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

        public Rectangle collider2D {
            get
            {
                return collider2D;
            }
            set
            {
                collider2D = value;
            }
        }

        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 destination);
    }
}
