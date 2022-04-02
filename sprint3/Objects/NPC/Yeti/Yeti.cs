using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using System;
using CSE3902_CSE3902_Project.Sprites;

namespace CSE3902_Project.Objects.NPC.Yeti
{
    public class Yeti : IEnemyState, ICollideable, ISprite
    {
        public IEnemyState currState;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 3.0f;
        public float framePerStep = 15;
        public int timeCounter = 300;
        public float acceleration;
        public Boolean isDead = false;

        public ICollisionHandler collisionHandler;
        public Rectangle collider2D;

        public Game1 Game { get; set; }

        public Yeti(Vector2 position, Game1 game)
        {
            currState = new YetiFacingWestState(this);
            xPos = position.X;
            yPos = position.Y;
            this.Game = game;
            acceleration = 0.05f;
            UpdateCollider();
        }

        public void positionLimit()
        {
            if (xPos < -15) xPos = -15;

            if (yPos < -20) yPos = -20;

            if (xPos > 760) xPos = 760;

            if (yPos > 440) yPos = 440;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            positionLimit();
        }
        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            currState.Update();
            UpdateCollider();
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

        public void UpdateCollider()
        {
            collider2D = new Rectangle((int)xPos + 7, (int)yPos + 5, 37, 40);
        }

        public void UpdatePreviousPosition()
        {
            previousXPos = xPos;
            previousYPos = yPos;
        }

        public Rectangle GetCollider2D()
        {
            return collider2D;
        }
    }
}
