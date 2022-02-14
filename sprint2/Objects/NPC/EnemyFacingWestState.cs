using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint2.Objects.NPC
{
    class EnemyFacingWestState : IEnemyState
    {
        private Enemy enemy;
        private int framesLeft;
        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.BOMBER_WEST,SpriteConstants.KNIGHT_WEST, SpriteConstants.GOBLIN_WEST,SpriteConstants.GHOST_WEST
        };

        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;

        public EnemyFacingWestState(Enemy enemy)
        {
            this.enemy = enemy;
            framesLeft = (int)enemy.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = enemy.SpriteIndex;
            enemy.direction = 3;
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
            enemy.currState = new EnemyFacingSouthState(enemy);
        }

        public void MoveLeft()
        {
            enemy.xPos -= enemy.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)Player.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[enemy.SpriteIndex].Count;
            }
        }

        public void MoveRight()
        {
            enemy.currState = new EnemyFacingEastState(enemy);
        }

        public void MoveUp()
        {
            enemy.currState = new EnemyFacingNorthState(enemy);
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            myTextureIndex = enemy.SpriteIndex;
        }
    }
}
