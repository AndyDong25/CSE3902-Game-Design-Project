using CSE3902_Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint2.Objects.NPC
{
    class EnemyFacingEastState : IEnemyState
    {
        private Enemy enemy;
        private int framesLeft;
        private static List<List<Rectangle>> mySources = new List<List<Rectangle>>
        {
            SpriteConstants.REDBOY_EAST,SpriteConstants.WHITEGIRL_EAST, SpriteConstants.GREENBOY_EAST,SpriteConstants.BROWNBOY_EAST
        };

        private int mySourceIndex;
        private int myTextureIndex;
        private Texture2D texture;

        public EnemyFacingEastState(Enemy enemy)
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
            enemy.currState = new EnemyFacingSouthState(enemy);
        }

        public void MoveLeft()
        {
            enemy.currState = new EnemyFacingWestState(enemy);
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
