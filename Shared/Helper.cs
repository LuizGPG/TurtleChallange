using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallange.Shared
{
    public static class Helper
    {

        public static string[] ReadFile(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception)
            {
                Console.WriteLine(Messages.ErroToReadFile);
                Console.WriteLine(Messages.LineWrap);
                throw;
            }
        }
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
            Console.WriteLine(Messages.WrongPosition);
            Console.WriteLine(Messages.SampleOfPosition);
            Console.WriteLine(Messages.LineWrap);
        }
    }
}
