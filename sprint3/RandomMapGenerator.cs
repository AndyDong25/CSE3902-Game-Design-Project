using CSE3902_CSE3902_Project.Objects.Player;
using CSE3902_CSE3902_Project.Sprites.BlockSprites;
using CSE3902_Project.Map;
using CSE3902_Project.Objects.NPC.AIPlayer;
using CSE3902_Project.Objects.NPC.Alien;
using CSE3902_Project.Objects.NPC.Bat;
using CSE3902_Project.Objects.NPC.Snake;
using CSE3902_Project.Objects.NPC.Yeti;
using CSE3902_Project.Sprites.Decorations;
using Microsoft.Xna.Framework;
using sprint3.Objects.Decorations;
using System;
using System.Collections.Generic;

using System.Text;

namespace CSE3902_CSE3902_Project
{
    public class RandomMapGenerator
    {
        private Map1 map;
        private Game1 game;
        private List<Vector2> posList;
        private Random rnd = new Random();
        public RandomMapGenerator(Game1 game, Map1 map)
        {
            this.map = map;
            this.game = game;
            posList = new List<Vector2> { };
        }
        private Vector2 GeneratePosition()
        {
            Vector2 pos = new Vector2(rnd.Next(0, 20) * 40 +20, rnd.Next(0, 12)*40+6);
            while (posList.Contains(pos))
            {
                pos = new Vector2(rnd.Next(0, 20) * 40+20, rnd.Next(0, 12) * 40 +6);
            }
            posList.Add(pos);
            return pos;
        }
        public void GenerateMap()
        {
            map.player1 = new Player(GeneratePosition(), game);
            map.player2 = new Player(GeneratePosition(), game);

            for (int i = 0; i < 2; i++)
            {
                map.tree1 = new Tree1(GeneratePosition());
                map.currentObstacleList.Add(map.tree1);
            }

            for (int i = 0; i < 2; i++)
            {
                map.tree2 = (new Tree2(GeneratePosition()));
                map.currentObstacleList.Add(map.tree2);
            }

            for (int i = 0; i < 20; i++)
            {
                map.dBlock = (new DestructableBlockSprite(game, 0, GeneratePosition()));
                map.destructibleBlockList.Add(map.dBlock);
                map.currentObstacleList.Add(map.dBlock);
            }
            for (int i = 0; i < 40; i++)
            {
                map.iBlock = new IndestructableBlockSprite(GeneratePosition(), 0);
                map.currentObstacleList.Add(map.iBlock);
                map.indestructibleBlockList.Add(map.iBlock);
            }
            for (int i = 0; i < 1; i++)
            {
                map.snake = new Snake(GeneratePosition(), game);
                map.snakeList.Add(map.snake);
                map.currentEnemyList.Add(map.snake);
            }
            for (int i = 0; i < 2; i++)
            {
                map.portalA = new Portal(GeneratePosition(), game);
                map.portalList.Add(map.portalA);
            }
            for (int i = 0; i < 1; i++)
            {
                map.verticalBat = new Bat(GeneratePosition(), game);
                map.batList.Add(map.verticalBat);
                map.currentEnemyList.Add(map.verticalBat);
            }
            for (int i = 0; i < 2; i++)
            {
                map.yeti = new Yeti(GeneratePosition(), game);
                map.yetiList.Add(map.yeti);
                map.currentEnemyList.Add(map.yeti);
            }
            for (int i = 0; i < 1; i++)
            {
                map.alien = new Alien(GeneratePosition(), game);
                map.currentEnemyList.Add(map.alien);
            }
            for (int i = 0; i < 2; i++)
            {
                map.trap = new Trap(GeneratePosition(), game);
                map.trapList.Add(map.trap);
            }
            /*
            for (int i = 0; i < 0; i++)
            {
                map.minecart = new Minecart(new Vector2(pos[0], pos[1]), game);
                map.minecartList.Add(map.minecart);
            }
            for (int i = 0; i < 0; i++)
            {
                map.coin = new Coin(new Vector2(pos[0], pos[1]), game);
                map.coinList.Add(map.coin);
                map.coinPosList.Add(new Vector2(pos[0], pos[1]));
            }
            
            foreach (List<int> pos in m2.aiplayers.Values)
            {
                map.aiplayer = new AIPlayer(new Vector2(pos[0], pos[1]), game);
                map.aiplayerList.Add(map.aiplayer);
                map.currentEnemyList.Add(map.aiplayer);
            }
            */
        }
    }
}
