using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;

namespace sprint2.Sprites.Decorations
{
    class Background1 : ISprite
    {
        public Texture2D texture { get; set; }
        public Background1()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getBackground1Sprite();
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 800, 480);

            spriteBatch.Draw(texture, destinationRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
