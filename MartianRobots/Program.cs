using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots
{
    public class Program
    {
        public static void Main()
        {
            var planetCoords = Console.ReadLine()
                .Split()
                .Select((x) => int.Parse(x))
                .ToArray();

            int maxX = planetCoords[0];
            int maxY = planetCoords[1];
            var planetState = new PlanetState(maxX + 1, maxY + 1);

            while (true)
            {
                // parse robot position & orientation
                var positionLine = Console.ReadLine();
                if (positionLine == null || positionLine.Length == 0)
                    break;
                var positionParts = positionLine.Split();
                var coordinates = positionParts.Take(2).Select(x => int.Parse(x)).ToArray();
                var orientation = (Orientation)(positionParts.Skip(2).First()[0]);
                var robotState = new RobotState
                {
                    X = coordinates[0],
                    Y = coordinates[1],
                    Orientation = orientation
                };

                // parse commands
                var commands = Console.ReadLine().Select(c => (Command)c);

                // exec commands
                var ok = PlanetBehavior.ExecCommands(planetState, robotState, commands);

                var suffix = ok ? "" : " LOST";
                Console.WriteLine($"{robotState.X} {robotState.Y} {(char)robotState.Orientation}{suffix}");
            }
        }
    }
}
