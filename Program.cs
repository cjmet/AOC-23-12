// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using static AOC_23_12.ExtensionMethods;

int sum = 0;
var filename = FindFileInVisualStudio("input.txt");
filename =  FindFileInVisualStudio("test.txt");
Console.WriteLine($"Attempting to read {filename}");
Console.WriteLine();
foreach (string line in File.ReadLines(filename))
{
	Console.Write($"{line} => ");
	int combinations = GetCombinations(line);
	Console.WriteLine(combinations);
	sum += combinations;
}


Console.WriteLine();
Console.WriteLine($"Sum: {sum}");
Debug.Assert(sum == 54597 || sum == 54504);
Environment.Exit(0);
// </main>


/* *********************************************************************** */

int GetCombinations(string line)
{
	return 0;
}





