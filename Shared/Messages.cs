using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallange.Shared
{
    public static class Messages
    {
        // Error
        public const string LineWrap = "------------------------------------------------";
        public const string WrongPosition = "Ops! We got some wront position! Make sure that all positions that you sent are with this pattern:";
        public const string SampleOfPosition = "Ex: 1-2 (X-Y)";

        public const string ErroToReadFile = "Ops! Something wrong with your file, make sure that your file is there!";
        public const string BombAndTurtleSamePosition = "Can't not inicialize the challange because your turtle are in the same position that a bomb!";
        public const string MinePositionWrong = "The mine of position ";
        public const string CantFit = " can't not fit in the table!";
        public const string InvalidDirection = "Invalid direction to start the turtle!! We will configure with a North directition!";
        public const string CantInicialize = "Can't not inicialize the challange!";
        
        //Questions
        public const string MovesFileQuestion = "What moves do you like to do?";
        public const string ConfigureFileQuestion = "What file should I read to configure the game?";

        // Others
        public const string ResultFor = "Result for the turtle ";
        public const string Was = " was ";
        public const string FinishGame = "Finishing game!!";

        //Actions
        public const string Move = "m";
        public const string Rotate = "r";


    }
}
