using System;
using System.Collections.Generic;
using static TurtleChallange.Entities.EnumEntities;

namespace TurtleChallange.Entities
{
    public class Table
    {
        private const string Mines = "Mines";
        private const string TableSize = "Table size";
        private const string TurtleStart = "Turtle start";
        private const string Finish = "Finish";
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public List<Position> Positions { get; set; }
        public List<Position> MinesPositions { get; set; }
        public Position FinishPosition { get; set; }

        public static Turtle ConfigureChallange(out Table table)
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

                if (item == TableSize)
                {
                    var tableSize = configurationFile[line + 1].Split("-");
                    table = Create(int.Parse(tableSize[0]), int.Parse(tableSize[1]));
                    line++;
                    continue;
                }

                if (item == Mines)
                {
                    table.MinesPositions = new List<Position>();
                    while (configurationFile[line + 1] != string.Empty)
                    {
                        var minePosition = configurationFile[line + 1].Split("-");
                        table.MinesPositions.Add(Position.GetPositionFromString(minePosition));
                        line++;
                    }
                }

                if (item == TurtleStart)
                {
                    var turtlePositionStart = configurationFile[line + 1].Split("-");
                    var direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), turtlePositionStart[2]);
                    turtle = new Turtle(Position.GetPositionFromString(turtlePositionStart), direction);
                }

                if (item == Finish)
                {
                    var finishPosition = configurationFile[line + 1].Split("-");
                    table.FinishPosition = new Position(int.Parse(finishPosition[0]), int.Parse(finishPosition[1]));
                }

                line++;
            }

            return turtle;
        }

        public static Table Create(int sizeX, int sizeY)
        {
            return new Table
            {
                SizeX = sizeX,
                SizeY = sizeY,
                Positions = Position.TablePositions(sizeX, sizeY)
            };
        }
    }
}
