// See https://aka.ms/new-console-template for more information
using AOC_23_12;
using System.Diagnostics;
using static AOC_23_12.Extensions;

class Program
{
    enum Part { Part1, Part2 };     // Top level Statements means this must at the bottom of the file.

    static void Main(string[] args)
    {

        // Print_Test_Array("??.??.??.??.??.", "1,1,1,1,1");
        // Print_Test_Array(".#.????.???.#.??.", "1,1,1,1,1");
        Springs.UseCache = false;
        Test_Array("???#???.??????????????#???.??????????????#???.??????????????#???.??????????????#???.???????????", "6,6,2,6,6,2,6,6,2,6,6,2,6,6,2", false);
        Springs.UseCache = true;
        Test_Array("???#???.??????????????#???.??????????????#???.??????????????#???.??????????????#???.???????????", "6,6,2,6,6,2,6,6,2,6,6,2,6,6,2", false);
        Console.WriteLine();

        Springs.UseCache = false;
        SubMain("test.txt", Part.Part1);

        SubMain("input.txt", Part.Part1);

        SubMain("test.txt", Part.Part2);

        //Task.Run(() => SubMain("test.txt", Part.Part2)).Wait(TimeSpan.FromSeconds(3));
        //var action = new Action(() => SubMain("test.txt", Part.Part2));
        //var task = new Task(action);
        //task.Run.Wait(TimeSpan.FromSeconds(3));
        //if (task.IsCanceled) Console.WriteLine("Operation Timed Out");
        
        Springs.UseCache = true;
        SubMain("test.txt", Part.Part2);
        // SubMain("input.txt", Part.Part2);

        Environment.Exit(0);



        ////**********************************************************************************************************************



        void SubMain(string filename, Part part)
        {
            long sum = 0;
            Springs.Reset();

            filename = FindFileInVisualStudio(filename);
            Debug.WriteLine($"Attempting to read {filename}");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (string line in File.ReadLines(filename))
            {
                Debug.Write($"{line} => ");
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
            Console.WriteLine($"Sum: {sum,13},     Elapsed Time: {stopWatch.Elapsed}s,     Operations: {info.Usage,6},     Cache Used: {info.CacheUsed}");

        }



        void Test_Array(string springString, string dataString, bool printCache)
        {


            Springs springs = new Springs(springString, dataString);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long combinations = springs.FindRecursiveMatches();              // < ============================
            stopWatch.Stop();
            if (printCache)
            {
                Console.WriteLine();
                Console.WriteLine();
                springs.PrintCache();
            }
            Console.WriteLine($"UseCache: {Springs.UseCache,5}     Combinations: {combinations},     Elapsed Time: {stopWatch.Elapsed}s");
        }
    }
}
