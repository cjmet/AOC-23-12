// See https://aka.ms/new-console-template for more information
using AOC_23_12;
using static AOC_23_12.Extensions;
using System.Diagnostics;
using System.Runtime.CompilerServices;

int sum = 0;
int springArraySize = 0;
int dataArraySize = 0;

var filename = FindFileInVisualStudio("input.txt");
// filename = FindFileInVisualStudio("test.txt");
Console.WriteLine($"Attempting to read {filename}");
Console.WriteLine();

foreach (string line in File.ReadLines(filename))
{
	Console.Write($"{line} => ");
	if (line.Length == 0)
	{
		Console.WriteLine("Blank Line Found, Exiting.");
		Environment.Exit(0);
	}

	// Split the line into its parts
	string[] parts = line.Split(" ");
	Assert(parts.Length == 2, "Error[0030] Invalid Input");
	string springsString = parts[0];
	string dataString = parts[1];
	springArraySize = int.Max(springArraySize, springsString.Length);
	dataArraySize = int.Max(dataArraySize, dataString.Length);

	Springs springs = new Springs(springsString, dataString);


	int combinations = springs.FindRecursiveMatches();				// < ============================


	Console.WriteLine($"{combinations}");
	sum += combinations;
}


Console.WriteLine();
Console.WriteLine("===========================================================");
Console.WriteLine($"Spring Array Size: {springArraySize},     Data Array Size: {dataArraySize}");
Springs info = new Springs();
Console.WriteLine($"Usage: {info.Usage},     Cache Used: {info.CacheUsed}");
Console.WriteLine($"Sum: {sum}");
Assert(sum == 7032, "Incorrect Answer");
Environment.Exit(0);
