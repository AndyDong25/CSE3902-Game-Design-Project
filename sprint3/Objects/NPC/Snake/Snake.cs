using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using System;

namespace sprint2.Objects.NPC.Snake
{
    public class Snake : IEnemyState
    {
        private Game1 game;
        public IEnemyState currState;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 2.0f;
        public float framePerStep = 7;
        public Random r = new Random();

        public ICollisionHandler collisionHandler;
        public Rectangle collider2D;

        public Snake(Vector2 position, Game1 game)
        {
            currState = new SnakeFacingNorthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.game = game;
            collider2D = new Rectangle((int)xPos + 3, (int)yPos + 3, 34, 34);
        }

        public void wallRedirect()
        {
            if (xPos < 40) currState = new SnakeFacingEastState(this);

            if (yPos < 5) currState = new SnakeFacingSouthState(this);

            if (xPos > 700) currState = new SnakeFacingWestState(this);

            if (yPos > 430) currState = new SnakeFacingNorthState(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            wallRedirect();
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

        public void UpdateCollider()
        {
            collider2D.X = (int)xPos + 3;
            collider2D.Y = (int)yPos + 3;
        }

        public void UpdatePreviousPosition()
        {
            previousXPos = xPos;
            previousYPos = yPos;
        }
    }
}
