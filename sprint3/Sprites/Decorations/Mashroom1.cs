using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Decorations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint3.Sprites.Decorations
{
    public class Mashroom1 : ISprite, ICollideable
    {
        public Vector2 pos;
        public Texture2D texture { get; set; }
        public Rectangle collider2D { get; set; }

        public Mashroom1(Vector2 pos)
        {
            this.pos = pos;
            /** 
 * TODO: find the actual hitbox
 * */
            collider2D = new Rectangle((int)pos.X, (int)pos.Y, 35, 50);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = DecorationTextureStorage.Instance.getMashroom1Sprite();
            Rectangle sourceRectangle = SpriteConstants.MASHROOM1;
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 70, 70);

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
