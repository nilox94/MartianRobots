using System;
namespace martian_robots
{
    public class PlanetState
    {
        public int LengthX { get; set; }

        public int LengthY { get; set; }

        public bool[,] ScentMap { get; set; }

        public PlanetState(int lengthX, int lengthY)
        {
            LengthX = lengthX;
            LengthY = lengthY;
            ScentMap = new bool[lengthX, lengthY];
        }
    }
}
