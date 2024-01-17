
namespace AOC_23_12
{
	public static class ExtensionMethods
	{
		public static string FindFileInVisualStudio(string filename, SearchOption searchOption = SearchOption.AllDirectories)
		{
			string pushd = Directory.GetCurrentDirectory();
			string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), filename, searchOption);
			if (files.Length == 0)
			{
				Directory.SetCurrentDirectory("..");
				// string value = directory.FindFileInVisualStudio(directory, filename, SearchOption.TopDirectoryOnly);
				string value = FindFileInVisualStudio(filename, SearchOption.TopDirectoryOnly);
				Directory.SetCurrentDirectory(pushd);
				return value;
			}
			else
			{
				Directory.SetCurrentDirectory(pushd);
				return files[0];
			}
		}
		
	}
}
