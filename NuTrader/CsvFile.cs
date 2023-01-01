using System;
namespace NuTrader
{
	public class CsvFile
	{
		public List<string> Lines => _lines;
		public int Count => _lines.Count;

		private List<string> _lines = new List<string>();

		public CsvFile()
		{
		}

		public void AddLine(string s)
		{
			Lines.Add(s);
		}

		public static CsvFile LoadCsv(string filePath, int headerLines = 0)
		{
			var csv = new CsvFile();

			var f = new StreamReader(filePath);

			string line;

			for (int i = 0; i < headerLines; i++)
			{
				line = f.ReadLine();
			}

			line = f.ReadLine();
			while (line != null)
			{
				csv.AddLine(line);
				line = f.ReadLine();
			}

			return csv;
		}
	}
}

