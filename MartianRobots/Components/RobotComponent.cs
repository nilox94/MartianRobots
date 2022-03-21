using System;
namespace MartianRobots.Components
{
    public class RobotComponent : IComponent
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Orientation Orientation { get; set; }

        public bool Lost { get; set; } = false;
    }
}

