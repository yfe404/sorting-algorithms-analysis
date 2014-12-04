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
			DataSet data = new DataSet (10, InitialSort.REVERSE);

			p = sorter.Sort (data, 0, 10);

			Console.WriteLine (p);

		}
	}
}
