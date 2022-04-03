using System;
using System.Collections.Generic;
using CSE3902_CSE3902_Project;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint3.Map
{
    class CoinsController
    {
        private Game1 game;
        private int width;
        public List<Vector2> tileMap;
        public CoinsController(Game1 game)
        {
            this.game = game;

            tileMap = new List<Vector2>();
        }
    }
}
