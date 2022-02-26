using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace sprint2.Objects.Items
{
    class NinjaStar
    {
        private Player player;
        private Game1 game;
        private Vector2 position;
        private float rotation;
        private float rotationVelocity = 20.0f;
        public float speed = 10.0f;
        public float direction;
        private Rectangle sourceRec = SpriteConstants.NINJA_STAR;
        public NinjaStar(Player p, Game1 game)
        {
            player = p;
            this.game = game;
            position = new Vector2(player.xPos, player.yPos);
            rotation = 0f;
            this.direction = player.direction;
        }

        public void DrawSprite(SpriteBatch spriteBatch)
        {
            Texture2D ninjaStarSprite = ItemTextureStorage.Instance.getNinjaStarSprite();
            Rectangle destination = new Rectangle((int)position.X + 30, (int)position.Y + 25, 45, 45);
            spriteBatch.Draw(ninjaStarSprite, destination, sourceRec, Color.White, rotation, new Vector2(ninjaStarSprite.Width / 2, ninjaStarSprite.Height / 2), SpriteEffects.None, 0f);
            //spriteBatch.Draw(ninjaStarSprite, new Vector2(destination.X, destination.Y), sourceRec, Color.White, rotation, new Vector2(destination.X / 2, destination.Y / 2), 1, SpriteEffects.None, 0f);
            //spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0f);

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
        }
    }
}
