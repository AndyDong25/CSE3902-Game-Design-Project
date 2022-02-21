﻿using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint2
{
    public abstract class BasicItem : IItem, ISprite
    {
        public Texture2D texture;

        public int increaseAmount = 3;

        public Player boostedPlayer;

        private float xPos;
        private float yPos;
        private Game1 gameRef;

        public bool activated;

        public int timer;
        
        public Rectangle sourceRec;
  
        public BasicItem(Vector2 position, Game1 game)
        {
            xPos = position.X;
            yPos = position.Y;
            gameRef = game;
        }

        public virtual void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
        }

        public ISprite GetSprite()
        {
            return this;
        }

        public void Update()
        {
            // later sprints
/*            if (activated)
            {
                if (gameRef.map.player1.xPos == xPos && gameRef.map.player2.yPos == yPos)
                {
                    Activate(gameRef.map.player1);
                    Destroy();
                }
                else if (gameRef.map.player2.xPos == xPos && gameRef.map.player2.yPos == yPos)
                {
                    Activate(gameRef.map.player2);
                    Destroy();
                }
                activated = false;
            }
            else
            {
                timer--;
                if (timer <= 0)
                {
                    Deactivate();
                }
            }*/
        }

        public void Destroy()
        {
            gameRef.map.currentItemList.Remove(this);        
        }

        public virtual void Deactivate()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle destination = new Rectangle((int)xPos, (int)yPos, 35, 35);
            spriteBatch.Draw(texture, destination, sourceRec, Color.White);
        }
    }
}
