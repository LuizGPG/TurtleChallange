using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallange.Entities
{
    public class Turtle
    {
        public Position StartPosition { get; set; }
        public Position ActualPosition { get; set; }
        public Direction ActualDirection { get; set; }
        public ValidResult Result { get; set; }

        public Turtle()
        {

        }

        public Turtle(int x, int y, Direction direction)
        {
            StartPosition = new Position(x, y);
            ActualPosition = new Position(x, y);
            ActualDirection = direction;
            Result = ValidResult.StillInDanger;
        }
        
    }
    public enum ValidResult
    {
        StillInDanger,
        Success,
        HitAMine,
    }

    public enum Direction
    {
        East,
        West,
        South,
        North
    }
}
