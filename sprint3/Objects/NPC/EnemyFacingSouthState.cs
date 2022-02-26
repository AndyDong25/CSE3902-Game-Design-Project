using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint2.Objects.NPC
{
    class EnemyFacingSouthState : IEnemyState
    {
        private Enemy enemy;
        private int framesLeft;
        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.REDBOY_SOUTH,SpriteConstants.WHITEGIRL_SOUTH, SpriteConstants.GREENBOY_SOUTH,SpriteConstants.BROWNBOY_SOUTH
        };

        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;

        public EnemyFacingSouthState(Enemy enemy)
        {
            this.enemy = enemy;
            framesLeft = (int)enemy.framePerStep;
            mySourceIndex = 0;
            myTextureIndex = enemy.SpriteIndex;
            enemy.direction = 2;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (myTextureIndex == 0)
            {
                texture = EnemyTextureStorage.Instance.getRedBoySpriteSheet();
            }
            else if (myTextureIndex == 1)
            {
                texture = EnemyTextureStorage.Instance.getWhiteGirlSpriteSheet();
            }
            else if (myTextureIndex == 2)
            {
                texture = EnemyTextureStorage.Instance.getGreenBoySpriteSheet();
            }
            else if (myTextureIndex == 3)
            {
                texture = EnemyTextureStorage.Instance.getBrownBoySpriteSheet();
                mySourceIndex = 0;
            }
            Rectangle source = mySources[myTextureIndex][mySourceIndex];
            enemy.DrawSprite(spriteBatch, texture, source);
        }

        public void MoveDown()
        {
            enemy.yPos += enemy.speed;
            if (--framesLeft <= 0)
            {
                framesLeft = (int)enemy.framePerStep;
                mySourceIndex++;
                mySourceIndex %= mySources[enemy.SpriteIndex].Count;
            }
        }

        public void MoveLeft()
        {
            enemy.currState = new EnemyFacingWestState(enemy);
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
