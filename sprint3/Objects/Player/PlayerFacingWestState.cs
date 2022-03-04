using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CSE3902_CSE3902_Project.Objects.Player
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
            framesLeft = (int)player.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = player.spriteIndex;
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
            myTextureIndex = player.spriteIndex;
        }

        public void MoveDown()
        {
            player.currState = new PlayerFacingSouthState(player);
        }

        public void MoveLeft()
        {
           
            player.xPos -= player.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)player.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[player.spriteIndex].Count;
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
