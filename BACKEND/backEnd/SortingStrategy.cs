using System;

namespace backEnd
{
	public abstract class SortingStrategy
	{
		protected DataSet data;

		public abstract Probe doAlgorithm(DataSet dataset, int beginIndex, int endIndex);
	}
}

