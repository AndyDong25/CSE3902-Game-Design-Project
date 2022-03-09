using CSE3902_CSE3902_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;
using System;
using CSE3902_CSE3902_Project.Sprites;

namespace CSE3902_Project.Objects.NPC.Bat
{
    public class Bat : IEnemyState, ICollideable, ISprite
    {
        public IEnemyState currState;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 4.5f;
        public float framePerStep = 3;
        public int timeCounter = 150;
        public Boolean isDead = false;

        public ICollisionHandler collisionHandler;
        public Rectangle collider2D;

        public Game1 Game { get; set; }

        Random r = new Random();

        public Bat(Vector2 position, Game1 game)
        {
            currState = new BatFacingSouthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.Game = game;
            collider2D = new Rectangle((int)xPos + 8, (int)yPos + 5, 24, 23);
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
            Rectangle destination = new Rectangle((int)xPos + XOffset, (int)yPos + YOffset, 40, 40);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void UpdateCollider()
        {
            collider2D.X = (int)xPos + 8;
            collider2D.Y = (int)yPos + 5;
        }

        public void UpdatePreviousPosition()
        {
            previousXPos = xPos;
            previousYPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 destination)
        {
            throw new NotImplementedException();
        }
    }
}
