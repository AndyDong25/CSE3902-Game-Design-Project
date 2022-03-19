using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CSE3902_CSE3902_Project
{
    class SpriteConstants
    {
        // player sprites
        public static List<Rectangle> BOMBER_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 32, 32),new Rectangle(64, 0, 32, 32), new Rectangle(160, 0, 32, 32)
        };
        public static List<Rectangle> BOMBER_EAST = new List<Rectangle>
        {
           new Rectangle(0, 32, 32, 32),new Rectangle(64, 32, 32, 32),new Rectangle(160, 32, 32, 32)
        };
        public static List<Rectangle> BOMBER_SOUTH = new List<Rectangle>
        {
           new Rectangle(0, 64, 32, 32),new Rectangle(64, 64, 32, 32),new Rectangle(160, 64, 32, 32)
        };
        public static List<Rectangle> BOMBER_WEST = new List<Rectangle>
        {
           new Rectangle(0, 96, 32, 32),new Rectangle(64, 96, 32, 32),new Rectangle(160, 96, 32, 32)
        };
        public static List<Rectangle> KNIGHT_NORTH = new List<Rectangle>
        {
           new Rectangle(280, 0, 70, 92),new Rectangle(350, 0, 70, 92),new Rectangle(420, 0, 70, 92)
        };
        public static List<Rectangle> KNIGHT_EAST = new List<Rectangle>
        {
           new Rectangle(280, 276, 70, 92),new Rectangle(350, 276, 70, 92),new Rectangle(420, 276, 70, 92)
        };
        public static List<Rectangle> KNIGHT_WEST = new List<Rectangle>
        {
           new Rectangle(0, 276, 70, 92),new Rectangle(70, 276, 70, 92),new Rectangle(140, 276, 70, 92)
        };
        public static List<Rectangle> KNIGHT_SOUTH = new List<Rectangle>
        {
           new Rectangle(280, 184, 70, 92),new Rectangle(350, 184, 70, 92),new Rectangle(420, 184, 70, 92)
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
          new Rectangle(48,144, 48, 48),new Rectangle(0, 144, 48, 48),new Rectangle(96, 144, 48, 48)
        };
        public static List<Rectangle> GHOST_SOUTH = new List<Rectangle> { new Rectangle(375, 175, 200, 185) };
        public static List<Rectangle> GHOST_NORTH = new List<Rectangle> { new Rectangle(175, 360, 200, 185) };
        public static List<Rectangle> GHOST_EAST = new List<Rectangle> { new Rectangle(375, 360, 200, 185)};
        public static List<Rectangle> GHOST_WEST = new List<Rectangle> { new Rectangle(175, 175, 200, 185) };

        // NPC sprites
        public static List<Rectangle> REDBOY_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 192, 64, 64), new Rectangle (64, 192, 64, 64), new Rectangle(192, 192, 64, 64)
        };
        public static List<Rectangle> REDBOY_SOUTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 64, 64), new Rectangle (64, 0, 64, 64), new Rectangle(192, 0, 64, 64)
        };
        public static List<Rectangle> REDBOY_WEST = new List<Rectangle>
        {
            new Rectangle(0, 64, 64, 64), new Rectangle (64, 64, 64, 64), new Rectangle(192, 64, 64, 64)
        };
        public static List<Rectangle> REDBOY_EAST = new List<Rectangle>
        {
            new Rectangle(0, 128, 64, 64), new Rectangle (64, 128, 64, 64), new Rectangle(192, 128, 64, 64)
        };

        public static List<Rectangle> WHITEGIRL_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 192, 64, 64), new Rectangle (64, 192, 64, 64), new Rectangle(192, 192, 64, 64)
        };
        public static List<Rectangle> WHITEGIRL_SOUTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 64, 64), new Rectangle (64, 0, 64, 64), new Rectangle(192, 0, 64, 64)
        };
        public static List<Rectangle> WHITEGIRL_WEST = new List<Rectangle>
        {
            new Rectangle(0, 64, 64, 64), new Rectangle (64, 64, 64, 64), new Rectangle(192, 64, 64, 64)
        };
        public static List<Rectangle> WHITEGIRL_EAST = new List<Rectangle>
        {
            new Rectangle(0, 128, 64, 64), new Rectangle (64, 128, 64, 64), new Rectangle(192, 128, 64, 64)
        };

        public static List<Rectangle> GREENBOY_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 192, 64, 64), new Rectangle (64, 192, 64, 64), new Rectangle(192, 192, 64, 64)
        };
        public static List<Rectangle> GREENBOY_SOUTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 64, 64), new Rectangle (64, 0, 64, 64), new Rectangle(192, 0, 64, 64)
        };
        public static List<Rectangle> GREENBOY_WEST = new List<Rectangle>
        {
            new Rectangle(0, 64, 64, 64), new Rectangle (64, 64, 64, 64), new Rectangle(192, 64, 64, 64)
        };
        public static List<Rectangle> GREENBOY_EAST = new List<Rectangle>
        {
            new Rectangle(0, 128, 64, 64), new Rectangle (64, 128, 64, 64), new Rectangle(192, 128, 64, 64)
        };

        public static List<Rectangle> BROWNBOY_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 192, 64, 64), new Rectangle (64, 192, 64, 64), new Rectangle(192, 192, 64, 64)
        };
        public static List<Rectangle> BROWNBOY_SOUTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 64, 64), new Rectangle (64, 0, 64, 64), new Rectangle(192, 0, 64, 64)
        };
        public static List<Rectangle> BROWNBOY_WEST = new List<Rectangle>
        {
            new Rectangle(0, 64, 64, 64), new Rectangle (64, 64, 64, 64), new Rectangle(192, 64, 64, 64)
        };
        public static List<Rectangle> BROWNBOY_EAST = new List<Rectangle>
        {
            new Rectangle(0, 128, 64, 64), new Rectangle (64, 128, 64, 64), new Rectangle(192, 128, 64, 64)
        };

        public static List<Rectangle> BAT_EAST = new List<Rectangle>
        {
            new Rectangle(31, 31, 32, 32), new Rectangle (63, 31, 32, 32), new Rectangle(95, 31, 32, 32)
        };

        public static List<Rectangle> BAT_WEST = new List<Rectangle>
        {
            new Rectangle(31, 95, 32, 32), new Rectangle (63, 95, 32, 32), new Rectangle(95, 95, 32, 32)
        };

        public static List<Rectangle> BAT_NORTH = new List<Rectangle>
        {
            new Rectangle(31, 63, 32, 32), new Rectangle (63, 63, 32, 32), new Rectangle(95, 63, 32, 32)
        };

        public static List<Rectangle> BAT_SOUTH = new List<Rectangle>
        {
            new Rectangle(31, 0, 32, 31), new Rectangle (63, 0, 32, 31), new Rectangle(95, 0, 32, 31)
        };

        public static List<Rectangle> SNAKE_EAST = new List<Rectangle>
        {
            new Rectangle(0, 124, 62, 63), new Rectangle (62, 124, 62, 63), new Rectangle(124, 124, 62, 63)
        };

        public static List<Rectangle> SNAKE_WEST = new List<Rectangle>
        {
            new Rectangle(0, 62, 62, 63), new Rectangle (62, 62, 62, 63), new Rectangle(124, 62, 62, 63)
        };

        public static List<Rectangle> SNAKE_SOUTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 62, 63), new Rectangle (62, 0, 62, 63), new Rectangle(124, 0, 62, 63)
        };

        public static List<Rectangle> SNAKE_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 189, 62, 63), new Rectangle (62, 189, 62, 63), new Rectangle(124, 189, 62, 63)
        };


        public static List<Rectangle> ALIEN_EAST = new List<Rectangle>
        {
            new Rectangle(0, 124, 62, 63), new Rectangle (62, 124, 62, 63), new Rectangle(124, 124, 62, 63)
        };

        public static List<Rectangle> ALIEN_WEST = new List<Rectangle>
        {
            new Rectangle(0, 62, 62, 63), new Rectangle (62, 62, 62, 63), new Rectangle(124, 62, 62, 63)
        };

        public static List<Rectangle> ALIEN_SOUTH = new List<Rectangle>
        {
            new Rectangle(0, 0, 62, 63), new Rectangle (62, 0, 62, 63), new Rectangle(124, 0, 62, 63)
        };

        public static List<Rectangle> ALIEN_NORTH = new List<Rectangle>
        {
            new Rectangle(0, 189, 62, 63), new Rectangle (62, 189, 62, 63), new Rectangle(124, 189, 62, 63)
        };
        /*
                public static List<Rectangle> YETI_EAST = new List<Rectangle>
                {
                    new Rectangle(74, 83, 81, 81), new Rectangle(155, 83, 81, 81), new Rectangle(236, 83, 81, 81), new Rectangle(317, 83, 81, 81), new Rectangle(398, 83, 81, 81),
                    new Rectangle(479, 83, 81, 81), new Rectangle(560, 83, 81, 81), new Rectangle(641, 83, 81, 81), new Rectangle(722, 83, 81, 81),
                };

                public static List<Rectangle> YETI_WEST = new List<Rectangle>
                {
                    new Rectangle(641, 83, 81, 81), new Rectangle(560, 83, 81, 81), new Rectangle(479, 83, 81, 81), new Rectangle(398, 83, 81, 81), new Rectangle(317, 83, 81, 81),
                     new Rectangle(236, 83, 81, 81), new Rectangle(155, 83, 81, 81), new Rectangle(74, 83, 81, 81), new Rectangle(0, 83, 81, 81),
                };*/


        public static List<Rectangle> YETI_EAST = new List<Rectangle>
        {
                    new Rectangle(641, 83, 81, 81), new Rectangle(560, 83, 81, 81), new Rectangle(479, 83, 81, 81), new Rectangle(398, 83, 81, 81), new Rectangle(317, 83, 81, 81),
                     new Rectangle(236, 83, 81, 81), new Rectangle(155, 83, 81, 81), new Rectangle(74, 83, 81, 81), new Rectangle(0, 83, 81, 81),
        };

        public static List<Rectangle> YETI_WEST = new List<Rectangle>
        {
            new Rectangle(74, 83, 81, 81), new Rectangle(155, 83, 81, 81), new Rectangle(236, 83, 81, 81), new Rectangle(317, 83, 81, 81), new Rectangle(398, 83, 81, 81),
            new Rectangle(479, 83, 81, 81), new Rectangle(560, 83, 81, 81), new Rectangle(641, 83, 81, 81), new Rectangle(722, 83, 81, 81),
        };


        public static Rectangle NINJA_STAR = new Rectangle(0, 0, 459, 459);
        //public static Rectangle EXPLOSION = new Rectangle(555, 124, 87, 87);
        public static Rectangle EXPLOSION = new Rectangle(561, 129, 75, 75);
        public static Rectangle TOMBSTONE = new Rectangle(0, 0, 233, 233);
        public static Rectangle STATIC_BOMB = new Rectangle(0, 0, 255, 255);

        // spawnable items
        public static Rectangle BOMB_ITEM = new Rectangle(0, 0, 363, 480);
        public static Rectangle GHOST_ITEM = new Rectangle(40, 0, 480, 498);
        public static Rectangle GOBLIN_ITEM = new Rectangle(88, 58, 403, 533);
        public static Rectangle KNIGHT_ITEM = new Rectangle(9, 10, 442, 510);
        public static Rectangle POTION_ITEM = new Rectangle(68, 35, 183, 277);
        public static Rectangle SHOE_ITEM = new Rectangle(47, 38, 389, 354);

        // decorations
        public static Rectangle TREE1 = new Rectangle(75, 40, 250, 260);
        public static Rectangle TREE2 = new Rectangle(120, 40, 550, 560);
        public static Rectangle CRATE_I_BLOCK = new Rectangle(0, 0, 250, 250);
        public static Rectangle CRATE_D_BLOCK = new Rectangle(0, 0, 340, 340);

        public static Rectangle ICE_D_BLOCK = new Rectangle(13, 18, 100, 100);
        public static Rectangle ICE_I_BLOCK = new Rectangle(0, 0, 160, 160);

        public static Rectangle CHEST_BLOCK = new Rectangle(0, 84, 254, 170);
        public static Rectangle MINERAL_BLOCK = new Rectangle(188, 69, 279, 260);

        public static Rectangle KELP_BLOCK = new Rectangle(232, 39, 200, 291);
        public static Rectangle WATER_BLOCK = new Rectangle(0, 0, 96, 96);

        public static Rectangle MASHROOM1 = new Rectangle(0, 0, 800, 800);

        public static List<Rectangle> PORTAL = new List<Rectangle>
        {
            new Rectangle(0, 38, 50, 120), new Rectangle(50, 38, 50, 120), new Rectangle(100, 38, 50, 120), new Rectangle(150, 38, 50, 120)
        };
    }
}
