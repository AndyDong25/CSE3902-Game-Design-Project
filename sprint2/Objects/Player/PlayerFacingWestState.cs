using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2.Objects.Player
{
    class PlayerFacingWestState : IPlayerState
    {
        private Player player;
        private int framesLeft;

        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.BOMBER_WEST,SpriteConstants.KNIGHT_WEST, SpriteConstants.GOBLIN_WEST,SpriteConstants.GHOST_WEST

        };
        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;

        public PlayerFacingWestState(Player player)
        {
            this.player = player;
            framesLeft = (int)Player.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = player.SpriteIndex;
            player.direction = 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myTextureIndex == 0)
            {
                texture = PlayerTextureStorage.Instance.getBomberSpriteSheet();
            }
            else if (myTextureIndex ==1)
            {
                texture = PlayerTextureStorage.Instance.getKnightSpriteSheet();
            }
            else if (myTextureIndex == 2)
            {
                texture = PlayerTextureStorage.Instance.getGoblinSpriteSheet();
            }
            else
            {
                texture = PlayerTextureStorage.Instance.getGhostSpriteSheet();
                mySourceIndex = 0;
            }
            Rectangle source = mySources[myTextureIndex][mySourceIndex];
            player.DrawSprite(spriteBatch, texture, source);
        }

        public void Update()
        {
            myTextureIndex = player.SpriteIndex;
        }
        public void setTextureIndex(int index)
        {
            
        }

        public void MoveDown()
        {
            player.currState = new PlayerFacingSouthState(player);
        }

        public void MoveLeft()
        {
           
            player.xPos -= Player.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)Player.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[player.SpriteIndex].Count;
            }
        }

        public void MoveRight()
        {
            player.currState = new PlayerFacingEastState(player);
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
