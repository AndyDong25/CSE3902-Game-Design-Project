using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Objects.Player
{
    class PlayerFacingNorthState : IPlayerState
    {
        private Player player;
        private int framesLeft;
        private static List<Rectangle> mySources = new List<Rectangle>
        {
            SpriteConstants.BOMBER_IDLE_NORTH,
            SpriteConstants.BOMBER_STEP_NORTH1,
            SpriteConstants.BOMBER_STEP_NORTH2
        };
        private int mySourceIndex;
        private int myTextureIndex;

        public PlayerFacingNorthState(Player player)
        {
            this.player = player;
            framesLeft = (int)Player.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = PlayerTextureStorage.Instance.getBomberSpriteSheet();
            Rectangle source = mySources[mySourceIndex];
            player.DrawSprite(spriteBatch, texture, source);
        }

        public void Update()
        {

        }
        public void setTextureIndex(int index)
        {
            myTextureIndex = index;
        }

        public void MoveDown()
        {
            player.currState = new PlayerFacingSouthState(player);
        }

        public void MoveLeft()
        {
            player.currState = new PlayerFacingWestState(player);
        }

        public void MoveRight()
        {
            player.currState = new PlayerFacingEastState(player);
        }

        public void MoveUp()
        {
            player.yPos -= Player.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)Player.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources.Count;
            }
        }

        public void TakeDamage()
        {
        }

    }
}
