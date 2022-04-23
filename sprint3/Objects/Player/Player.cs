using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CSE3902_Project.Collisions;
using System.Collections.Generic;
using CSE3902_CSE3902_Project.Sprites;
using System.Diagnostics;
using sprint3.Objects;

namespace CSE3902_CSE3902_Project.Objects.Player
{
    public class Player : ICollideable, ISprite, IDynamicObject
    {
        public IPlayerState currState;
        public int spriteIndex = 0;
        public int textureIndex = 0;
        public Color color;

        public int potionCount = 2;
        public int bombCount = 3;
        public float speed = 3.0f;

        public int maxBombs { get; set; } = 10;
        public int maxPotions { get; set; } = 7;
        public int maxShoes { get; set; } = 14;

        public int collect_coins = 0;
        public float xPos, yPos, previousXPos, previousYPos;

        public float framePerStep = 6;
        public int direction = 2;
        public Boolean isDead = false;

        public ICollisionHandler collisionHandler;

        public bool boosted;
        public int boostedTimer;
        public float boostFadeAmount;
        public Rectangle collider2D { get; set; }

        private Game1 Game { get; set; }

        public Dictionary<String, int> inventory;

        public Player(Vector2 position, Game1 game)
        {
            currState = new PlayerFacingSouthState(this);
            color = Color.White;
            xPos = position.X;
            yPos = position.Y;
            previousXPos = xPos;
            previousYPos = yPos;
            this.Game = game;
            UpdateCollider();
            boosted = false;
            boostedTimer = 1200;
            boostFadeAmount = 1.0f;
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
                Vector2 tilePos = Game.currentMap.tileMap.RoundToNearestTile(new Vector2((int)xPos + 12, (int)yPos + 15));
                bool success = Game.currentMap.tileMap.AddBombToTileMap(tilePos);
                if (success)
                {
                    Game.currentMap.AddBomb(this, tilePos);
                    bombCount--;
                }
            }
        }

        //  maybe pass in an index to determine which item to use when implemented later
        public void UseItem()
        {
            if (inventory["ninjaStar"] > 0)
            {
                Game.currentMap.AddNinjaStar(this);
                inventory["ninjaStar"]--;
            }
        }

        public void UseTorpedo()
        {
            if (inventory["torpedo"] > 0)
            {
                Game.currentMap.AddTorpedo(this);
                inventory["torpedo"]--;
            }
        }

        public void UseLandmine()
        {
            if (inventory["landmine"] > 0)
            {
                Game.currentMap.AddLandmine(this);
                inventory["landmine"]--;
            }
        }

        public void ChangeCharacter()
        {
            spriteIndex = (++spriteIndex % 4);
            ApplyAbilities();
        }

        public void Update()
        {
            UpdateBoostEffects();
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
            spriteBatch.Draw(texture, destination, source, color * boostFadeAmount);
        }

        public void ApplyAbilities()
        {
            switch(spriteIndex)
            {
                // bomberman
                case 0:
                    speed = inventory["shoe"] * 0.5f;
                    potionCount = inventory["potion"];
                    bombCount = inventory["bomb"];
                    framePerStep = 6;
                    break;
                // knight
                case 1:
                    speed = 9.0f;
                    potionCount = 4;                 
                    framePerStep = 3;
                    break;
                case 2:
                // goblin
                    speed = 5.0f;
                    potionCount = 8;
                    framePerStep = 6;
                    break;
                case 3:
                // ghost
                    speed = -6.0f;
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
            collider2D = new Rectangle((int)xPos + 18, (int)yPos + 22, 24, 20);
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
            inventory.Add("shoe", 6);
            inventory.Add("torpedo", 1);
            inventory.Add("landmine", 2);
        }
       
        public void UpdateBoostEffects()
        {
            if (boosted)
            {
                boostedTimer--;
                if (boostedTimer <= 0)
                {
                    boostFadeAmount = 1.0f;
                    boosted = false;
                    boostedTimer = 1200;
                    spriteIndex = 0;
                    ApplyAbilities();
                }
                else if (boostedTimer <= 300)
                {
                    boostFadeAmount -= 0.002f;
                }
            }
        }
        public Rectangle GetCollider2D()
        {
            return collider2D;
        }

        public void GoBackToPrevPosition()
        {
            xPos = previousXPos;
            yPos = previousYPos;
            UpdateCollider();
        }

        public void Die()
        {
            currState = new PlayerDeathState(this);
            isDead = true;
        }
    }
}
