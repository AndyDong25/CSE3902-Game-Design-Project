using CSE3902_Sprint2;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;

namespace sprint2.Sprites.Decorations
{
    class Tree1 : ISprite
    {

        public Texture2D texture { get; set; }
        public Tree1()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getTree1Sprite();
            Rectangle sourceRectangle = SpriteConstants.TREE1;
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }
    
}
}
