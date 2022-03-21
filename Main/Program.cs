using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MartianRobots;
using MartianRobots.Components;
using MartianRobots.Systems;

namespace Main
{
    public class Program
    {
        public static void Main()
        {
            // Parse Planet data
            var planetCoords = Console.ReadLine()
                .Split()
                .Select((x) => int.Parse(x))
                .ToArray();

            // Create System
            var system = new MarsSystem();

            // Add Planet Component
            system.Planet.Replace(new PlanetComponent(planetCoords[0]+1, planetCoords[1]+1));

            while (true)
            {
                // Parse Robot data
                var positionLine = Console.ReadLine();
                if (positionLine == null || positionLine.Length == 0)
                    break;
                var positionParts = positionLine.Split();
                var coordinates = positionParts.Take(2).Select(x => int.Parse(x)).ToArray();
                var orientation = (Orientation)(positionParts.Skip(2).First()[0]);

                // Add Robot Component
                system.Robot.Replace(new RobotComponent
                {
                    X = coordinates[0],
                    Y = coordinates[1],
                    Orientation = orientation
                });

                // Parse commands
                var commands = Console.ReadLine().Select(c => (Command)c);

                // Add Command Components
                system.Commands.Replace(commands.Select(c => new CommandComponent { Command = c }));

                // Run System
                system.Run();

                // Get resulting Robot component
                var robotComponent = system.Robot.Get<RobotComponent>();

                // Print Robot status
                var suffix = robotComponent.Lost ? " LOST" : "";
                Console.WriteLine($"{robotComponent.X} {robotComponent.Y} {(char)robotComponent.Orientation}{suffix}");
            }
        }
    }
}
