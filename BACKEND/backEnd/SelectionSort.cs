using System;
namespace backEnd
{
	public class SelectionSort : SortingStrategy
	{
		public SelectionSort () : base() {}

		bool initialized = false;
		int call = 0;

		public override Probe doAlgorithm (DataSet dataset, int beginIndex, int endIndex)
		{

			if(!initialized) {
				data = dataset.getSubDataSet (beginIndex, endIndex);
				beginIndex -= beginIndex;
				endIndex -= beginIndex;
				initialized = true;
			}
			++call; 

			int data_size = data.size-1;
			for(int i = 0; i < data_size; ++i)
			{
				for(int j = 0; j < data_size; ++j)
				{

					if(data.compare(j, j+1) > 0) {
						data.exchange (j, j + 1);

					}
				}
			}

			--call; 
			if (call == 0) {
				initialized = false;
				Console.WriteLine ("BubbleSort result :");
				Console.Write (data);
				return data.probe;
			} else {
				return null;
			}

		} /* public override Probe doAlgorithm () */
	} /* public class BubbleSort : SortingStrategy */ 
} /* namespace backEnd */




