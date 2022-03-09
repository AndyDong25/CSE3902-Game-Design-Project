using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;

namespace CSE3902_Project.Objects.Bomb
{
    public class StaticBomb : ISprite, ICollideable
    {
        public Game1 game;
        private Player player;
        public Vector2 pos;
        public Texture2D texture { get; set; }
        public ICollisionHandler collisionHandler;
        public Rectangle collider2D { get; set; }
     
        public int timer;

        public bool passable;

        private int animationSpeed;
        private byte tintAmount;
        private Color bombColor;
        public StaticBomb(Game1 game, Player player, Vector2 pos)
        {
            this.player = player;
            this.game = game;
            texture = ItemTextureStorage.Instance.getBombObjectSprite();
            this.pos = pos;
            timer = 200;
            collider2D = new Rectangle((int)pos.X + 2, (int)pos.Y + 6, 35, 40);
            if (player.collider2D.Intersects(collider2D))
            {
                passable = true;
            }
            animationSpeed = 200;
            tintAmount = 10;
            bombColor = Color.White;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourcerectangle = new Rectangle(0, 0, 255, 255);
            Rectangle destinationrectangle = new Rectangle((int)pos.X, (int)pos.Y, 45, 45);
            spriteBatch.Draw(texture, destinationrectangle, sourcerectangle, bombColor);
        }

        public void Update()
        {
            if (--animationSpeed % 10 == 0)
            {
                bombColor.B -= tintAmount;
                bombColor.G -= tintAmount;
            }
            timer--;
            if (timer <= 0)
            {
                game.map.tileMap.tileMap.Remove(pos);
                game.map.finishedBombs.Add(this);
/*                game.map.staticBombList.Remove(this);
                game.map.allObjects.Remove(this);*/
                game.map.AddExplosions(pos, player.potionCount);
                player.bombCount++;
            }
            if (!player.collider2D.Intersects(collider2D))
            {
                passable = false;
            }
        }

        public void UpdateCollider()
        {
            
        }
    }
}

