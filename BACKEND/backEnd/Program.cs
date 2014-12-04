using System;

namespace backEnd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Probe p;

			Sorter sorter = new Sorter ();
			sorter.sortingStrategy = new BubbleSortBool ();
			DataSet data = new DataSet (10, InitialSort.SORTED);

			p = sorter.Sort (data, 3, 10);

			Console.WriteLine (p);

		}
	}
}
