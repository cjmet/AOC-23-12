using static AOC_23_12.Extensions;

namespace AOC_23_12
{
	public class Springs
	{
		char[] _springs;
		int[] _data;

		public Springs(string springsString, string dataString)
		{
			_springs = springsString.ToCharArray();
			_data = dataString.Split(",").Select(x => int.Parse(x)).ToArray();
		}


		public int Zero() { return 0; }


		//public int GetCombinations(int springIndex = 0, int clusterIndex = 0)
		//{
		//	Assert(springIndex >= 0 && clusterIndex >= 0);
		//	if (springIndex >= _springs.Length || clusterIndex >= _data.Length) return 0;

		//	return 1;
		//}


		// ************************************************************************************************


		public int FindClusters(int springIndex, int clusterIndex)
		{
			int found = 0;
			do
			{
				int cluster = _data[clusterIndex];
				Debut.WriteLine($"Spring {springIndex} Cluster {clusterIndex} {cluster}");
				int index = FindFirstCluster(springIndex, cluster);  // cjm

				// if the clusters sequence is not complete increment clusterIndex and springIndex, and continue	
				// index + cluster + 1 to chomp the tail character
				// if (index >= 0 && clusterIndex < _data.Length - 1) FindClusters(index + cluster + 1, clusterIndex + 1);

				// if the sequence is complete and has a valid tail, increment found and continue
				if (index >= 0 && clusterIndex == _data.Length - 1 && TailCheck(index + cluster + 1))
				{
					found++;
					if (!IsSpring(springIndex)) return found;
				}
			}
			while (++springIndex < _springs.Length);

			return found;
		}



		// Increment Right Searching for Cluster, fail if not spring or EOL
		int FindFirstCluster(int springIndex, int cluster)
		{
			do
			{
				if (SpringsMatchesCluster(springIndex, cluster) >= 0)
				{
					return springIndex;
				}
				if (!IsSpring(++springIndex)) return -1;
			} while (springIndex < _springs.Length);
			return -1;
		}



		// Match One Cluster
		int SpringsMatchesCluster(int springIndex, int cluster)
		{
			int j = 0;

			if (springIndex + cluster > _springs.Length)
			{
				return -1;
			}
			// Check the Cluster
			for (j = 0; j < cluster; j++)
			{
				if (!IsDamaged(springIndex + j))
				{
					return -1;
				}
			}
			// Check the Tail
			if (IsSpringOrEOL(springIndex + j))
			{
				return springIndex;
			}

			return -1;
		}



		bool TailCheck(int springIndex)
		{
			while (springIndex < _springs.Length)
			{
				if (!IsSpringOrEOL(springIndex)) return false;
				else springIndex++;
			}
			return true;
		}

		bool IsEOL(int springIndex)
		{
			if ((springIndex) >= _springs.Length) return true;
			else return false;
		}

		bool IsSpring(int springIndex)
		{
			if (IsEOL(springIndex)) return false;
			else if (_springs[springIndex] == '.' || _springs[springIndex] == '?') return true;
			else return false;
		}

		bool IsSpringOrEOL(int springIndex)
		{
			if (IsSpring(springIndex) || IsEOL(springIndex)) return true;
			else return false;
		}

		bool IsDamaged(int springIndex)
		{
			if (_springs[springIndex] == '#' || _springs[springIndex] == '?') return true;
			else return false;
		}

		bool IsDamagedOrEOL(int springIndex)
		{
			if (IsDamaged(springIndex) || IsEOL(springIndex)) return true;
			else return false;
		}

	}
}
