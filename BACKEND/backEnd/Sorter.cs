using System;

namespace backEnd
{
	public class Sorter
	{
		public SortingStrategy sortingStrategy { get; set;}

		public Sorter ()
		{
		}


		public Probe Sort(DataSet dataset, int beginIndex, int endIndex) {
	
			this.sortingStrategy.initialize (dataset, beginIndex, endIndex);
			return this.sortingStrategy.doAlgorithm ();
		}

	}
}

