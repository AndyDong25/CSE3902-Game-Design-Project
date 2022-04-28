using System;
using System.Collections.Generic;
using System.Linq;
using CSE3902_CSE3902_Project;
using CSE3902_Project.Map;
using CSE3902_Project.Objects.NPC.AIPlayer;
using Microsoft.Xna.Framework;
using sprint3.Objects.Decorations;

namespace sprint3.Map
{
    public class EnemySpawner
    {
        private int timer;
        private int col;
        private int row;
        private Map1 map;
        private Game1 game;
        private List<Vector2> coinPos;
        private Random rnd = new Random();
        private int interval;
        public EnemySpawner(Game1 game, Map1 map)
        {
            this.game = game;
            this.map = map;
            timer = 950; //200;
            interval = 1000;
        }
        public void EnemySpaw(Map1 map)
        {
            coinPos = map.coinPosList;
            if (game.infiniteMode)
            {
                row = rnd.Next(0, 20);
                col = rnd.Next(0, 12);
                Vector2 pos = new Vector2(row * 40 + 8, col * 40 + 8);
                col = rnd.Next(0, 2);
                if(col == 1)
                {
                    AIPlayer ai = new AIPlayer(pos, game,true);
                    map.currentEnemyList.Add(ai);
                    map.allObjects.Add(ai);
                }
                else
                {
                    AIPlayer ai = new AIPlayer(pos, game, false);
                    map.currentEnemyList.Add(ai);
                    map.allObjects.Add(ai);
                }
                //map.enem.Add(ai);
                
            }
        }
        public void Update()
        {
            timer = (timer + 1) % interval; //250
            if (timer == 0)
            {
                EnemySpaw(map);
                interval = interval / 2 + 50;
            }

        }
    }
}
