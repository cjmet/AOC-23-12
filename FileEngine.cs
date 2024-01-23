using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AOC_23_12.Extensions;

namespace AOC_23_12
{
    public class FileEngine
    {

        public FileEngine(string filename, Part part)
        {
            long sum = 0;
            int linenum = 0;
            Springs.Reset();

            filename = FindFileInVisualStudio(filename);
            Debug.WriteLine($"Attempting to read {filename}");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (string line in File.ReadLines(filename))
            {
                linenum++;
                Debug.Write($"{linenum,4}: {line} => ");
                if (line.Length == 0)
                {
                    Console.WriteLine("Blank Line Found, Exiting.");
                    break;
                }

                // Split the line into its parts
                string[] parts = line.Split(" ");
                Assert(parts.Length == 2, "Error[0030] Invalid Input");
                string springsString = parts[0];
                string dataString = parts[1];

                // Part 2
                if (part == Part.Part2)
                {
                    string tmpSpring = springsString;
                    string tmpData = dataString;
                    for (int i = 0; i < 4; i++)
                    {
                        springsString += "?" + tmpSpring;
                        dataString += "," + tmpData;
                    }
                }

                Springs springs = new Springs(springsString, dataString);
                long combinations = springs.FindRecursiveMatches();              // < ============================

                Debug.WriteLine($"{combinations}");
                sum += combinations;
            }
            stopWatch.Stop();

            Springs info = new Springs();
            Console.WriteLine($"Filename: {filename},      Lines: {linenum},    Part: {part}");
            Console.WriteLine($"Sum: {sum,13},     Elapsed Time: {stopWatch.Elapsed}s,     Operations: {info.Usage,6},     Cache Used: {info.CacheUsed}");

        }

    }
}
