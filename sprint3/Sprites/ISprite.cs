using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CSE3902_Sprint2.Sprites
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

        public Rectangle collider2D { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 destination);
    }
}
