using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
    class SpriteConstants
    {
        // player sprites
        public static List<Rectangle> BOMBER_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 31, 31),new Rectangle(62, 0, 31, 31), new Rectangle(155, 0, 31, 31)
        };
        public static List<Rectangle> BOMBER_EAST = new List<Rectangle>
        {
           new Rectangle(0, 31, 31, 31),new Rectangle(62, 31, 31, 31),new Rectangle(155, 31, 31, 31)
        };
        public static List<Rectangle> BOMBER_SOUTH = new List<Rectangle>
        {
           new Rectangle(0, 62, 31, 31),new Rectangle(62, 62, 31, 31),new Rectangle(155, 62, 31, 31)
        };
        public static List<Rectangle> BOMBER_WEST = new List<Rectangle>
        {
           new Rectangle(0, 93, 31, 31),new Rectangle(62, 93, 31, 31),new Rectangle(155, 93, 31, 31)
        };

        public static List<Rectangle> KNIGHT_NORTH = new List<Rectangle>
        {
           new Rectangle(0, 0, 190, 190),new Rectangle(160, 0, 190, 190),new Rectangle(380, 0, 190, 190)
        };
        public static List<Rectangle> KNIGHT_SOUTH = new List<Rectangle>
        {
           new Rectangle(575, 0, 190, 190),new Rectangle(0, 190, 190, 190),new Rectangle(190, 190, 190, 190)
        };
        public static List<Rectangle> KNIGHT_WEST = new List<Rectangle>
        {
          new Rectangle(380, 190, 190, 190),new Rectangle(560, 190, 190, 190),new Rectangle(0, 380, 160, 190)
        };
        public static List<Rectangle> KNIGHT_EAST = new List<Rectangle>
        {
          new Rectangle(160, 380, 180, 190),new Rectangle(345, 380, 190, 190),new Rectangle(540, 380, 190, 190)
        };
        public static List<Rectangle> GOBLIN_SOUTH = new List<Rectangle>
        {
          new Rectangle(48, 0, 48, 48),new Rectangle(0, 0, 48, 48), new Rectangle(96, 0, 48, 48)
        };
        public static List<Rectangle> GOBLIN_WEST = new List<Rectangle>
        {
          new Rectangle(48, 48, 48, 48),new Rectangle(0, 48, 48, 48),new Rectangle(96, 48, 48, 48)
        };
        public static List<Rectangle> GOBLIN_EAST = new List<Rectangle>
        {
          new Rectangle(48, 96, 48, 48),new Rectangle(0, 96, 48, 48),new Rectangle(96, 96, 48, 48)
        };
        public static List<Rectangle> GOBLIN_NORTH = new List<Rectangle>
        {
          new Rectangle(48,1440, 48, 48),new Rectangle(0, 144, 48, 48),new Rectangle(96, 144, 48, 48)
        };
        public static List<Rectangle> GHOST_NORTH = new List<Rectangle> { new Rectangle(0, 172, 172, 172) };
        public static List<Rectangle> GHOST_SOUTH = new List<Rectangle> { new Rectangle(172, 0, 172, 172)    };
        public static List<Rectangle> GHOST_EAST = new List<Rectangle> { new Rectangle(0, 0, 172, 172)};
        public static List<Rectangle> GHOST_WEST = new List<Rectangle> { new Rectangle(172, 172, 172, 172) };


    }
}
