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
            timer = 100;
        }
        public void RenewCoins(Map1 map)
        {
            coinPos = map.coinPosList;
            remainCoins = 20-map.coinList.Count();
            for (int i = 0; i < remainCoins/2; i++)
            {
                row = rnd.Next(0, 20);
                col = rnd.Next(0, 12);
                Vector2 pos = new Vector2(row * 40 + 8, col * 40 + 8);
                if (!coinPos.Contains(pos))
                {
                    map.coinPosList.Add(pos);
                    map.coinList.Add(new Coin(pos, game));
                    map.allObjects.Add(new Coin(pos, game));
                }

            }
            
        }
        public void Update()
        {
            timer = (timer+1) % 100;
            if (timer== 0)
            {
                RenewCoins(map);
            }

        }
    }
}
