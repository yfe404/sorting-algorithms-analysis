using System;
using System.IO;

namespace GUI
{



	public class DataFactory
	{

		static Random _random = new Random();

		public static int[] build(int n, InitialSort sort ) {

			int [] t = new int [n];

			if(sort == InitialSort.SORTED) {
				for(int i = 0; i < n; ++i) {
					t[i] = i;
				}           
			} else if(sort == InitialSort.REVERSE) {
				for(int i = 0; i < n; ++i) {
					t[i] = n-i-1;
				}
			} else if(sort == InitialSort.RANDOM) {
				for(int i = 0; i < n; ++i) {
					t[i] = i;
				}   
				Shuffle(t);
			}

			return t;
		}



		// reader.ReadLine();
		public static int[] build(string pathname) {

			int[] t = null;
			int cpt = 0; 
			int i = 0;
			StreamReader reader = null; // In System.IO namespace try

			try {
				reader = File.OpenText (pathname); 

				while(!reader.EndOfStream) {
					reader.ReadLine();
					++cpt;
				}

				t = new int[cpt];
				reader.Close();
				reader = File.OpenText (pathname); 

				while(!reader.EndOfStream) {
					string tmp = reader.ReadLine();
					if(!Int32.TryParse(tmp, out t[i++])) {
						Console.WriteLine("Error, NAN read in the file : " + pathname);
						return null; // change this line by exit 
					}
				}
			} finally {
				if (reader != null) reader.Dispose(); 
			}

			return t;
		}
	



		private static void Shuffle<T>(T[] array)
		{
			var random = _random;
			for (int i = array.Length; i > 1; i--)
			{
				// Pick random element to swap.
				int j = random.Next(i); // 0 <= j <= i-1
				// Swap
				T tmp = array[j];
				array[j] = array[i - 1];
				array[i - 1] = tmp;
			}
		}

	

	

	}

}




