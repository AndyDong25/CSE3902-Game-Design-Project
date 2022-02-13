using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using CSE3902_Sprint2.Objects.Player;
using CSE3902_Sprint2.Sprites;


namespace CSE3902_Sprint2
{
    interface IItem
    {
        void Activate(Player currentPlayer);

        void Update();
        
        public ISprite GetSprite();

        void Destroy();

    }
}
