using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CSE3902_CSE3902_Project.Objects.Player
{
    class PlayerFacingEastState : IPlayerState
    {
        private Player player;
        private int framesLeft;

        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.BOMBER_EAST,SpriteConstants.KNIGHT_EAST, SpriteConstants.GOBLIN_EAST,SpriteConstants.GHOST_EAST
        };
        
        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;
        public PlayerFacingEastState(Player player)
        {
            this.player = player;
            framesLeft = (int)player.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = player.spriteIndex;
            player.direction = 1;
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
            else if (myTextureIndex == 3)
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
            player.xPos += player.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)player.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[player.spriteIndex].Count;
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
