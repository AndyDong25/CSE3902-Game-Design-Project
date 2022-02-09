using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Objects.Player
{
    class PlayerFacingEastState : IPlayerState
    {
        private Player player;
        private int framesLeft;
        private static List<Rectangle> mySourcesBomber = new List<Rectangle>
        {
            SpriteConstants.BOMBER_IDLE_EAST,
            SpriteConstants.BOMBER_STEP_EAST1,
            SpriteConstants.BOMBER_STEP_EAST2
        };
        private static List<Rectangle> mySourcesKnight = new List<Rectangle>
        {
            SpriteConstants.KNIGHT_IDLE_EAST,
            SpriteConstants.KNIGHT_STEP_EAST1,
            SpriteConstants.KNIGHT_STEP_EAST2
        };
        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            mySourcesBomber,mySourcesKnight

        };

        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;
        public PlayerFacingEastState(Player player)
        {
            this.player = player;
            framesLeft = (int)Player.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = player.SpriteIndex;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myTextureIndex == 0)
            {
                texture = PlayerTextureStorage.Instance.getBomberSpriteSheet();
            }
            else
            {
                texture = PlayerTextureStorage.Instance.getKnightSpriteSheet();
            }
            
            Rectangle source = mySources[myTextureIndex][mySourceIndex];
            player.DrawSprite(spriteBatch, texture, source);
        }

        public void Update()
        {
            myTextureIndex = player.SpriteIndex;
        }

        public void ChangeTexture()
        {
           
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
            
            player.xPos += Player.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)Player.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[0].Count;
            }
        }

        public void MoveUp()
        {
            player.currState = new PlayerFacingNorthState(player);

        }

        public void TakeDamage()
        {
        }
    }
}
