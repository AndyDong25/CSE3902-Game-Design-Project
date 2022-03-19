using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Decorations;
using CSE3902_Project.Map;

namespace CSE3902_CSE3902_Project.Sprites.BlockSprites
{
    public class DestructableBlockSprite : ISprite, ICollideable
    {
        private Game1 game;
        public Vector2 pos;

        public ICollisionHandler collisionHandler;
        //public Rectangle collider2D;
        public Rectangle collider2D { get; set; }
        public Rectangle sourceRec;
        public Texture2D texture { get; set; }

        public DestructableBlockSprite(Game1 game, int mapIndex, Vector2 pos)
        {
            this.game = game;
            this.pos = pos;
            collider2D = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);
            SelectBlockTexture(mapIndex);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);

            spriteBatch.Draw(texture, destinationRectangle, sourceRec, Color.White);
        }

        public void Remove()
        {
/*            game.map.currentObstacleList.Remove(this);
            game.map.allObjects.Remove(this);*/
            game.currentMap.finishedObstacles.Add(this);
            game.currentMap.AddItem(pos);
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
                    texture = DecorationTextureStorage.Instance.getCrateDBlock();
                    sourceRec = SpriteConstants.CRATE_D_BLOCK;
                    break;
                case 1:
                    texture = DecorationTextureStorage.Instance.getIceDBlock();
                    sourceRec = SpriteConstants.ICE_D_BLOCK;
                    break;
                case 2:
                    texture = DecorationTextureStorage.Instance.getChestBlock();
                    sourceRec = SpriteConstants.CHEST_BLOCK;
                    break;
                case 3:
                    texture = DecorationTextureStorage.Instance.getKelpBlock();
                    sourceRec = SpriteConstants.KELP_BLOCK;
                    break;
                default:
                    texture = DecorationTextureStorage.Instance.getCrateDBlock();
                    sourceRec = SpriteConstants.CRATE_D_BLOCK;
                    break;
            }
        }
    }
}
