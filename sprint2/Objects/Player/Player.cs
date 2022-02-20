using CSE3902_Sprint2.Objects;
using CSE3902_Sprint2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint2.Objects.Bomb;
using sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSE3902_Sprint2.Objects.Player
{
    public class Player
    {
        public IPlayerState currState;
        public int SpriteIndex = 0;
        public int TextureIndex = 0;
        public bool hasNinjaStar = true;
        public int potionCount = 3;
        public float xPos, yPos, previousXPos, previousYPos;
        public float speed = 3.0f;
        public float framePerStep = 6;
        public int direction = 2;
        public static Boolean isDead = false;
        public Game1 Game { get; set; }
        private NinjaStar ninjaStar { get; set; } = null;
        private StaticBomb staticBomb { get; set; }
        private int maxBombs = 10;
        public Texture2D bombTexture = ItemTextureStorage.Instance.getBombObjectSprite();
        public Dictionary<Vector2, int> staticBombList = new Dictionary<Vector2, int>();
        public Dictionary<Vector2, int> staticExplosionList = new Dictionary<Vector2, int>();

        public Player(Vector2 position, Game1 game)
        {
            currState = new PlayerFacingSouthState(this);
            xPos = position.X;
            yPos = position.Y;
            this.Game = game;
            staticBomb = new StaticBomb(bombTexture, this);
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void MoveDown()
        {
            currState.MoveDown();
        }

        public void MoveUp()
        {
            currState.MoveUp();
        }

        public void MoveLeft()
        {
            currState.MoveLeft();
        }

        public void MoveRight()
        {
            currState.MoveRight();
        }

        public void DropBomb()
        {
            Vector2 bombPos = new Vector2(((int)xPos + 30) / 10 * 10, ((int)yPos + 30) / 10 * 10);
            if (!staticBombList.Keys.Contains(bombPos) && staticBombList.Count < maxBombs)
            {
                staticBombList.Add(bombPos, 200);
            }        
        }
        public void UseItem()
        {
            if (hasNinjaStar) ninjaStar = new NinjaStar(this, Game);
        }

        public void ChangeCharacter()
        {
            SpriteIndex = (++SpriteIndex % 4);
            ApplyAbilities();
        }

        public void Update()
        {
            previousXPos = xPos;
            previousYPos = yPos;
            if (ninjaStar != null) { ninjaStar.Update(); }
            currState.Update();
            checkMapBounds();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currState.Draw(spriteBatch);
            DrawBombs(spriteBatch);
            DrawExplosions(spriteBatch);
            if (ninjaStar != null) { ninjaStar.DrawSprite(spriteBatch); }
        }

        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Rectangle source, int XOffset = 0, int YOffset = 0)
        {
            Rectangle destination = new Rectangle((int)xPos + XOffset, (int)yPos + YOffset,60, 60);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void ApplyAbilities()
        {
            switch(SpriteIndex)
            {
                // bomberman
                case 0:
                    speed = 3.0f;
                    potionCount = 3;
                    framePerStep = 6;
                    break;
                // knight
                case 1:
                    speed = 6.0f;
                    potionCount = 3;
                    framePerStep = 3;
                    break;
                case 2:
                // goblin
                    speed = 3.0f;
                    potionCount = 6;
                    framePerStep = 6;
                    break;
                case 3:
                // ghost
                    speed = -4.0f;
                    potionCount = 3;
                    framePerStep = 6;
                    break;
                default:
                    break;
            }
        }

        private void checkMapBounds()
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
                    //explosion origin
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
    }
}
