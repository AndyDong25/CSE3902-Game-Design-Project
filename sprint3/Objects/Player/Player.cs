﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Bomb;
using sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using sprint2.Collisions;
using System.Diagnostics;
using sprint3.Collisions;

namespace CSE3902_Sprint2.Objects.Player
{
    public class Player : ICollideable
    {
        public IPlayerState currState;
        public int spriteIndex = 0;
        public int textureIndex = 0;
        public bool hasNinjaStar = true;
        public int potionCount = 3;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 3.0f;
        public float framePerStep = 6;
        public int direction = 2;
        public static Boolean isDead = false;

        public ICollisionHandler collisionHandler;
        public Rectangle collider2D;

        private Game1 Game { get; set; }
        private NinjaStar ninjaStar { get; set; } = null;

        public StaticBomb staticBomb { get; set; }
        public int maxBombs { get; set; } = 10;
        private Dictionary<Vector2, int> staticBombList = new Dictionary<Vector2, int>();

        public Player(Vector2 position, Game1 game)
        {
            currState = new PlayerFacingSouthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.Game = game;
            staticBomb = new StaticBomb(this);
            collider2D = new Rectangle((int)xPos + 20, (int)yPos + 10, 20, 30);
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
            Vector2 bombPos = new Vector2(((int)xPos + 30) / 10 * 10, ((int)yPos + 30) / 10 * 10);
            if (!staticBombList.Keys.Contains(bombPos) && staticBombList.Count < maxBombs)
            {
                staticBombList.Add(bombPos, 200);
            }        
        }

        public void UseItem()
        {
            if (hasNinjaStar) ninjaStar = new NinjaStar(this, Game);
        }

        public void ChangeCharacter()
        {
            spriteIndex = (++spriteIndex % 4);
            ApplyAbilities();
        }

        public void Update()
        {
            if (ninjaStar != null) { ninjaStar.Update(); }
            currState.Update();
            staticBomb.Update();
            checkMapBounds();
            UpdateCollider();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            DrawBombs(spriteBatch);
            staticBomb.DrawExplosions(spriteBatch);
            if (ninjaStar != null) { ninjaStar.DrawSprite(spriteBatch); }
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
            if (xPos < 20) xPos = 20;
            
            if (yPos < 5) yPos = 5;
            
            if (xPos > 700) xPos = 700;
            
            if (yPos > 400) yPos = 400;            
        }

        private void DrawBombs(SpriteBatch spriteBatch)
        {
            List<Vector2> bombList = new List<Vector2>(staticBombList.Keys);
            foreach (Vector2 bomb in bombList)
            {
                staticBombList[bomb]--;
                if (staticBombList[bomb] < 0)
                {
                    staticBombList.Remove(bomb);
                    staticBomb.AddNewExplosion(bomb, potionCount);
                    //staticBomb.explosion.AddNewExplosionOrigin(bomb, 20);
                }
            }
            foreach (Vector2 bomb in bombList)
            {
                staticBomb.Draw(spriteBatch, bomb);
            }
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
