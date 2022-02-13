using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace CSE3902_Sprint2
{
    public abstract class BasicItem : IItem
    {
        public int increaseAmount = 3;

        public Player boostedPlayer;

        public int xPos;

        public int yPos;

        ISprite item;

        public Game1 gameRef;


        public BasicItem(int xPos, int yPos, ISprite item, Game1 gameRef){
            this.xPos = xPos;
            this.yPos = yPos;
            this.item = item;
            this.gameRef = gameRef;

        }

        public void Activate(Player currentPlayer)
        {
            boostedPlayer = currentPlayer;
        }

        public ISprite GetSprite()
        {
            return item;
        }

        

        public void Update()
        {
            if (gameRef.player1.xPos == xPos && gameRef.player2.yPos == yPos)
            {
                Activate(gameRef.player1);
                Destroy();
            }
            else if (gameRef.player2.xPos == xPos && gameRef.player2.yPos == yPos)
            {
                Activate(gameRef.player2);
                Destroy();
            }

        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
