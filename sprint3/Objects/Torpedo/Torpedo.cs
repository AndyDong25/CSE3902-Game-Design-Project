using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using System;
using CSE3902_CSE3902_Project.Sprites;

namespace CSE3902_Project.Objects.Torpedo
{
    public class Torpedo : ICollideable, ISprite
    {
        private Player player;
        public Boolean hit = false;
        private Vector2 position;
        private float rotation;
        public float speed = 10.0f;
        public float direction;
        private Rectangle sourceRec = SpriteConstants.TORPEDO;
        public Rectangle collider2D;
        public ICollisionHandler collisionHandler;
        public Boolean exist = true;
        public Torpedo(Player p)
        {
            player = p;
            position = new Vector2(player.xPos, player.yPos);
            rotation = 0f;
            this.direction = player.direction;
            /**
             * TODO: find the actual hitbox
             **/
            collider2D = new Rectangle((int)position.X + 3, (int)position.Y + 3, 30, 30);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D torpedoSprite = ItemTextureStorage.Instance.getTorpedoItemSprite();
            Rectangle destination = new Rectangle((int)position.X + 30, (int)position.Y + 25, 45, 45);
            spriteBatch.Draw(torpedoSprite, destination, sourceRec, Color.White, rotation, new Vector2(torpedoSprite.Width / 2, torpedoSprite.Height / 2), SpriteEffects.None, 0f);
            UpdateCollider();
        }
        public void Update()
        {
            switch (direction)
            {
                case 0:
                    position.Y -= speed;
                    rotation = 1.575f;
                    break;
                case 1:
                    position.X += speed;
                    rotation = 3.15f;
                    break;
                case 2:
                    position.Y += speed;
                    rotation = 4.725f;
                    break;
                case 3:
                    position.X -= speed;
                    break;
                default:
                    Console.WriteLine("Player has no direction...?");
                    break;
            }
            UpdateCollider();
        }

        public void UpdateCollider()
        {
            collider2D.X = (int)position.X + 3;
            collider2D.Y = (int)position.Y + 3;
        }
    }
}
