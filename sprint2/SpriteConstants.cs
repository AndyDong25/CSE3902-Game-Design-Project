using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Sprint2
{
    class SpriteConstants
    {
        // player sprites
        public static Rectangle BOMBER_IDLE_NORTH = new Rectangle(0, 0, 31, 31);
        public static Rectangle BOMBER_STEP_NORTH1 = new Rectangle(62, 0, 31, 31);
        public static Rectangle BOMBER_STEP_NORTH2 = new Rectangle(155, 0, 31, 31);
        public static Rectangle BOMBER_IDLE_EAST = new Rectangle(0, 31, 31, 31);
        public static Rectangle BOMBER_STEP_EAST1 = new Rectangle(62, 31, 31, 31);
        public static Rectangle BOMBER_STEP_EAST2 = new Rectangle(155, 31, 31, 31);
        public static Rectangle BOMBER_IDLE_SOUTH = new Rectangle(0, 62, 31, 31);
        public static Rectangle BOMBER_STEP_SOUTH1 = new Rectangle(62, 62, 31, 31);
        public static Rectangle BOMBER_STEP_SOUTH2 = new Rectangle(155, 62, 31, 31);
        public static Rectangle BOMBER_IDLE_WEST = new Rectangle(0, 93, 31, 31);
        public static Rectangle BOMBER_STEP_WEST1 = new Rectangle(62, 93, 31, 31);
        public static Rectangle BOMBER_STEP_WEST2 = new Rectangle(155, 93, 31, 31);

        public static Rectangle KNIGHT_IDLE_NORTH = new Rectangle(0, 0, 190, 190);
        public static Rectangle KNIGHT_STEP_NORTH1 = new Rectangle(160, 0, 190, 190);
        public static Rectangle KNIGHT_STEP_NORTH2 = new Rectangle(380, 0, 190, 190);
        public static Rectangle KNIGHT_IDLE_SOUTH = new Rectangle(575, 0, 190, 190);
        public static Rectangle KNIGHT_STEP_SOUTH1 = new Rectangle(0, 190, 190, 190);
        public static Rectangle KNIGHT_STEP_SOUTH2 = new Rectangle(190, 190, 190, 190);
        public static Rectangle KNIGHT_IDLE_WEST = new Rectangle(380, 190, 190, 190);
        public static Rectangle KNIGHT_STEP_WEST1 = new Rectangle(560, 190, 190, 190);
        public static Rectangle KNIGHT_STEP_WEST2 = new Rectangle(0, 380, 160, 190);
        public static Rectangle KNIGHT_IDLE_EAST = new Rectangle(160, 380, 180, 190);
        public static Rectangle KNIGHT_STEP_EAST1 = new Rectangle(345, 380, 190, 190);
        public static Rectangle KNIGHT_STEP_EAST2 = new Rectangle(540, 380, 190, 190);

        public static Rectangle GOBLIN_IDLE_SOUTH = new Rectangle(48, 0, 48, 48);
        public static Rectangle GOBLIN_SOUTH_STEP1 = new Rectangle(0, 0, 48, 48);
        public static Rectangle GOBLIN_SOUTH_STEP2 = new Rectangle(96, 0, 48, 48);
        public static Rectangle GOBLIN_IDLE_WEST = new Rectangle(48, 48, 48, 48);
        public static Rectangle GOBLIN_WEST_STEP1 = new Rectangle(0, 48, 48, 48);
        public static Rectangle GOBLIN_WEST_STEP2 = new Rectangle(96, 48, 48, 48);
        public static Rectangle GOBLIN_IDLE_EAST = new Rectangle(48, 96, 48, 48);
        public static Rectangle GOBLIN_EAST_STEP1 = new Rectangle(0, 96, 48, 48);
        public static Rectangle GOBLIN_EAST_STEP2 = new Rectangle(96, 96, 48, 48);
        public static Rectangle GOBLIN_IDLE_NORTH = new Rectangle(48,1440, 48, 48);
        public static Rectangle GOBLIN_NORTH_STEP1 = new Rectangle(0, 144, 48, 48);
        public static Rectangle GOBLIN_NORTH_STEP2 = new Rectangle(96, 144, 48, 48);

        public static Rectangle GHOST_SOUTH = new Rectangle(0, 172, 172, 172);
        public static Rectangle GHOST_NORTH = new Rectangle(172, 0, 172, 172);
        public static Rectangle GHOST_EAST = new Rectangle(0, 0, 172, 172);
        public static Rectangle GHOST_WEST = new Rectangle(172, 172, 172, 172);

    }
}
