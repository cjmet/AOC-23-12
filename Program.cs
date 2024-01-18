// See https://aka.ms/new-console-template for more information
using AOC_23_12;
using static AOC_23_12.Extensions;
using System.Diagnostics;
using System.Runtime.CompilerServices;

int sum = 0;

var filename = FindFileInVisualStudio("input.txt");
filename = FindFileInVisualStudio("test.txt");
Console.WriteLine($"Attempting to read {filename}");
Console.WriteLine();

foreach (string line in File.ReadLines(filename))
{
	Console.WriteLine($"{line} ");
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

	Springs springs = new Springs(springsString, dataString);
	int combinations = springs.FindClusters(0,0);

	Console.WriteLine($"Combinations: {combinations}");
	Console.WriteLine();
	sum += combinations;
}


Console.WriteLine("===========================================================");
Console.WriteLine($"Sum: {sum}");
// Assert(sum == 54597 || sum == 54504);
Environment.Exit(0);
// </main>

