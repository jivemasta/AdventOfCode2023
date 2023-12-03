using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Utils
    {
        public static List<List<char>> FileTo2d(string filename)
        {
            return File.ReadAllLines(filename).Select(line => line.ToList()).ToList();
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Tries to parse a string to an int or throws an exception
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ParseIntOrThrow(this string str)
        {
            if(int.TryParse(str, out int result)) return result;

            throw new Exception($"Unable to parse {str} to int");
        }
    }
}
