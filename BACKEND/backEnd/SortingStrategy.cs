using System;

namespace backEnd
{
	public abstract class SortingStrategy
	{
		protected DataSet data;

		public void initialize(DataSet dataset, int beginIndex, int endIndex)
		{
			data = dataset.getSubDataSet (beginIndex, endIndex);
		}

		public abstract Probe doAlgorithm();
	}
}

