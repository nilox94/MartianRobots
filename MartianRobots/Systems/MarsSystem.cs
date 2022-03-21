using System;
using System.Linq;
using System.Runtime.CompilerServices;
using MartianRobots.Components;

namespace MartianRobots.Systems
{
    public class MarsSystem : ISystem
    {
        public readonly Entity Planet = new();
        public readonly Entity Robot = new();
        public readonly Entity Commands = new();

        public void Run()
        {
            // Exec Commands until failure
            foreach(var command in Commands.GetAll<CommandComponent>())
            {
                var ok = ExecCommand(command.Command);
                if (!ok)
                {
                    break;
                }
            }
        }

        public bool ExecCommand(Command command)
        {
            switch (command)
            {
                case Command.Left:
                    ExecLeft();
                    break;
                case Command.Right:
                    ExecRight();
                    break;
                case Command.Forward:
                    ExecForward();
                    break;
                default:
                    throw new NotImplementedException($"Not implemented Command ${command}");
            }
            return !Robot.Get<RobotComponent>().Lost;
        }

        public void ExecLeft()
        {
            var robotComponent = Robot.Get<RobotComponent>();
            var orientation = robotComponent.Orientation;
            // rotate Orientation counter-clockwise
            switch (orientation)
            {
                case Orientation.North:
                    // 👆 => 👈
                    orientation = Orientation.West;
                    break;
                case Orientation.West:
                    // 👈 => 👇
                    orientation = Orientation.South;
                    break;
                case Orientation.South:
                    // 👇 => 👉
                    orientation = Orientation.East;
                    break;
                case Orientation.East:
                    // 👉 => 👆
                    orientation = Orientation.North;
                    break;
                default:
                    throw new NotImplementedException($"Not implemented Orientation ${orientation}");
            }
            Robot.Replace(new RobotComponent
            {
                X = robotComponent.X,
                Y = robotComponent.Y,
                Orientation = orientation,
                Lost = false,
            });
        }

        public void ExecRight()
        {
            var robotComponent = Robot.Get<RobotComponent>();
            var orientation = robotComponent.Orientation;
            // rotate Orientation clockwise
            switch (orientation)
            {
                case Orientation.North:
                    // 👆 => 👉
                    orientation = Orientation.East;
                    break;
                case Orientation.East:
                    // 👉 => 👇
                    orientation = Orientation.South;
                    break;
                case Orientation.South:
                    // 👇 => 👈
                    orientation = Orientation.West;
                    break;
                case Orientation.West:
                    // 👈 => 👆
                    orientation = Orientation.North;
                    break;
                default:
                    throw new NotImplementedException($"Not implemented Orientation ${orientation}");
            }
            Robot.Replace(new RobotComponent
            {
                X = robotComponent.X,
                Y = robotComponent.Y,
                Orientation = orientation,
                Lost = false,
            });
        }

        public void ExecForward()
        {
            var robotComponent = Robot.Get<RobotComponent>();
            var planetComponent = Planet.Get<PlanetComponent>();
            sbyte dx = 0;
            sbyte dy = 0;
            switch (robotComponent.Orientation)
            {
                case Orientation.North:
                    // move 👆
                    dy = 1;
                    break;
                case Orientation.East:
                    // move 👉
                    dx = 1;
                    break;
                case Orientation.South:
                    // move 👇
                    dy = -1;
                    break;
                case Orientation.West:
                    // move 👈
                    dx = -1;
                    break;
            }
            var lost = false;
            var x = robotComponent.X;
            var y = robotComponent.Y;
            var newX = x + dx;
            var newY = y + dy;

            // check new position validity
            if (newX >= 0 && newX < planetComponent.LengthX && newY >= 0 && newY < planetComponent.LengthY)
            {
                // update position
                x = newX;
                y = newY;
            }
            else if (!planetComponent.ScentMap[x, y])
            {
                // die leaving a scent if no scent (else ignore it)
                planetComponent.ScentMap[x, y] = true;
                Planet.Replace(new PlanetComponent
                {
                    LengthX = planetComponent.LengthX,
                    LengthY = planetComponent.LengthY,
                    ScentMap = planetComponent.ScentMap,
                });
                lost = true;
            }
            Robot.Replace(new RobotComponent
            {
                X = x,
                Y = y,
                Orientation = robotComponent.Orientation,
                Lost = lost,
            });
        }
    }
}

