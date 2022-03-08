﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.NinjaStar;
using System.Collections.Generic;

namespace CSE3902_CSE3902_Project.Objects.Player
{
    public class Player : ICollideable
    {
        public IPlayerState currState;
        public int spriteIndex = 0;
        public int textureIndex = 0;
        public int potionCount = 3;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 3.0f;
        public float framePerStep = 6;
        public int direction = 2;
        public Boolean isDead = false;

        public ICollisionHandler collisionHandler;
        public Rectangle collider2D;

        private Game1 Game { get; set; }
        public Dictionary<String, int> inventory;

        public int maxBombs { get; set; } = 10;

        public Player(Vector2 position, Game1 game)
        {
            currState = new PlayerFacingSouthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.Game = game;
            collider2D = new Rectangle((int)xPos + 18, (int)yPos + 19, 24, 22);
            // initialize inventory to 1 ninja star
            inventory = new Dictionary<String, int>();
            inventory.Add("ninjaStar", 1);
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
            if (!isDead)
            {
                Vector2 tilePos = Game.map.tileMap.RoundToNearestTile(new Vector2((int)xPos + 12, (int)yPos + 15));
                bool success = Game.map.tileMap.AddBombToTileMap(tilePos);
                if (success)
                {
                    Game.map.AddBomb(this, tilePos);
                }
            }
        }

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
            checkMapBounds();
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
                    speed = 3.0f;
                    potionCount = 3;
                    framePerStep = 6;
                    break;
                // knight
                case 1:
                    speed = 6.0f;
                    potionCount = 3;
                    framePerStep = 3;
                    break;
                case 2:
                // goblin
                    speed = 3.0f;
                    potionCount = 6;
                    framePerStep = 6;
                    break;
                case 3:
                // ghost
                    speed = -4.0f;
                    potionCount = 3;
                    framePerStep = 6;
                    break;
                default:
                    break;
            }
        }

        private void checkMapBounds()
        {
            if (xPos < -15) xPos = -15;
            
            if (yPos < -20) yPos = -20;
            
            if (xPos > 760) xPos = 760;
            
            if (yPos > 440) yPos = 440;            
        }

        public void UpdateCollider()
        {
            collider2D.X = (int)xPos + 20;
            collider2D.Y = (int)yPos + 20;
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
    }
}
