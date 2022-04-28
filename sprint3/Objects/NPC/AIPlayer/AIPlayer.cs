using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;
using CSE3902_Project.Collisions;
using CSE3902_Project.Objects.Bomb;
using CSE3902_Project.Objects.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint3.Objects;
using sprint3.Objects.Bomb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSE3902_Project.Objects.NPC.AIPlayer
{
    public class AIPlayer : IEnemyState, ICollideable, ISprite, IDynamicObject,IEnemy
    {
        public IEnemyState currState; 
        public int SpriteIndex = 0;
        public int TextureIndex = 0;
        public bool isPet = false;
        public bool hasNinjaStar = true;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 3.0f;
        public int bombCount = 3;
        public float framePerStep = 6;
        public int potionCount = 2;

        public int direction = 2;
        int randomNum = 1;
        int count = 0;
        private int timer = 0;
        public Rectangle collider2D { get; set; }

        public Boolean isDead = false;
        public Game1 Game { get; set; }
        private ISprite bomb { get; set; }
        public bool isDeadWalk = true;
        public AIPlayer(Vector2 position, Game1 game,bool isDeadWalk)
        {
            this.isDeadWalk = isDeadWalk;
            if (isDeadWalk)
            {
                SpriteIndex = 2;
            }
            currState = new AIPlayerFacingNorthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.Game = game;
        }
        public void DropBomb()
        {

            if (!isDead && bombCount != 0)
            {
                Vector2 tilePos = Game.currentMap.tileMap.RoundToNearestTile(new Vector2((int)xPos + 12, (int)yPos + 15));
                bool success = Game.currentMap.tileMap.AddBombToTileMap(tilePos);
                if (success)
                {
                    Game.currentMap.AddBomb(Game.currentMap.player1, new Vector2((int)xPos, (int)yPos - 20), false);
                    bombCount--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            CheckMapBounds();
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            if (!isDeadWalk)
            {
                GenerateRandomBehavior();
                currState.Update();
                UpdateCollider();
                CheckMapBounds();
            }
            else
            {
                if (timer == 0)
                {
                    speed = 0.3f;
                    SpriteIndex = 1;
                    FindPath(FineGoal());
                    UpdateCollider();
                    CheckMapBounds();
                }
            }
            timer = timer++ % 3;
        }
        private Vector2 FineGoal()
        {
            int maxDis = 0;
            Vector2 pos = new Vector2(Game.currentMap.player1.xPos, Game.currentMap.player1.yPos);
            if( ((Game.currentMap.player1.xPos - xPos)*(Game.currentMap.player1.xPos - xPos) + (Game.currentMap.player1.yPos - yPos)* (Game.currentMap.player1.yPos - yPos))>
                ((Game.currentMap.player2.xPos - xPos) * (Game.currentMap.player2.xPos - xPos) + (Game.currentMap.player2.yPos - yPos) * (Game.currentMap.player2.yPos - yPos)
                ))
            {
                pos = new Vector2(Game.currentMap.player2.xPos, Game.currentMap.player2.yPos);
            }
            return pos;
        }
        private void FindPath(Vector2 goal)
        {
            float upDis = yPos- goal.Y;
            float downDis = goal.Y- yPos ;
            float rightDis = goal.X - xPos;
            float leftDis = xPos - goal.X;
            float max = Math.Max(Math.Max(upDis, downDis), Math.Max( rightDis, leftDis));
            if(max == upDis)
            {
                this.MoveUp();
            }
            else if(max == downDis)
            {
                this.MoveDown();
            }
            else if (max == leftDis)
            {
                this.MoveLeft();
            }
            else
            {
                this.MoveRight();
            }

        }
        private void GenerateRandomBehavior()
        {
            Random rd = new Random();
            if (count % 60 == 0)
            {
                randomNum = rd.Next(1, 6);
            }
            if (randomNum == 1)
            {
                this.MoveUp();
                count++;
            }
            else if (randomNum == 2)
            {
                this.MoveDown();
                count++;
            }
            else if (randomNum == 3)
            {
                this.MoveLeft();
                count++;
            }
            else if (randomNum == 4)
            {
                this.MoveRight();
                count++;
            }
            else if (randomNum == 5)
            {
                this.DropBomb();
                count++;
            }
        }

        private void CheckMapBounds()
        {
            if (xPos < -15) xPos = -15;

            if (yPos < -20) yPos = -20;

            if (xPos > 760) xPos = 760;

            if (yPos > 440) yPos = 440;
        }

        public void MoveUp()
        {
            currState.MoveUp();
        }

        public void MoveDown()
        {
            currState.MoveDown();
        }

        public void MoveLeft()
        {
            currState.MoveLeft();
        }

        public void MoveRight()
        {
            currState.MoveRight();
        }
        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, int XOffset = 0, int YOffset = 0)
        {
            Rectangle destination = new Rectangle((int)xPos + XOffset, (int)yPos + YOffset, 60, 60);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void UpdatePreviousPosition()
        {
            previousXPos = xPos;
            previousYPos = yPos;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void UpdateCollider()
        {
            collider2D = new Rectangle((int)xPos + 18, (int)yPos + 22, 24, 20);
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
            currState = new AIPlayerDeathState(this);
            isDead = true;
        }
    }
}

