using CSE3902_Sprint2;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Bomb;
using sprint2.Objects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sprint2.Objects.NPC
{
    public class Enemy : IEnemyState
    {
        public IEnemyState currState;
        public int SpriteIndex = 0;
        public int TextureIndex = 0;

        public bool hasNinjaStar = true;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 3.0f;
        public float framePerStep = 3;

        public int direction = 2;
        int randomNum = 1;
        int count = 0;

        public static Boolean isDead = false;
        public Game1 Game { get; set; }
        private ISprite bomb { get; set; }
        private NinjaStar ninjaStar { get; set; } = null;
        StaticBomb staticBomb { get; set; }
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

        }
        public void DropBomb()
        {
            //Game.staticBomb.Draw(Game.spriteBatch, new Vector2((int)xPos, (int)yPos));
            Vector2 bombPos = new Vector2(((int)xPos + 30) / 10 * 10, ((int)yPos + 30) / 10 * 10);
            if (staticBombList.Keys.Contains(bombPos) && staticBombList.Count < maxBombs)
            {
                staticBombList.Add(bombPos, 200);
            }
            //StaticBomb bomb = new StaticBomb(Game.bombTexture);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            if (ninjaStar != null) { ninjaStar.DrawSprite(spriteBatch); }

            // Generate NPC
            Random rd = new Random();

            if(count % 20 == 0)
            {
                randomNum = rd.Next(1, 6);
            }

            if (randomNum == 1)
            {
                this.MoveUp();
                if (this.yPos < 5)
                {
                    this.yPos = 5;
                }
                count++;
            }
            if (randomNum == 2)
            {
                this.MoveDown();
                if (this.yPos > 400)
                {
                    this.yPos = 400;
                }
                count++;
            }
            if (randomNum == 3)
            {
                this.MoveLeft();
                if (this.xPos < 20)
                {
                    this.xPos = 20;
                }
                count++;
            }
            if (randomNum == 4)
            {
                this.MoveRight();
                if (this.xPos > 700)
                {
                    this.xPos = 700;
                }
                count++;
            }
            if (randomNum == 5)
            {
                this.DropBomb();
                count++;
            }

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
            List<Vector2> explosionList = new List<Vector2>(staticExplosionList.Keys);
            foreach (Vector2 explosion in explosionList)
            {
                int timer = staticExplosionList[explosion]--;
                if (timer != 0)
                {
                    staticBomb.Explode(spriteBatch, explosion);
                }
                else
                {
                    staticExplosionList.Remove(explosion);
                }
            }
        }
        public void ChangeCharacter()
        {
            SpriteIndex = (++SpriteIndex % 4);
        }
        public void TakeDamage()
        {
        }

        public void Update()
        {
            if (ninjaStar != null) { ninjaStar.Update(); }
            currState.Update();
            previousXPos = xPos;
            previousYPos = yPos;
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
        public void UseItem()
        {
            //if (hasNinjaStar)
            //{
            //    ninjaStar = new NinjaStar(this, Game);
            //    //hasNinjaStar = false;
            //}
        }
        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, int XOffset = 0, int YOffset = 0)
        {
            Rectangle destination = new Rectangle((int)xPos + XOffset, (int)yPos + YOffset, 60, 60);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }
    }
}
