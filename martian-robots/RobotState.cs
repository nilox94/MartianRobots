﻿using System;
namespace martian_robots
{
    public class RobotState
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Orientation Orientation { get; set; }

        public bool Lost { get; set; } = false;
    }
}
