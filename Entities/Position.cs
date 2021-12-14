using System.Collections.Generic;

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
