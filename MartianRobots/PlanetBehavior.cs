using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots
{
    public static class PlanetBehavior
    {
        public static bool ExecLeft(RobotState robotState)
        {
            // rotate Orientation counter-clockwise
            switch (robotState.Orientation)
            {
                case Orientation.North:
                    // 👆 => 👈
                    robotState.Orientation = Orientation.West;
                    break;
                case Orientation.West:
                    // 👈 => 👇
                    robotState.Orientation = Orientation.South;
                    break;
                case Orientation.South:
                    // 👇 => 👉
                    robotState.Orientation = Orientation.East;
                    break;
                case Orientation.East:
                    // 👉 => 👆
                    robotState.Orientation = Orientation.North;
                    break;
            }
            return true;
        }

        public static bool ExecRight(RobotState robotState)
        {
            // rotate Orientation clockwise
            switch (robotState.Orientation)
            {
                case Orientation.North:
                    // 👆 => 👉
                    robotState.Orientation = Orientation.East;
                    break;
                case Orientation.East:
                    // 👉 => 👇
                    robotState.Orientation = Orientation.South;
                    break;
                case Orientation.South:
                    // 👇 => 👈
                    robotState.Orientation = Orientation.West;
                    break;
                case Orientation.West:
                    // 👈 => 👆
                    robotState.Orientation = Orientation.North;
                    break;
            }
            return true;
        }

        public static bool ExecForward(RobotState robotState, PlanetState planetState)
        {
            sbyte dx = 0;
            sbyte dy = 0;
            switch (robotState.Orientation)
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
            var newX = robotState.X + dx;
            var newY = robotState.Y + dy;

            // check new position validity
            if (newX >= 0 && newX < planetState.LengthX && newY >= 0 && newY < planetState.LengthY)
            {
                // update position
                robotState.X = newX;
                robotState.Y = newY;
            }
            else if (!planetState.ScentMap[robotState.X, robotState.Y])
            {
                // die leaving a scent (if no scent, else ignore it)
                robotState.Lost = true;
                planetState.ScentMap[robotState.X, robotState.Y] = true;
            }
            return !robotState.Lost;
        }

        public static bool ExecCommand(PlanetState planetState, RobotState robotState, Command command)
        {
            switch (command)
            {
                case Command.Left:
                    return ExecLeft(robotState);
                case Command.Right:
                    return ExecRight(robotState);
                case Command.Forward:
                    return ExecForward(robotState, planetState);
                default:
                    return false;
            }
        }

        public static bool ExecCommands(PlanetState planetState, RobotState robotState, IEnumerable<Command> commands)
        {
            var total = commands.Count();

            var valid = commands
                .Select(command => ExecCommand(planetState, robotState, command))
                .TakeWhile(ok => ok)
                .Count();

            return valid == total;
        }
    }
}
