using System;

namespace backEnd
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			DataSet data = new DataSet (10, InitialSort.RANDOM);

			Console.WriteLine ("Test => Attempting to generate and output 10 random values between 1 and 1O");

			Console.WriteLine (data);

			Console.WriteLine ("Test => DONE");
		}
	}
}
