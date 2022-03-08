using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.NinjaStar;
using System.Collections.Generic;
using CSE3902_CSE3902_Project.Sprites;

namespace CSE3902_CSE3902_Project.Objects.Player
{
    public class Player : ICollideable, ISprite
    {
        public IPlayerState currState;
        public int spriteIndex = 0;
        public int textureIndex = 0;

        public int potionCount = 2;
        public int bombCount = 3;
        public float speed = 3.0f;

        public int maxBombs { get; set; } = 10;
        public int maxPotions { get; set; } = 8;
        public int maxShoes { get; set; } = 9;


        public float xPos, yPos, previousXPos, previousYPos;

        public float framePerStep = 6;
        public int direction = 2;
        public Boolean isDead = false;

        public ICollisionHandler collisionHandler;
        public Rectangle collider2D { get; set; }

        private Game1 Game { get; set; }

        public Dictionary<String, int> inventory;

        public Player(Vector2 position, Game1 game)
        {
            currState = new PlayerFacingSouthState(this);
            xPos = position.X;
            yPos = position.Y;
            previousXPos = xPos;
            previousYPos = yPos;
            this.Game = game;
            collider2D = new Rectangle((int)xPos + 18, (int)yPos + 19, 24, 22);
            InitializeInventory();
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void MoveDown()
        {
            currState.MoveDown();
        }

        public void MoveUp()
        {
            currState.MoveUp();
        }

        public void MoveLeft()
        {
            currState.MoveLeft();
        }

        public void MoveRight()
        {
            currState.MoveRight();
        }

        public void DropBomb()
        {
            if (!isDead && bombCount != 0)
            {
                Vector2 tilePos = Game.map.tileMap.RoundToNearestTile(new Vector2((int)xPos + 12, (int)yPos + 15));
                bool success = Game.map.tileMap.AddBombToTileMap(tilePos);
                if (success)
                {
                    Game.map.AddBomb(this, tilePos);
                    bombCount--;
                }
            }
        }

        //  maybe pass in an index to determine which item to use when implemented later
        public void UseItem()
        {
            if (inventory["ninjaStar"] > 0)
            {
                Game.map.AddNinjaStar(this);
                inventory["ninjaStar"]--;
            }
        }

        public void ChangeCharacter()
        {
            spriteIndex = (++spriteIndex % 4);
            ApplyAbilities();
        }

        public void Update()
        {
            currState.Update();
            CheckMapBounds();
            UpdateCollider();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
        }

        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, int XOffset = 0, int YOffset = 0)
        {
            
            Rectangle destination = new Rectangle((int)xPos + XOffset, (int)yPos + YOffset,60, 60);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void ApplyAbilities()
        {
            switch(spriteIndex)
            {
                // bomberman
                case 0:
                    speed = inventory["shoe"];
                    potionCount = inventory["potion"];
                    bombCount = inventory["bomb"];
                    framePerStep = 6;
                    break;
                // knight
                case 1:
                    speed = 10.0f;
                    potionCount = 4;                 
                    framePerStep = 3;
                    break;
                case 2:
                // goblin
                    speed = 5.0f;
                    potionCount = 6;
                    framePerStep = 6;
                    break;
                case 3:
                // ghost
                    speed = -5.0f;
                    potionCount = 5;
                    framePerStep = 6;
                    break;
                default:
                    break;
            }
        }

        private void CheckMapBounds()
        {
            if (xPos < -15) xPos = -15;
            
            if (yPos < -20) yPos = -20;
            
            if (xPos > 760) xPos = 760;
            
            if (yPos > 440) yPos = 440;            
        }

        public void UpdateCollider()
        {
            collider2D  = new Rectangle((int)xPos + 18, (int)yPos + 19, 24, 22);
        }

        public void PlayerCollisionTest()
        {
            xPos = previousXPos;
            yPos = previousYPos;
            UpdateCollider();
        }

        public void UpdatePreviousPosition()
        {
            previousXPos = xPos;
            previousYPos = yPos;
        }

        public void InitializeInventory()
        {
            inventory = new Dictionary<String, int>();
            inventory.Add("ninjaStar", 1);
            inventory.Add("bomb", 3);
            inventory.Add("potion", 2);
            inventory.Add("shoe", 3);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
        }
    }
}
