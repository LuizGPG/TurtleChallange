using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallange.Entities;
using static TurtleChallange.Entities.EnumEntities;

namespace TurtleChallange.Shared
{
    public static class Validations
    {
        public static bool ValidIfIsAMine(Turtle turtle, Table table)
        {
            var hitAMine = false;
            var turtlePosition = turtle.ActualPosition;
            foreach (var minePosition in table.MinesPositions)
            {
                if (!hitAMine)
                    hitAMine = turtlePosition.X == minePosition.X && turtlePosition.Y == minePosition.Y;
            }

            return hitAMine;
        }

        public static bool ValidIfIsFinished(Turtle turtle, Table table)
        {
            var turtlePosition = turtle.ActualPosition;
            var finalPosition = table.FinishPosition;

            return turtlePosition.X == finalPosition.X && turtlePosition.Y == finalPosition.Y;
        }
        public static bool ValidNextPosition(Turtle turtle, Table table)
        {
            var position = new Position(turtle.ActualPosition.X, turtle.ActualPosition.Y);

            position = Direction.NextPosition(turtle.ActualDirection, position);

            var xValidPositions = table.Positions.Select(d => d.X).Distinct();
            var yValidPositions = table.Positions.Select(d => d.Y).Distinct();

            return xValidPositions.Contains(position.X) && yValidPositions.Contains(position.Y);
        }
    }
}
