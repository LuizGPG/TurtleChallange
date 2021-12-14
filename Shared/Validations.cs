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

        internal static bool ValidateIfChallengeWasConfiguredCorrectly(Table table, Turtle turtle)
        {

            var canRunChallage = ValidIfAllInformationsNecessaryIsFilled(table, turtle);
            canRunChallage = canRunChallage && ValidateIfTurtleAreInTheSamePositionThatAMine(table, turtle);

            if (!canRunChallage)
            {
                Console.WriteLine("Can't not inicialize the challange!");
                Console.WriteLine("------------------------------------------------");
            }
            else
            {
                ValidateIfHasMineOutSideTable(table);
            }

            return canRunChallage;
        }

        private static bool ValidIfAllInformationsNecessaryIsFilled(Table table, Turtle turtle)
        {
            var allInformationsAreFilled = table.SizeX != default && table.SizeY != default;
            allInformationsAreFilled = allInformationsAreFilled && table.FinishPosition != default;
            allInformationsAreFilled = allInformationsAreFilled && table.Positions != default && table.Positions.Any();
            allInformationsAreFilled = allInformationsAreFilled && turtle.StartPosition != default && turtle.ActualDirection != default;

            return allInformationsAreFilled;
        }

        private static void ValidateIfHasMineOutSideTable(Table table)
        {
            var listOfXPositions = table.Positions.Select(d => d.X);
            var listOfYPositions = table.Positions.Select(d => d.Y);
            foreach (var mine in table.MinesPositions)
            {
                if (!listOfXPositions.Contains(mine.X) && !listOfYPositions.Contains(mine.Y))
                {
                    Console.WriteLine("The mine of position " + mine.X + "-" + mine.Y + " can't not fit in the table!");
                    Console.WriteLine("------------------------------------------------");
                }
            }
        }

        private static bool ValidateIfTurtleAreInTheSamePositionThatAMine(Table table, Turtle turtle)
        {
            var hasDifferentPosition = true;
            var turtlePositionStart = turtle.StartPosition;

            foreach (var mine in table.MinesPositions)
                hasDifferentPosition = hasDifferentPosition && !(turtlePositionStart.X == mine.X && turtlePositionStart.Y == mine.Y);


            if (!hasDifferentPosition)
            {
                Console.WriteLine("Can't not inicialize the challange because your turtle are in the same position that a bomb!");
                Console.WriteLine("------------------------------------------------");
            }

            return hasDifferentPosition;
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
