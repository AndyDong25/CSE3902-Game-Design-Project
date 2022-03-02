using CSE3902_Sprint2;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;
using sprint3.Collisions;

namespace sprint2.Sprites.Decorations
{
    public class Tree1 : ISprite, ICollideable
    {

        public Vector2 pos;
        public Texture2D texture { get; set; }
        public Rectangle collider2D { get; set; }

        public Tree1(Vector2 pos)
        {
            this.pos = pos;
            /** 
 * TODO: find the actual hitbox
 * */
            collider2D = new Rectangle((int)pos.X, (int)pos.Y, 35, 50);

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getTree1Sprite();
            Rectangle sourceRectangle = SpriteConstants.TREE1;
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
        }

        public void UpdateCollider()
        {
        }
    }
}
