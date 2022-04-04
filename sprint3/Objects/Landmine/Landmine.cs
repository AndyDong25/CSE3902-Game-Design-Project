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
    public class Landmine : ICollideable, ISprite
    {
        public Player player;
        public Boolean hit = false;
        public Vector2 position;
        private float rotation;
        public float speed = 10.0f;
        public float direction;
        private Rectangle sourceRec = SpriteConstants.LANDMINE;
        public Rectangle collider2D;
        public ICollisionHandler collisionHandler;
        public Boolean exist = true;
        public Landmine(Player p)
        {
            player = p;
            position = new Vector2(player.xPos, player.yPos);
            rotation = 0f;
            this.direction = player.direction;
            /**
             * TODO: find the actual hitbox
             **/
            collider2D = new Rectangle((int)position.X + 20, (int)position.Y + 20, 20, 20);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(exist == true) 
            {
                Texture2D landmineSprite = ItemTextureStorage.Instance.getLandmineItemSprite();
                Rectangle destination = new Rectangle((int)position.X + 30, (int)position.Y + 25, 40, 40);
                spriteBatch.Draw(landmineSprite, destination, sourceRec, Color.White, rotation, new Vector2(landmineSprite.Width / 2, landmineSprite.Height / 2), SpriteEffects.None, 0f);
                //spriteBatch.Draw(landmineSprite, destination, sourceRec, Color.White);
                UpdateCollider();
            }
            
        }
        public void Update()
        {
            //switch (direction)
            //{
            //    case 0:
            //        position.Y -= speed;
            //        rotation = 1.575f;
            //        break;
            //    case 1:
            //        position.X += speed;
            //        rotation = 3.15f;
            //        break;
            //    case 2:
            //        position.Y += speed;
            //        rotation = 4.725f;
            //        break;
            //    case 3:
            //        position.X -= speed;
            //        break;
            //    default:
            //        Console.WriteLine("Player has no direction...?");
            //        break;
            //}
            UpdateCollider();
        }

        public void UpdateCollider()
        {
            //collider2D.X = (int)position.X + 3;
            //collider2D.Y = (int)position.Y + 3;
        }
        public Rectangle GetCollider2D()
        {
            return collider2D;
        }
    }
}

