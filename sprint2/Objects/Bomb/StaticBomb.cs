using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint2.Objects.Bomb
{
    class StaticBomb : ISprite
    {
        private Player player;
        public Texture2D texture { get; set; }
        public int radius;

        public StaticBomb(Texture2D texture, Player player)
        {
            this.texture = texture;
            this.player = player;
            radius = player.potionCount;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            texture = ItemTextureStorage.Instance.getBombObjectSprite();
            Rectangle sourcerectangle = new Rectangle(0, 0, 1340, 1340);
            Rectangle destinationrectangle = new Rectangle((int)destination.X, (int)destination.Y, 50, 50);
            float rotation = .0f;
            spriteBatch.Draw(texture, destinationrectangle, sourcerectangle, Color.White, rotation, new Vector2(100, 50), SpriteEffects.None, 0f);
        }

        public void Update()
        {
        }

        public void Explode(SpriteBatch spriteBatch, List<Rectangle> bombrange)
        {
            Texture2D explosionTexture = ItemTextureStorage.Instance.getExplosionSprite();
            Rectangle sourceRec = SpriteConstants.EXPLOSION;

            radius = player.potionCount;
            foreach (Rectangle rec in bombrange)
            {
                spriteBatch.Draw(explosionTexture, rec, sourceRec, Color.White);
            }
        }

    }
}

