using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallange.Shared
{
    public static class Helper
    {
        public static string[] GetValueNextLine(string[] configurationFile, int line)
        {
            try
            {
                return configurationFile[line + 1].Split("-");

            }
            catch (Exception)
            {
                ErrorWithValues();
                throw;
            }
        }

        public static int[] GetValueNextLineToInt(string[] configurationFile, int line)
        {
            try
            {
                var values = configurationFile[line + 1].Split("-");
                return new int[] { int.Parse(values[0]), int.Parse(values[1]) };
            }
            catch (Exception)
            {
                ErrorWithValues();
                throw;
            }
        }
        public static int[] GetValueNextLineToInt(string[] configurationFile)
        {
            try
            {
                return new int[] { int.Parse(configurationFile[0]), int.Parse(configurationFile[1]) };
            }
            catch (Exception)
            {
                ErrorWithValues();
                throw;
            }
        }

        private static void ErrorWithValues()
        {
            Console.WriteLine("Ops! We got some wront position! Make sure that all positions that you sent are with this pattern:");
            Console.WriteLine("Ex: 1-2 (X-Y)");
            Console.WriteLine("------------------------------------------------");
        }
    }
}
