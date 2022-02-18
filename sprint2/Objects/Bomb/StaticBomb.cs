using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Objects.Bomb
{
    class StaticBomb : ISprite
    {
        public Texture2D Texture { get; set; }
        private Player player;

        public int radius;
        public StaticBomb(Texture2D texture, Player player)
        {
            this.Texture = texture;
            this.player = player;
            radius = player.potionCount;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            //destination.X = player.xPos;
            //destination.Y = player.yPos;
            Rectangle sourcerectangle = new Rectangle(0, 0, 1340, 1340);
            Rectangle destinationrectangle = new Rectangle((int)destination.X, (int)destination.Y, 50, 50);

            //float scale = .5f; //50% smaller

            Texture = ItemTextureStorage.Instance.getBombObjectSprite();
            float rotation = .0f;
            spriteBatch.Draw(Texture, destinationrectangle, sourcerectangle, Color.White, rotation, new Vector2(100, 50), SpriteEffects.None, 0f);
            //spriteBatch.Draw(Texture, destinationrectangle, sourcerectangle, Color.White);
        }

        public void Update()
        {
        }

        public void Explode(SpriteBatch spriteBatch, Vector2 destination)
        {
            Texture2D explosionTexture = ItemTextureStorage.Instance.getExplosionSprite();
            Rectangle sourceRec = SpriteConstants.EXPLOSION;
            int x = (int)destination.X;
            int y = (int)destination.Y;
            radius = player.potionCount;
            // explosion origin
            spriteBatch.Draw(explosionTexture, new Rectangle(x, y, 50, 50), sourceRec, Color.White);
            // temporary hard coded explosion radius of 3
            for (int i = 1; i < radius; i++)
            {
                spriteBatch.Draw(explosionTexture, new Rectangle(50 * i + x, y, 50, 50), sourceRec, Color.White);
                spriteBatch.Draw(explosionTexture, new Rectangle(x, 50 * i + y, 50, 50), sourceRec, Color.White);
                spriteBatch.Draw(explosionTexture, new Rectangle(x - (50 * i), y, 50, 50), sourceRec, Color.White);
                spriteBatch.Draw(explosionTexture, new Rectangle(x, y - (50 * i), 50, 50), sourceRec, Color.White);
            }

        }

    }
}
