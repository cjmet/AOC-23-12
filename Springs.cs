using System.Diagnostics;
using static AOC_23_12.Extensions;

namespace AOC_23_12
{
	public class Springs
	{
		char[] _springs;
		int[] _data;
		static long[,] _cache;
		static int _cacheUsed = 0;
		static int _usage = 0;

        public int CacheUsed { get { return _cacheUsed; } }
		public int Usage { get { return _usage; } }
		static public void Reset() { _cacheUsed = 0; _usage = 0; }

		public Springs() => new Springs(".", "1"); 
		public Springs(string springsString, string dataString)
		{
			
			_springs = OptimizeDots(springsString).ToCharArray();
			_data = dataString.Split(",").Select(x => int.Parse(x)).ToArray();
			_cache = new long[125,75];
			//initialize _cache
			for (int i = 0; i < 125; i++) for (int j = 0; j < 75; j++) _cache[i, j] = -1;
		}

		private string OptimizeDots(string source)
		{
			string optimized = "";
			foreach (char c in source)
			{
				if (optimized.Length < 1 || optimized.Last() != '.' || c != '.') optimized += c;
			}
			return optimized;
		}

		public long FindRecursiveMatches() => FindRecursiveMatches(0, 0);
		public long FindRecursiveMatches(int springIndex, int clusterIndex)
		{
			_usage++;
			if (_cache[springIndex, clusterIndex] >= 0) { _cacheUsed++; return _cache[springIndex, clusterIndex]; }

			if (clusterIndex >= _data.Length)		
				if (TailCheck(springIndex)) return _cache[springIndex, clusterIndex] = 1;  
				else return _cache[springIndex, clusterIndex] = 0;

			if (IsEOL(springIndex)) return _cache[springIndex, clusterIndex] = 0;
			long found = 0;

			// Increment Down
			if (SpringsMatchesCluster(springIndex, _data[clusterIndex])) found += FindRecursiveMatches(springIndex + _data[clusterIndex] + 1, clusterIndex + 1);
			// Increment Right
			if (IsSpring(springIndex)) found += FindRecursiveMatches(springIndex + 1, clusterIndex);
			
			return _cache[springIndex, clusterIndex] = found;
		}



		// Match One Cluster
		bool SpringsMatchesCluster(int springIndex, int cluster)
		{

			if (!IsSpringOrEOL(springIndex - 1)) return false;

			// Check the Cluster
			for (int i = 0; i < cluster; i++)
			{
				if (!IsDamaged(springIndex + i)) return false;
			}

			if (!IsSpringOrEOL(springIndex + cluster)) return false;

			return true;
		}



		// Console.Writeline _cache with formatting 
		public void PrintCache()
		{
			if (_data == null) return;
			if (_springs == null) return;

			foreach (char c in _springs) Console.Write($"  {c}");
			Console.Write("     ");
			Console.WriteLine($"{String.Join(",", _data)}");
			
			for (int y = 0; y <  _data.Length; y++)
			{
                for (int x = 0; x < _springs.Length; x++)
				{
						if (_cache[x,y] >= 0) Console.Write($"{_cache[x, y],3}");
						else Console.Write($"  .");
                }
                Console.WriteLine();
            }
        }



		// ************************************************************************************************



		bool TailCheck(int springIndex)		// aka: no '#' to the right of the answer, invalidating that answer as premature
		{
			if (IsEOL(springIndex)) return true;
			for (int i = springIndex; i < _springs.Length; i++) if (!IsSpring(i)) return false;
			return true;
		}

		bool IsEOL(int springIndex)
		{
			if ((springIndex) >= _springs.Length) return true;
			if ((springIndex) < 0) return true;
			return false;
		}

		bool IsSpring(int springIndex)          // '.', or '?'
		{
			if (IsEOL(springIndex)) return false;
			if (_springs[springIndex] == '.' || _springs[springIndex] == '?') return true;
			return false;
		}

		bool IsSpringOrEOL(int springIndex)     // '.', '?', or EOL
		{
			if (IsEOL(springIndex) || IsSpring(springIndex)) return true;
			return false;
		}

		bool IsDamaged(int springIndex)         // '#', or '?'
		{
			if (IsEOL(springIndex)) return false;
			if (_springs[springIndex] == '#' || _springs[springIndex] == '?') return true;
			return false;
		}

	}
}
