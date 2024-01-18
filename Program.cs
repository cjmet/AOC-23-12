// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static AOC_23_12.ExtensionMethods;

int sum = 0;
string _springs;
int[] _data;

var filename = FindFileInVisualStudio("input.txt");
filename = FindFileInVisualStudio("test.txt");
Console.WriteLine($"Attempting to read {filename}");
Console.WriteLine();

foreach (string line in File.ReadLines(filename))
{
	Console.WriteLine($"{line} ");

	// Split the line into its parts
	string[] parts = line.Split(" ");
	Assert(parts.Length == 2, "Error[0030] Invalid Input");
	_springs = parts[0];
	string dataString = parts[1];
	Console.WriteLine($"{_springs} :: {dataString}");
	_data = dataString.Split(",").Select(x => int.Parse(x)).ToArray();
	Console.WriteLine($"[{string.Join(" ", _data)}]");

	// Search Backwards, the last one always has to match, and then cache the answers
	int combinations = GetCombinations();

	Console.WriteLine($"Combinations: {combinations}");
	Console.WriteLine();
	sum += combinations;
}


Console.WriteLine("===========================================================");
Console.WriteLine($"Sum: {sum}");
// Assert(sum == 54597 || sum == 54504);
Environment.Exit(0);
// </main>


/* *********************************************************************** */


int GetCombinations(int spring_index = 0, int data_index = 0)
{
	// line.IndexOf("a");

	if (spring_index >= _springs.Length || data_index >= _data.Length) return 0;

	string _s = _springs.Substring(spring_index);
	Console.WriteLine($"[{spring_index},{data_index}] :: [{_s}, {_data[data_index]}]");

	// int index = _s.IndexOf(_table[_data[data_index]]);
	int index = FindFirst(spring_index, data_index);
	Console.WriteLine($"First Index: {index}");

	if (index < 0)
	{
		return 0;
	}
	else if (data_index < _data.Length - 1)
	{
		spring_index += index + _data[data_index] + 1;
		data_index++;
		return GetCombinations(spring_index, data_index);
	}
	else if (data_index == _data.Length - 1)
	{
		return 1;
	}
	else
	{
		Assert(false);
	}

	Assert(false);
	return -1;
}




int FindFirst(int spring_index, int data_index)
{
	int clusterLength = _data[data_index];
	int j = 0;

	Console.WriteLine($"FindFirst[{spring_index}, {data_index}:{clusterLength}]");

	do
	{
		Console.WriteLine($"spring_index: {spring_index}, clusterLength: {clusterLength}");
		if (spring_index + clusterLength > _springs.Length)
		{
			Console.WriteLine("Return 98"); // Return or Next?
			return -1;
		}
		for (j = 0; j < clusterLength; j++)
		{
			if (_springs[spring_index + j] != '#' && _springs[spring_index + j] != '?')
			{
				Console.WriteLine($"Return 105, j: {j}"); // Return or Next?
				return -1;
			}
		}
		if ((spring_index + j) == _springs.Length || _springs[spring_index + j] == '.' || _springs[spring_index + j] == '?')
		{
			Console.WriteLine("Return 111"); // Return or Next?
			return spring_index;
		}
	} while (++spring_index < _springs.Length);

	Console.WriteLine("Return 116"); // Return or Next?
	return -1;
}


