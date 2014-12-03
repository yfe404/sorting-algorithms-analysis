using System;

namespace backEnd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Probe p;

			Sorter sorter = new Sorter ();
			sorter.sortingStrategy = new BubbleSort ();

			DataSet data = new DataSet (10, InitialSort.RANDOM);

			p = sorter.Sort (data, 0, 3);

			Console.WriteLine ("Test => Attempting to generate and output 10 random values between 1 and 1O");

			Console.WriteLine (p);

			Console.WriteLine ("Test => DONE");
		}
	}
}
