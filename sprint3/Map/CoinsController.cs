using System;
using System.Collections.Generic;
using System.Linq;
using CSE3902_CSE3902_Project;
using CSE3902_Project.Map;
using Microsoft.Xna.Framework;
using sprint3.Objects.Decorations;

namespace sprint3.Map
{
    public class CoinsController
    {
        private int timer;
        private int remainCoins;
        private int col;
        private int row;
        private Map1 map;
        private Game1 game;
        private List<Vector2> coinPos;
        private Random rnd = new Random();
        public CoinsController(Game1 game, Map1 map)
        {
            this.game = game;
            this.map = map;
            timer = 200;
        }
        public void RenewCoins(Map1 map)
        {
            coinPos = map.coinPosList;
            if (!game.coinMode)
            {
                remainCoins = 0;
            }
            else
            {
                remainCoins = 20 - map.coinList.Count();
            }
            for (int i = 0; i < remainCoins/3; i++)
            {
                row = rnd.Next(0, 20);
                col = rnd.Next(0, 12);
                Vector2 pos = new Vector2(row * 40 + 8, col * 40 + 8);
                if (!coinPos.Contains(pos))
                {
                    map.coinPosList.Add(pos);
                    Coin c = new Coin(pos, game);
                    map.coinList.Add(c);
                    map.allObjects.Add(c);

                }

            }
            
        }
        public void Update()
        {
            timer = (timer+1) % 250;
            if (timer== 0)
            {
                RenewCoins(map);
            }

        }
    }
}
