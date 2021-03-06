using CSE3902_CSE3902_Project;
using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_Project.Objects.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Project.Objects.NPC.AIPlayer
{
    class AIPlayerFacingEastState : IEnemyState
    {
        private AIPlayer enemy;
        private int framesLeft;
        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.REDBOY_EAST,SpriteConstants.WHITEGIRL_EAST, SpriteConstants.GREENBOY_EAST,SpriteConstants.BROWNBOY_EAST
        };
        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;

        public AIPlayerFacingEastState(AIPlayer enemy)
        {
            this.enemy = enemy;
            framesLeft = (int)enemy.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = enemy.SpriteIndex;
            enemy.direction = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myTextureIndex == 0)
            {
                texture = PlayerTextureStorage.Instance.getRedBoySpriteSheet();
            }
            else if (myTextureIndex == 1)
            {
                texture = PlayerTextureStorage.Instance.getWhiteGirlSpriteSheet();
            }
            else if (myTextureIndex == 2)
            {
                texture = PlayerTextureStorage.Instance.getGreenBoySpriteSheet();
            }
            else if (myTextureIndex == 3)
            {
                texture = PlayerTextureStorage.Instance.getBrownBoySpriteSheet();
                mySourceIndex = 0;
            }
            Rectangle source = mySources[myTextureIndex][mySourceIndex];
            enemy.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
            enemy.currState = new AIPlayerFacingSouthState(enemy);
        }

        public void MoveLeft()
        {
            enemy.currState = new AIPlayerFacingWestState(enemy);
        }

        public void MoveRight()
        {
            enemy.xPos += enemy.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)enemy.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[enemy.SpriteIndex].Count;
            }
        }

        public void MoveUp()
        {
            enemy.currState = new AIPlayerFacingNorthState(enemy);
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            myTextureIndex = enemy.SpriteIndex;
        }

        public void UpdatePreviousPosition()
        {
            enemy.UpdatePreviousPosition();
        }

        public bool IsDead()
        {
            return enemy.isDead;
        }
    }
}

