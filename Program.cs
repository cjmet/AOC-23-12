// See https://aka.ms/new-console-template for more information
using AOC_23_12;
using static AOC_23_12.Extensions;
using System.Diagnostics;
using System.Runtime.CompilerServices;

long sum = 0;
int springArraySize = 0;
int dataArraySize = 0;
int lineNum = 0;

var filename = FindFileInVisualStudio("input.txt");
//filename = FindFileInVisualStudio("test.txt");
Console.WriteLine($"Attempting to read {filename}");
Console.WriteLine();

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
foreach (string line in File.ReadLines(filename))
{
	Console.Write($"{++lineNum}: {line} => ");
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
	bool Part2 = true;
	if (Part2) {
		string tmpSpring = springsString;
		string tmpData = dataString;
		for (int i = 0; i < 4; i++)
		{
			springsString += "?" + tmpSpring;
			dataString += "," + tmpData;
		}
	}

	springArraySize = int.Max(springArraySize, springsString.Length);
	dataArraySize = int.Max(dataArraySize, dataString.Length);

	Springs springs = new Springs(springsString, dataString);

	long combinations = springs.FindRecursiveMatches();              // < ============================
	
	Console.WriteLine($"{combinations}");
	sum += combinations;
}
stopWatch.Stop();

Console.WriteLine();
Console.WriteLine("===========================================================");
Console.WriteLine($"Execution Time: {stopWatch.Elapsed}s");
Console.WriteLine($"Spring Array Size: {springArraySize},     Data Array Size: {dataArraySize}");
Springs info = new Springs();
Console.WriteLine($"Usage: {info.Usage},     Cache Used: {info.CacheUsed}");
Console.WriteLine($"Sum: {sum}");
Assert(sum == 21 || sum == 7032 || sum == 525152 || sum == 1493340882140, "Incorrect Answer");
Environment.Exit(0);
