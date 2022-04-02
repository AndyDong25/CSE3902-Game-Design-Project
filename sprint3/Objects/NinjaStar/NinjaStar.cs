using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using System;
using CSE3902_CSE3902_Project.Sprites;

namespace CSE3902_Project.Objects.NinjaStar
{
    public class NinjaStar: ICollideable, ISprite
    {
        private Player player;
        public Boolean hit = false;
        private Vector2 position;
        private float rotation;
        private float rotationVelocity = 20.0f;
        public float speed = 10.0f;
        public float direction;
        private Rectangle sourceRec = SpriteConstants.NINJA_STAR;
        public Rectangle collider2D;
        public ICollisionHandler collisionHandler;
        public Boolean exist = true;
        public NinjaStar(Player p)
        {
            player = p;
            position = new Vector2(player.xPos, player.yPos);
            rotation = 0f;
            this.direction = player.direction;
            /**
             * TODO: find the actual hitbox
             **/
            collider2D = new Rectangle((int)position.X+3, (int)position.Y+3 , 30, 30);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D ninjaStarSprite = ItemTextureStorage.Instance.getNinjaStarSprite();
            Rectangle destination = new Rectangle((int)position.X + 30, (int)position.Y + 25, 45, 45);
            spriteBatch.Draw(ninjaStarSprite, destination, sourceRec, Color.White, rotation, new Vector2(ninjaStarSprite.Width / 2, ninjaStarSprite.Height / 2), SpriteEffects.None, 0f);
            UpdateCollider();
        }
        public void Update()
        {
            switch (direction)
            {
                case 0:
                    position.Y -= speed;
                    break;
                case 1:
                    position.X += speed;
                    break;
                case 2:
                    position.Y += speed;
                    break;
                case 3:
                    position.X -= speed;
                    break;
                default:
                    Console.WriteLine("Player has no direction...?");
                    break;
            }
            rotation += MathHelper.ToRadians(rotationVelocity);
            UpdateCollider();
        }

        public void UpdateCollider()
        {     
                collider2D.X = (int)position.X + 3;
                collider2D.Y = (int)position.Y + 3;     
        }
        /*   Jiachen zhang used for de_bug, I will delete this after Im sure it is useless
        public void SetHitTo(Boolean flag)
        {
            this.hit = flag;
        }

        public void HitBoxChecking(Rectangle r)
        {
            if (this.collider2D.Intersects(r))
            {
                this.hit = true;
                this.exist = true;
            }
            else
            {
                this.hit = false;
            }
        }
        */
        public Rectangle GetCollider2D()
        {
            return collider2D;
        }
    }
}
