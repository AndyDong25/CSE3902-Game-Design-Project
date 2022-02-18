using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace CSE3902_Sprint2.Sprites
{
    public class Map1
    {   
        private Dictionary<Vector2, ISprite> Items { get; set; }
        private Vector2 Position { get; set; }
        public Game1 game { get; set; }
        public Map1(Dictionary<Vector2, ISprite> Items, Game1 game)
        {
            this.game = game;
            this.Items = Items;
            
            
        }
        public void Draw()
        {
            foreach (var item in Items)
            {
        
                Position = item.Key;
                item.Value.Draw(game.spriteBatch, Position);
            }
        }
    }
}
