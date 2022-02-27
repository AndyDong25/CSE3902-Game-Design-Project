using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Collisions;
using sprint2.Objects.Bomb;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sprint2.Objects.NPC
{
    public class Enemy : IEnemyState
    {
        public IEnemyState currState;
        public int SpriteIndex = 0;
        public int TextureIndex = 0;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 3.0f;
        public float framePerStep = 3;
        public int direction = 2;
        private int randomNum = 1;
        private int count = 0;
        public int potionCount = 3;

        public ICollisionHandler collisionHandler;
        public Rectangle collider2D;
        private Game1 Game { get; set; }

        StaticBombForEnemy staticBomb { get; set; }
        private int maxBombs = 10;
        public Texture2D bombTexture = ItemTextureStorage.Instance.getBombObjectSprite();
        public Dictionary<Vector2, int> staticBombList = new Dictionary<Vector2, int>();
        public Dictionary<Vector2, int> staticExplosionList = new Dictionary<Vector2, int>();

        public Enemy (Vector2 position, Game1 game)
        {
            currState = new EnemyFacingNorthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.Game = game;
            staticBomb = new StaticBombForEnemy(bombTexture, this);
            collider2D = new Rectangle((int)xPos + 20, (int)yPos + 10, 20, 30);
        }

        public void DropBomb()
        {
            Vector2 bombPos = new Vector2(((int)xPos + 30) / 10 * 10, ((int)yPos + 30) / 10 * 10);
            if (!staticBombList.Keys.Contains(bombPos) && staticBombList.Count < maxBombs)
            {
                staticBombList.Add(bombPos, 200);
            }
        }

        public void GenerateNpc()
        {
            Random rd = new Random();
            if (count % 20 == 0) randomNum = rd.Next(1, 7);

            if (randomNum == 1) this.MoveUp();

            if (randomNum == 2) this.MoveDown();

            if (randomNum == 3) this.MoveLeft();

            if (randomNum == 4) this.MoveRight();

            if (randomNum == 5) this.DropBomb();

            count++;
        }

        public void PositionLimit()
        {
            if (xPos < 20) xPos = 20;

            if (yPos < 5) yPos = 5;

            if (xPos > 700) xPos = 700;

            if (yPos > 400) yPos = 400;
        }

        private void DrawBombs(SpriteBatch spriteBatch)
        {
            List<Vector2> bombList = new List<Vector2>(staticBombList.Keys);
            foreach (Vector2 bomb in bombList)
            {
                staticBombList[bomb]--;
                if (staticBombList[bomb] < 0)
                {
                    staticBombList.Remove(bomb);
                    staticExplosionList.Add(bomb, 20);
                }
            }
            foreach (Vector2 bomb in bombList)
            {
                staticBomb.Draw(spriteBatch, bomb);
            }
        }

        private void DrawExplosions(SpriteBatch spriteBatch)
        {
            List<Vector2> explosionList = new List<Vector2>(staticExplosionList.Keys);
            foreach (Vector2 explosion in explosionList)
            {
                int timer = staticExplosionList[explosion]--;
                if (timer != 0)
                {
                    int x = (int)explosion.X;
                    int y = (int)explosion.Y;
                    List<Rectangle> bombrange = new List<Rectangle> { };
                    // explosion origin
                    bombrange.Add(new Rectangle(x, y, 50, 50));
                    for (int i = 1; i < potionCount; i++)
                    {
                        bombrange.Add(new Rectangle(50 * i + x, y, 50, 50));
                        bombrange.Add(new Rectangle(x, 50 * i + y, 50, 50));
                        bombrange.Add(new Rectangle(x - (50 * i), y, 50, 50));
                        bombrange.Add(new Rectangle(x, y - (50 * i), 50, 50));
                        staticBomb.Explode(spriteBatch, bombrange);
                    }
/*                    List<Vector2> tilesPos = new List<Vector2>(Game.mapDir.Keys);

                    foreach (Rectangle rec in bombrange)
                    {
                        foreach (Vector2 pos in tilesPos)
                        {
                            if (rec.Contains(pos))
                            {
                                Game.mapDir.Remove(pos);
                            }
                        }
                    }*/
                }
                else
                {
                    staticExplosionList.Remove(explosion);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            GenerateNpc();
            PositionLimit();
            DrawBombs(spriteBatch);
            DrawExplosions(spriteBatch);
            UpdateCollider();
        }

        public void TakeDamage()
        {
        }

        public void Update()
        {
            currState.Update();
        }

        public void MoveUp()
        {
            currState.MoveUp();
        }

        public void MoveDown()
        {
            currState.MoveDown();
        }

        public void MoveLeft()
        {
            currState.MoveLeft();
        }

        public void MoveRight()
        {
            currState.MoveRight();
        }

        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, int XOffset = 0, int YOffset = 0)
        {
            Rectangle destination = new Rectangle((int)xPos + XOffset, (int)yPos + YOffset, 60, 60);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }
        private void UpdateCollider()
        {
            collider2D.X = (int)xPos + 20;
            collider2D.Y = (int)yPos + 10;
        }

        public void UpdatePreviousPosition()
        {
            previousXPos = xPos;
            previousYPos = yPos;
        }
    }
}
