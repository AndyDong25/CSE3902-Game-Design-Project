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
        public Vector2 position;
        private float rotation;
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
                UpdateCollider();
            }
        }
        public void Update()
        {
            UpdateCollider();
        }

        public void UpdateCollider()
        {
            
        }
        public Rectangle GetCollider2D()
        {
            return collider2D;
        }
    }
}

