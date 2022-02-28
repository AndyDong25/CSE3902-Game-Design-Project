﻿using CSE3902_Sprint2;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Decorations;
using sprint3.Collisions;

namespace sprint2.Sprites.Decorations
{
    public class Tree2 : ISprite, ICollideable
    {

        public Vector2 pos;
        public Texture2D texture { get; set; }
        public Rectangle collider2D;

        public Tree2(Vector2 pos)
        {
            this.pos = pos;
            /** 
 * TODO: find the actual hitbox
 * */
            collider2D = new Rectangle(0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = DecorationTextureStorage.Instance.getTree2Sprite();
            Rectangle sourceRectangle = SpriteConstants.TREE2;
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

