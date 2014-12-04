using System;

namespace backEnd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Probe p;

			Sorter sorter = new Sorter ();
			sorter.sortingStrategy = new InsertionSort ();
			DataSet data = new DataSet (1000000, InitialSort.RANDOM);

			p = sorter.Sort (data, 999, 1000);

			Console.WriteLine (p);

		}
	}
}
