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

        public Turtle(Position position, DirectionEnum direction)
        {
            StartPosition = position;
            ActualPosition = position;
            ActualDirection = direction;
            Result = ValidResultEnum.StillInDanger;
        }

    }
    
}
