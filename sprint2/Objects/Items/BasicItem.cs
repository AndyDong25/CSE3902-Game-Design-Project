using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Items;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint2
{
    public abstract class BasicItem : IItem
    {
        public int increaseAmount = 3;

        public Player boostedPlayer;

        public int xPos;

        public int yPos;

        public bool activated;

        public int timer;

        public ISprite item;

        public Texture2D texture = ItemTextureStorage.Instance.getBombItemSprite();
        public Rectangle sourceRec = SpriteConstants.BOMB_ITEM;

        public Game1 gameRef;



        public void Initialize(int xPos, int yPos, ISprite item, Game1 gameRef) { 
        
        
            //we might be able to put this in some initialization function
            // as opposed to the constructor and destructor, might be neater/more efficient
            this.xPos = xPos;
            this.yPos = yPos;
            this.item = item;
            this.gameRef = gameRef;
            gameRef.map.currentItemList.Add(this);


        }

        public virtual void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
        }

        public ISprite GetSprite()
        {
            return item;
        }
   

        public void Update()
        {
            if (activated)
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
            }

        }

        public void Destroy()
        {
            gameRef.map.currentItemList.Remove(this);
            
            
        }

        public virtual void Deactivate()
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
