using System;
namespace MartianRobots.Components
{
    public class PlanetComponent : IComponent
    {
        public int LengthX { get; set; }

        public int LengthY { get; set; }

        public bool[,] ScentMap { get; set; }

        #pragma warning disable CS8618
        public PlanetComponent() { }
        #pragma warning restore CS8618

        public PlanetComponent(int lengthX, int lengthY)
        {
            LengthX = lengthX;
            LengthY = lengthY;
            ScentMap = new bool[lengthX, lengthY];
        }
    }
}

