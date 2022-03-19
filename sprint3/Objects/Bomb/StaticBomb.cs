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
        private Rectangle sourceRec;
        public Vector2 pos;
        public Texture2D texture { get; set; }
        public ICollisionHandler collisionHandler;
        public Rectangle collider2D { get; set; }

        /* int field to keep track of direction if bomb was "chain exploded" from an explosion
         * 0 - no chain
         * 1 - up
         * 2 - right
         * 3 - down
         * 4 - up
         */
        public int directionChained;
     
        public int timer;

        public bool p1Passable;
        public bool p2Passable;

        private int animationSpeed;
        private byte tintAmount;
        private Color bombColor;

        public StaticBomb(Game1 game, Player player, Vector2 pos)
        {
            this.player = player;
            this.game = game;
            texture = ItemTextureStorage.Instance.getBombObjectSprite();
            sourceRec = SpriteConstants.STATIC_BOMB;
            this.pos = pos;
            timer = 200;
            collider2D = new Rectangle((int)pos.X + 4, (int)pos.Y + 6, 32, 35);
            directionChained = 0;
            animationSpeed = 200;
            tintAmount = 10;
            bombColor = Color.White;
            CheckInitialBombColliderState();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationrectangle = new Rectangle((int)pos.X, (int)pos.Y, 45, 45);
            spriteBatch.Draw(texture, destinationrectangle, sourceRec, bombColor);
        }

        public void Update()
        {
            CheckUpdatedBombColliderState();
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
                game.map.AddExplosions(pos, player.potionCount, directionChained);
                player.bombCount++;
            }
        }

        public void UpdateCollider()
        {
            
        }

        // boundary case where bomb is dropped on top of a player - needs to disable the bomb collider until player leaves collider range
        private void CheckInitialBombColliderState()
        {
            if (game.map.player1.collider2D.Intersects(collider2D))
            {
                p1Passable = true;
            }
            if (game.map.player2.collider2D.Intersects(collider2D))
            {
                p2Passable = true;
            }
        }

        // used to check to when to reactivate bomb collider (after player no longer "in" bomb upon dropping it)
        private void CheckUpdatedBombColliderState()
        {
            // only need to check if bomb is a player is still in the bomb
            if (p1Passable || p2Passable)
            {
                if (!game.map.player1.collider2D.Intersects(collider2D))
                {
                    p1Passable = false;
                }
                if (!game.map.player2.collider2D.Intersects(collider2D))
                {
                    p2Passable = false;
                }
            }
        }

        public bool PlayerPassable(Player p)
        {
            if (p == game.map.player1)
            {
                return p1Passable;
            }
            else
            {
                return p2Passable;
            }
        }
    }
}

