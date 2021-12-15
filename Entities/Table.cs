using System;
using System.Collections.Generic;
using System.IO;
using TurtleChallange.Shared;
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
            Console.WriteLine(Messages.ConfigureFileQuestion);
            var filePath = Console.ReadLine();
            var configurationFile = Helper.ReadFile(filePath);
            Console.WriteLine(Messages.LineWrap);

            var turtle = new Turtle();
            table = new Table();
            for (int line = 0; line < configurationFile.Length; line++)
            {
                var item = configurationFile[line];
                if (item == string.Empty)
                    continue;

                if (item == TableSize)
                {
                    var tableSize = Helper.GetValueNextLineToInt(configurationFile, line);
                    table = Create(tableSize[0], tableSize[1]);
                    line++;
                    continue;
                }

                if (item == Mines)
                {
                    table.MinesPositions = new List<Position>();
                    while (configurationFile[line + 1] != string.Empty)
                    {
                        table.MinesPositions.Add(Position.GetPositionFromString(Helper.GetValueNextLine(configurationFile, line)));
                        line++;
                    }
                }

                if (item == TurtleStart)
                {
                    var turtlePositionStart = Helper.GetValueNextLine(configurationFile, line);
                    var direction = Direction.GetDirection(turtlePositionStart);
                    turtle = new Turtle(Position.GetPositionFromString(turtlePositionStart), direction);
                }

                if (item == Finish)
                    table.FinishPosition = Position.GetPositionFromString(Helper.GetValueNextLine(configurationFile, line));

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
