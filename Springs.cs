using System.Diagnostics;
using static AOC_23_12.Extensions;

namespace AOC_23_12
{
	public class Springs
	{
		char[] _springs;
		int[] _data;
		static int[,] _cache;
		static int _cacheUsed = 0;
		static int _usage = 0;

        public int CacheUsed { get { return _cacheUsed; } }
		public int Usage { get { return _usage; } }

		public Springs() => new Springs(".", "1"); 
		public Springs(string springsString, string dataString)
		{
			
			_springs = OptimizeDots(springsString).ToCharArray();
			_data = dataString.Split(",").Select(x => int.Parse(x)).ToArray();
			_cache = new int[25,15];
			foreach (int i in _cache) _cache[i % 25, i / 25] = -1;
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

		public int FindRecursiveMatches() => FindRecursiveMatches(0, 0);
		public int FindRecursiveMatches(int springIndex, int clusterIndex)
		{
			_usage++;
			if (_cache[springIndex, clusterIndex] > 0) { _cacheUsed++; return _cache[springIndex, clusterIndex]; }

			if (clusterIndex >= _data.Length)		
				if (TailCheck(springIndex)) return _cache[springIndex, clusterIndex] = 1;  
				else return _cache[springIndex, clusterIndex] = 0;

			if (IsEOL(springIndex)) return _cache[springIndex, clusterIndex] = 0;
			int found = 0;

			if (IsSpring(springIndex)) found += FindRecursiveMatches(springIndex + 1, clusterIndex);  // Increment Right
			if (SpringsMatchesCluster(springIndex, _data[clusterIndex])) found += FindRecursiveMatches(springIndex + _data[clusterIndex] + 1, clusterIndex + 1); // Increment Right Searching for Cluster

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
