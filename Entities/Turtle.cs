using static TurtleChallange.Entities.EnumEntities;

namespace TurtleChallange.Entities
{
    public class Turtle
    {
        public Position StartPosition { get; set; }
        public Position ActualPosition { get; set; }
        public DirectionEnum ActualDirection { get; set; }
        public ValidResultEnum Result { get; set; }

        public Turtle()
        {

        }

        public Turtle(int x, int y, DirectionEnum direction)
        {
            StartPosition = new Position(x, y);
            ActualPosition = new Position(x, y);
            ActualDirection = direction;
            Result = ValidResultEnum.StillInDanger;
        }

    }
    
}
