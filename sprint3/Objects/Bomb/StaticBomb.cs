using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Items;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using sprint3.Objects.Bomb;

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
        public bool HelperMode;
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

        public Texture2D RangeTexture { get; set; }
        public ExplosionRange RangeExplosion;
        public StaticBomb(Game1 game, Player player, Vector2 pos)
        {
            this.player = player;
            this.game = game;
            texture = ItemTextureStorage.Instance.getBombObjectSprite();
            RangeTexture = ItemTextureStorage.Instance.getExplosionSprite();
            sourceRec = SpriteConstants.STATIC_BOMB;
            this.pos = pos;
            timer = 200;
            collider2D = new Rectangle((int)pos.X + 4, (int)pos.Y + 6, 32, 35);
            directionChained = 0;
            animationSpeed = 200;
            tintAmount = 10;
            bombColor = Color.White;
            HelperMode = !game.HelperMode;
            CheckInitialBombColliderState();

            

            RangeExplosion = new ExplosionRange(game);
            //RangeExplosion.SetAllEplosions();

        }

        public StaticBomb(Game1 game)
        {
            this.game = game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationrectangle = new Rectangle((int)pos.X, (int)pos.Y, 45, 45);
           spriteBatch.Draw(texture, destinationrectangle, sourceRec, bombColor);
        }

        public void Update()
        {
            HelperMode = game.HelperMode;
            CheckUpdatedBombColliderState();
            if (HelperMode == true) { 
            game.currentMap.AddExplosionsRange(pos, player.potionCount, directionChained);
            }
            if (--animationSpeed % 10 == 0)
            {
                bombColor.B -= tintAmount;
                bombColor.G -= tintAmount;
            }
            timer--;
            if (timer <= 0)
            {
                game.currentMap.tileMap.tileMap.Remove(pos);
                game.currentMap.finishedBombs.Add(this);
/*                game.map.staticBombList.Remove(this);
                game.map.allObjects.Remove(this);*/
                game.currentMap.AddExplosions(pos, player.potionCount, directionChained);
               
                player.bombCount++;
            }
        }

        public void UpdateCollider()
        {
            
        }

        // boundary case where bomb is dropped on top of a player - needs to disable the bomb collider until player leaves collider range
        private void CheckInitialBombColliderState()
        {
            if (game.currentMap.player1.collider2D.Intersects(collider2D))
            {
                p1Passable = true;
            }
            if (game.currentMap.player2.collider2D.Intersects(collider2D))
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
                if (!game.currentMap.player1.collider2D.Intersects(collider2D))
                {
                    p1Passable = false;
                }
                if (!game.currentMap.player2.collider2D.Intersects(collider2D))
                {
                    p2Passable = false;
                }
            }
        }

        public bool PlayerPassable(Player p)
        {
            if (p == game.currentMap.player1)
            {
                return p1Passable;
            }
            else
            {
                return p2Passable;
            }
        }
        public Rectangle GetCollider2D()
        {
            return collider2D;
        }
        public void setHelperMode()
        {
            game.HelperMode = !game.HelperMode;
        }
    }
}

