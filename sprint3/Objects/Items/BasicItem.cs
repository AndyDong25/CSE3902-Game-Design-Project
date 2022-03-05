﻿using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Project.Collisions;

namespace CSE3902_CSE3902_Project
{
    public abstract class BasicItem : IItem, ISprite, ICollideable
    {
        public Texture2D texture;

        public int increaseAmount = 1;

        public Player boostedPlayer;

        private float xPos;
        private float yPos;


        private Game1 gameRef;

        public bool activated;

        public int timer = 600;
        
        public Rectangle sourceRec;

        public Rectangle collider2D { get; set; }
        public ICollisionHandler collisionHandler;

        public int invincibilityTimer;
        public bool invincible;
        public BasicItem(Vector2 position, Game1 game)
        {
            xPos = position.X;
            yPos = position.Y;
            gameRef = game;
            
            collider2D = new Rectangle((int)xPos, (int)yPos, 35, 35);
            invincibilityTimer = 20;
            invincible = true;
        }

        public virtual void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
            activated = true;
            Destroy();
        }

        public ISprite GetSprite()
        {
            return this;
        }

        public void Update()
        {
            invincibilityTimer--;
            if (invincibilityTimer <= 0)
            {
                invincible = false;
            }
            // later sprints
            /*if (activated)
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
            gameRef.map.finishedItems.Add(this);
            
            // this is an optional implmentation to take place if we don't want to call !activated in the Draw function
            
            /*if (gameRef.map.currentItemList.Contains(this))
            {
                gameRef.map.currentItemList.Remove(this);
            }
            */
        }

        public virtual void Deactivate()
        {

            if (gameRef.map.finishedItems.Contains(this))
            {
                gameRef.map.finishedItems.Remove(this);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (!activated)
            {
                Rectangle destination = new Rectangle((int)xPos, (int)yPos, 35, 35);
                spriteBatch.Draw(texture, destination, sourceRec, Color.White);
            }
        }

        public void UpdateCollider()
        {
            // items will be stationary, so nothing needs to be done here
        }
    }
}
