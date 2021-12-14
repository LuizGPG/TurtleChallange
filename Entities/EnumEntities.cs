using System;

namespace TurtleChallange.Entities
{
    public class EnumEntities
    {
        public enum ValidResultEnum
        {
            StillInDanger,
            Success,
            HitAMine,
        }

        public enum DirectionEnum
        {
            East,
            West,
            South,
            North
        }

        public static class Direction
        {
            public static DirectionEnum GetDirection(string[] turtlePositionStart)
            {
                try
                {
                    return (DirectionEnum)Enum.Parse(typeof(DirectionEnum), turtlePositionStart[2]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid direction to start the turtle!! We will configure with a North directition!");
                    Console.WriteLine("------------------------------------------------");
                    return DirectionEnum.North;   
                }
            }
            public static DirectionEnum NextDirection(DirectionEnum atualDirection)
            {
                switch (atualDirection)
                {
                    case DirectionEnum.East:
                        return DirectionEnum.South;
                    case DirectionEnum.West:
                        return DirectionEnum.North;
                    case DirectionEnum.South:
                        return DirectionEnum.West;
                    default:
                        return DirectionEnum.East;
                }
            }

            public static Position NextPosition(DirectionEnum atualDirection, Position actualPosition)
            {
                switch (atualDirection)
                {
                    case DirectionEnum.East:
                        actualPosition.X++;
                        break;
                    case DirectionEnum.West:
                        actualPosition.X--;
                        break;
                    case DirectionEnum.South:
                        actualPosition.Y++;
                        break;
                    default:
                        actualPosition.Y--;
                        break;
                }

                return actualPosition;
            }
        }
    }
}
