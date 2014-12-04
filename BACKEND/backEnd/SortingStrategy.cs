using System;
using backEnd;

namespace algorithms
{
	public abstract class SortingStrategy
	{
		protected DataSet data;
		protected bool initialized = false;
		protected int call = 0;

		public abstract Probe doAlgorithm(DataSet dataset, int beginIndex, int endIndex);
	}
}

