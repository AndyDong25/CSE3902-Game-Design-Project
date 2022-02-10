using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace sprint2
{
    interface IItem
    {
        void Activate();

        void Update();
        
        public Rectangle getSprite();

    }
}
