using System.Collections.Generic;
using TurtleChallange.Shared;

namespace TurtleChallange.Entities
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position Clone()
        {
            return (Position)MemberwiseClone();
        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position GetPositionFromString(string[] position)
        {
            var values = Helper.GetValueNextLineToInt(position);
            return new Position(values[0], values[1]);
        }

        public static List<Position> TablePositions(int sizeX, int sizeY)
        {
            var positions = new List<Position>();
            for (int x = 0; x < sizeX; x++)
                for (int y = sizeY-1; y >= 0; y--)
                    positions.Add(new Position(x, y));

            return positions;
        }
    }
}
