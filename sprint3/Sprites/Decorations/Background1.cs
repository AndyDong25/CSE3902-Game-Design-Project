using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Objects.Decorations;

namespace CSE3902_Project.Sprites.Decorations
{
    class Background1 : ISprite
    {
        public Texture2D texture { get; set; }
        public Rectangle collider2D { get; set; }
        public Vector2 pos;
        public Background1(Vector2 pos, int mapIndex)
        {
            this.pos = pos;
            SelectMapBackground(mapIndex);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 800, 480);

            spriteBatch.Draw(texture, destinationRectangle, Color.White);
        }

        public void Update()
        {
        }

        public void SelectMapBackground(int mapIndex)
        {
            switch (mapIndex)
            {
                case 0:
                    texture = DecorationTextureStorage.Instance.getGrassBackgroundSprite();
                    break;
                case 1:
                    texture = DecorationTextureStorage.Instance.getIceBackGroundSprite();
                    break;
                case 2:
                    texture = DecorationTextureStorage.Instance.getDirtBackgroundSprite();
                    break;
                case 3:
                    texture = DecorationTextureStorage.Instance.getWaterBackgroundSprite();
                    break;
                default:
                    texture = DecorationTextureStorage.Instance.getGrassBackgroundSprite();
                    break;
            }
        }
    }
}
