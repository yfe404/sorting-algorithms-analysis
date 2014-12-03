using System;

namespace backEnd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Probe p;

			Sorter sorter = new Sorter ();
			sorter.sortingStrategy = new BubbleSortOptimized ();
			DataSet data = new DataSet (100, InitialSort.SORTED);

			p = sorter.Sort (data, 0, 100);

			Console.WriteLine (p);

		}
	}
}
