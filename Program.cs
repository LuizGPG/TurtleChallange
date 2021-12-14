using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallange.Entities;
using TurtleChallange.Shared;
using static TurtleChallange.Entities.EnumEntities;

namespace TurtleChallange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Table table;
            var turtle = Table.ConfigureChallange(out table);

            var canRunTheChallenge = Validations.ValidateIfChallengeWasConfiguredCorrectly(table, turtle);

            if (!canRunTheChallenge)
                return;

            //ConsoleInformations(table, turtle);

            Console.WriteLine("What moves do you like to do?");
            var filePath = Console.ReadLine();

            var movesSequenceList = System.IO.File.ReadAllLines(filePath);
            var resultList = new List<ValidResultEnum>();

            var startPosition = new Position(turtle.StartPosition.X, turtle.StartPosition.Y);
            var direction = turtle.ActualDirection;

            foreach (var movesSequence in movesSequenceList)
            {
                turtle = new Turtle(new Position(startPosition.X, startPosition.Y), direction);

                var moves = movesSequence.Split(",");
                var hitAMine = false;
                var finishedGame = false;
                for (int i = 0; i < moves.Length && !hitAMine && !finishedGame; i++)
                {
                    var action = moves[i];
                    if (action == "m")
                    {
                        var canMoveForNextPosition = Validations.ValidNextPosition(turtle, table);
                        if (!canMoveForNextPosition)
                            continue;

                        turtle.ActualPosition = Direction.NextPosition(turtle.ActualDirection, turtle.ActualPosition);
                        
                        hitAMine = Validations.ValidIfIsAMine(turtle, table);
                        finishedGame = Validations.ValidIfIsFinished(turtle, table);
                    }
                    else
                        turtle.ActualDirection = Direction.NextDirection(turtle.ActualDirection);
                }

                if (hitAMine)
                    turtle.Result = ValidResultEnum.HitAMine;

                if (finishedGame)
                    turtle.Result = ValidResultEnum.Success;

                resultList.Add(turtle.Result);
            }

            var turtleNumber = 1;
            foreach (var item in resultList)
            {
                Console.WriteLine("Resultado of the turtle "+ turtleNumber + " was " + item.ToString());
                turtleNumber++;
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Finishing game!!");

        }
        private static void ConsoleInformations(Table table, Turtle turtle)
        {
            Console.WriteLine("----------------------------------------------");
            foreach (var position in table.Positions)
            {
                Console.WriteLine("Positions");
                Console.WriteLine("X:" + position.X + " Y: " + position.Y);
            }

            Console.WriteLine("----------------------------------------------");
            foreach (var position in table.MinesPositions)
            {
                Console.WriteLine("Mines Positions");
                Console.WriteLine("X:" + position.X + " Y: " + position.Y);
            }
            Console.WriteLine("----------------------------------------------");


            Console.WriteLine("Turtle start position: " + turtle.StartPosition.X + "-" + turtle.StartPosition.Y);
            Console.WriteLine("Turtle actual position: " + turtle.ActualPosition.X + "-" + turtle.ActualPosition.Y);
            Console.WriteLine("Turtle direction: " + turtle.ActualDirection.ToString());

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Final Position: " + table.FinishPosition.X + "-" + table.FinishPosition.Y);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
