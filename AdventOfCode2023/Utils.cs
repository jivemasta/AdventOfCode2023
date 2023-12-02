using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Utils
    {
        public static IEnumerable<string> LinesFromFile(string filename)
        {
            var reader = new StreamReader(filename);
            while (reader.ReadLine() is string line)
            {
                yield return line;
            }
        }
    }
}
