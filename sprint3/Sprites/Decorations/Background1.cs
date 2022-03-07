using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Objects.Decorations;

namespace CSE3902_Project.Sprites.Decorations
{
    class Background1 : ISprite
    {
        public Texture2D texture { get; set; }
        public Rectangle collider2D { get; set; }
        public Background1()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getBackground2Sprite();
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 800, 480);

            //spriteBatch.Draw(texture, destinationRectangle, Color.White);
            spriteBatch.Draw(texture, destinationRectangle, Color.White);
        }

        public void Update()
        {
        }
    }
}
