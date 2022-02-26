using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CSE3902_Sprint2.Objects.Player
{
    class PlayerFacingNorthState : IPlayerState
    {
        private Player player;
        private int framesLeft;


        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.BOMBER_NORTH,SpriteConstants.KNIGHT_NORTH, SpriteConstants.GOBLIN_NORTH,SpriteConstants.GHOST_NORTH

        };
        
        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;
        public PlayerFacingNorthState(Player player)
        {
            this.player = player;
            framesLeft = (int)player.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = player.spriteIndex;
            player.direction = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (myTextureIndex == 0)
            {
                texture = PlayerTextureStorage.Instance.getBomberSpriteSheet();
            }
            else if (myTextureIndex == 1)
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
            player.currState = new PlayerFacingWestState(player);
        }

        public void MoveRight()
        {
            player.currState = new PlayerFacingEastState(player);
        }

        public void MoveUp()
        {
            
            player.yPos -= player.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)player.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[player.spriteIndex].Count;
            }
        }

        public void TakeDamage()
        {
        }

    }
}
