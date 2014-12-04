using System;

namespace backEnd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Probe p;

			Sorter sorter = new Sorter ();
			sorter.sortingStrategy = new QuickSort ();
			//DataSet data = new DataSet (1000000, InitialSort.REVERSE);

			DataSet testDataSetFile = new DataSet ("/Users/yafeunteun/Documents/Projets/backEnd/backEnd/fic0.txt");
			if (testDataSetFile != null) {
				//Console.Write (testDataSetFile);
			}

			p = sorter.Sort (testDataSetFile, 0, testDataSetFile.size);

			Console.WriteLine (p);

		}
	}
}
