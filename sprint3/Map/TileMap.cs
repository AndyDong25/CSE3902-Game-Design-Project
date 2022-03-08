using CSE3902_CSE3902_Project;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace sprint3.Map
{
    public class TileMap 
    {
        private Game1 game;
        private int width;
        private int height;
        private int tileSize;
        public List<Vector2> tileMap;
        public TileMap(Game1 game)
        {
            this.game = game;
            tileSize = 40;
            width = (int)game.screenSize.X;
            height = (int)game.screenSize.Y;
            tileMap = new List<Vector2>();
        }

        public Vector2 RoundToNearestTile(Vector2 pos)
        {
            Vector2 roundedPos = new Vector2();
            int x = (int)pos.X;
            int y = (int)pos.Y;
            roundedPos.X = (int)Math.Round(x / (double) tileSize, MidpointRounding.AwayFromZero) * tileSize;
            roundedPos.Y = (int)Math.Round(y / (double)tileSize, MidpointRounding.AwayFromZero) * tileSize;
            return roundedPos;
        }

        public bool AddBombToTileMap(Vector2 pos)
        {
            if (tileMap.Contains(pos))
            {
                return false;
            }
            else
            {
                tileMap.Add(pos);
                return true;
            }
        }
            
    }
}
