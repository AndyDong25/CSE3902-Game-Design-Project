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
    class AIPlayerFacingNorthState : IEnemyState
    {
        private AIPlayer enemy;
        private int framesLeft;
        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.BOMBER_NORTH,SpriteConstants.KNIGHT_NORTH, SpriteConstants.GOBLIN_NORTH,SpriteConstants.GHOST_NORTH
        };

        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;

        public AIPlayerFacingNorthState(AIPlayer enemy)
        {
            this.enemy = enemy;
            framesLeft = (int)enemy.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = enemy.SpriteIndex;
            enemy.direction = 0;
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
            enemy.currState = new AIPlayerFacingEastState(enemy);
        }

        public void MoveUp()
        {
            enemy.yPos -= enemy.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)enemy.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[enemy.SpriteIndex].Count;
            }
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

