using CSE3902_Sprint2.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Objects.Player
{
    public class Player
    {
        public IPlayerState currState;
        public int SpriteIndex = 0;
        public int TextureIndex = 0;

        public float xPos, yPos, previousXPos, previousYPos;
        public static float speed = 3.0f;
        public static float framePerStep = 6;

        public static Boolean isDead = false;

        public Player(Vector2 position)
        {
            currState = new PlayerFacingEastState(this);
            xPos = position.X;
            yPos = position.Y;
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

        }
        public void UseItem()
        {

        }
        public void ChangeCharacter()
        {
            
         
   
        }
        public void Update()
        {
            currState.Update();
            previousXPos = xPos;
            previousYPos = yPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
        }

        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, int XOffset = 0, int YOffset = 0)
        {
            Rectangle destination = new Rectangle(
                (int)xPos + XOffset, (int)yPos + YOffset,
                60, 60);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

    }
}
