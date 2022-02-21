using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace sprint2.Objects.NPC.Snake
{
    class Snake : IEnemyState
    {
        private Game1 game;
        public IEnemyState currState;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 2.0f;
        public float framePerStep = 7;
        public Random r = new Random();

        public Snake(Vector2 position, Game1 game)
        {
            currState = new SnakeFacingNorthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.game = game;
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
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            currState.Update();
            previousXPos = xPos;
            previousYPos = yPos;
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
    }
}
