// See https://aka.ms/new-console-template for more information
using AOC_23_12;
using System.Diagnostics;
using static AOC_23_12.Extensions;


Console.WriteLine("Hello, World!");

SubMain("test.txt", Part.Part1);

SubMain("input.txt", Part.Part1);

SubMain("test.txt", Part.Part2);

SubMain("input.txt", Part.Part2);

Print_Test_Array("??.??.??.??.??.", "1,1,1,1,1");
Print_Test_Array(".#.????.???.#.??.", "1,1,1,1,1");

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
    Console.WriteLine($"Sum: {sum},     Elapsed Time: {stopWatch.Elapsed}s,     Operations: {info.Usage},     Cache Used: {info.CacheUsed}");

}



void Print_Test_Array(string springString, string dataString)
{

    Console.WriteLine();
    Springs springs = new Springs(springString, dataString);
    long combinations = springs.FindRecursiveMatches();              // < ============================
    springs.PrintCache();
    Console.WriteLine($"     Combinations: {combinations}");
    Console.WriteLine();
}



public enum Part { Part1, Part2 };     // Top level Statements means this must at the bottom of the file.