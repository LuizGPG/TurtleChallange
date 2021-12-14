using System.Collections.Generic;

namespace TurtleChallange.Entities
{
    public class Table
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public List<Position> Positions { get; set; }
        public List<Position> MinesPositions { get; set; }
        public Position FinishPosition { get; set; }

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
