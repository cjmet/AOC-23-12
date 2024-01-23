// See https://aka.ms/new-console-template for more information
using AOC_23_12;
using System.Diagnostics;
using System.IO.Enumeration;
using static AOC_23_12.Extensions;
using System.Threading.Tasks;

namespace AOC_23_12
{
    public enum Part { Part1, Part2 };     // Top level Statements means this must at the bottom of the file.
    class Program
    {

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
            new FileEngine("test.txt", Part.Part1);

            new FileEngine("input.txt", Part.Part1);

            new FileEngine("test.txt", Part.Part2);

            Springs.UseCache = true;
            new FileEngine("input.txt", Part.Part2);

            Environment.Exit(0);



            // *********************************************************


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
}