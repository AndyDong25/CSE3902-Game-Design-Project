using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using System;

namespace sprint2.Objects.NPC.Bat
{
    public class Bat : IEnemyState
    {
        public IEnemyState currState;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 4.5f;
        public float framePerStep = 3;
        public int timeCounter = 150;

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
            if (xPos < 40) xPos = 40;

            if (yPos < 5) yPos = 5;

            if (xPos > 700) xPos = 700;

            if (yPos > 430) yPos = 430;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            positionLimit();
            UpdateCollider();
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            currState.Update();
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

        private void UpdateCollider()
        {
            collider2D.X = (int)xPos + 15;
            collider2D.Y = (int)yPos + 5;
        }

        public void UpdatePreviousPosition()
        {
            previousXPos = xPos;
            previousYPos = yPos;
        }
    }
}
