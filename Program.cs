using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallange.Entities;

namespace TurtleChallange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Table table;
            var turtle = ConfigureChallange(out table);
            //ConsoleInformations(table, turtle);

            /*Console.WriteLine("What moves do you like to do?");
            var filePath = Console.ReadLine();*/
            
            var filePath = @"C:\Users\Luiz\Desktop\Projetos\FilesTurtle\Moves.txt";

            var movesSequenceList = System.IO.File.ReadAllLines(filePath);
            var resultList = new List<ValidResult>();

            var startPosition = new Position(turtle.StartPosition.X, turtle.StartPosition.Y);
            var direction = turtle.ActualDirection;

            foreach (var movesSequence in movesSequenceList)
            {
                turtle = new Turtle();
                turtle.StartPosition = new Position(startPosition.X, startPosition.Y);
                turtle.ActualPosition = new Position(startPosition.X, startPosition.Y);
                turtle.ActualDirection = direction;

                var moves = movesSequence.Split(",");
                
                var hitAMine = false;
                var finishedGame = false;
                for (int i = 0; i < moves.Length && !hitAMine && !finishedGame; i++)
                {
                    var action = moves[i];
                    if (action == "m" && ValidNextPosition(turtle, table))
                    {
                        switch (turtle.ActualDirection)
                        {
                            case Direction.East:
                                turtle.ActualPosition.X++;
                                break;
                            case Direction.West:
                                turtle.ActualPosition.X--;
                                break;
                            case Direction.South:
                                turtle.ActualPosition.Y++;
                                break;
                            case Direction.North:
                                turtle.ActualPosition.Y--;
                                break;
                        }
                        
                        hitAMine = ValidIfIsAMine(turtle, table);
                        finishedGame = ValidIfIsFinished(turtle, table);
                    }
                    else
                    {
                        switch (turtle.ActualDirection)
                        {
                            case Direction.East:
                                turtle.ActualDirection = Direction.South;
                                break;
                            case Direction.West:
                                turtle.ActualDirection = Direction.North;
                                break;
                            case Direction.South:
                                turtle.ActualDirection = Direction.West;
                                break;
                            case Direction.North:
                                turtle.ActualDirection = Direction.East;
                                break;
                        }
                    }
                }

                if (hitAMine)
                    turtle.Result = ValidResult.HitAMine;

                if (finishedGame)
                    turtle.Result = ValidResult.Success;

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

        private static bool ValidIfIsAMine(Turtle turtle, Table table)
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

        private static bool ValidIfIsFinished(Turtle turtle, Table table)
        {
            var turtlePosition = turtle.ActualPosition;
            var finalPosition = table.FinishPosition;
            
            return turtlePosition.X == finalPosition.X && turtlePosition.Y == finalPosition.Y;
        }

        private static bool ValidNextPosition(Turtle turtle, Table table)
        {
            var position = new Position(turtle.ActualPosition.X, turtle.ActualPosition.Y);
            switch (turtle.ActualDirection)
            {
                case Direction.East:
                    position.X++;
                    break;
                case Direction.West:
                    position.X--;
                    break;
                case Direction.South:
                    position.Y++;
                    break;
                case Direction.North:
                    position.Y--;
                    break;
            }

            var xValidPositions = table.Positions.Select(d => d.X).Distinct();
            var yValidPositions = table.Positions.Select(d => d.Y).Distinct();
            
            return xValidPositions.Contains(position.X) && yValidPositions.Contains(position.Y);
        }

        private static Turtle ConfigureChallange(out Table table)
        {
            /*Console.WriteLine("What file should I read to configure the game?");
            var filePath = Console.ReadLine();*/
            var filePath = @"C:\Users\Luiz\Desktop\Projetos\FilesTurtle\MyPositions.txt";
            var configurationFile = System.IO.File.ReadAllLines(filePath);

            var turtle = new Turtle();
            table = new Table();
            for (int line = 0; line < configurationFile.Length; line++)
            {
                var item = configurationFile[line];
                if (item == string.Empty)
                    continue;

                if (item == "Table size")
                {
                    var tableSize = configurationFile[line + 1].Split("-");
                    table = Table.Create(int.Parse(tableSize[0]), int.Parse(tableSize[1]));
                    line++;
                    continue;
                }

                if (item == "Mines")
                {
                    table.MinesPositions = new List<Position>();
                    while (configurationFile[line + 1] != string.Empty)
                    {
                        var minePosition = configurationFile[line + 1].Split("-");
                        table.MinesPositions.Add(new Position(int.Parse(minePosition[0]), int.Parse(minePosition[1])));
                        line++;
                    }
                }

                if (item == "Turtle start")
                {
                    var turtlePositionStart = configurationFile[line + 1].Split("-");
                    var direction = (Direction)Enum.Parse(typeof(Direction), turtlePositionStart[2]);
                    turtle = new Turtle(int.Parse(turtlePositionStart[0]), int.Parse(turtlePositionStart[1]), direction);
                }

                if(item == "Finish")
                {
                    var finishPosition = configurationFile[line + 1].Split("-");
                    table.FinishPosition  = new Position(int.Parse(finishPosition[0]), int.Parse(finishPosition[1]));
                }

                line++;
            }
            
            return turtle;
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
