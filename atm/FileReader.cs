namespace atm
{
	public static class FileReader
	{
		public static SortedList<int, int?> ReadValuesFromFile(string fileName)
		{
			SortedList<int, int?> result = new();
			using StreamReader sr = new(fileName);
			while (!sr.EndOfStream)
			{
				var values = sr.ReadLine()?.Split(" - ");
				if (values?.Length == 2)
				{
					result.Add(int.Parse(values[0]), int.Parse(values[1]));
				}
			}
			return result;
		}
	}
}