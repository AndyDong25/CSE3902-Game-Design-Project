using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Decorations;
using CSE3902_Project.Map;

namespace CSE3902_CSE3902_Project.Sprites.BlockSprites
{
    public class IndestructableBlockSprite : ISprite, ICollideable 
    {
        public Vector2 pos;
        public Texture2D texture { get; set; }
        ICollisionHandler collisionHandler;
        public Rectangle collider2D { get; set; }
        public Rectangle sourceRec;

        public IndestructableBlockSprite(Vector2 pos, int mapIndex)
        {
            this.pos = pos;
            collider2D = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);
            SelectBlockTexture(mapIndex);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRec, Color.White);
        }

        public void Update()
        {
        }

        public void UpdateCollider()
        {
        }

        public void SelectBlockTexture(int mapIndex)
        {
            switch (mapIndex)
            {
                case 0:
                    texture = DecorationTextureStorage.Instance.getCrateIBlock();
                    sourceRec = SpriteConstants.CRATE_I_BLOCK;
                    break;
                case 1:
                    texture = DecorationTextureStorage.Instance.getIceIBlock();
                    sourceRec = SpriteConstants.ICE_I_BLOCK;
                    break;
                case 2:
                    texture = DecorationTextureStorage.Instance.getMineralBlock();
                    sourceRec = SpriteConstants.MINERAL_BLOCK;
                    break;
                case 3:
                    texture = DecorationTextureStorage.Instance.getWaterBlock();
                    sourceRec = SpriteConstants.WATER_BLOCK;
                    break;
                default:
                    texture = DecorationTextureStorage.Instance.getCrateIBlock();
                    sourceRec = SpriteConstants.CRATE_I_BLOCK;
                    break;
            }
        }
    }
}
