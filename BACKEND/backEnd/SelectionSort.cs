using System;
using backEnd;

namespace algorithms
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





			int data_size = data.size;
			int max = 0;
			int tmp = data_size;
			int i,j;

			for(i = 0; i < data_size; ++i)
			{
				for(j = 0; j < tmp; ++j)
				{
					if(data.compare(j, max) > 0) {
						max = j;
						data.copy(0); 
					}
				}
				data.exchange(max, tmp-1);
				--tmp;
				max = 0;

			}






			--call; 
			if (call == 0) {
				initialized = false;
				Console.WriteLine ("Selection Sort result :");
				Console.Write (data);
				return data.probe;
			} else {
				return null;
			}

		} /* public override Probe doAlgorithm () */
	} /* public class BubbleSort : SortingStrategy */ 
} /* namespace backEnd */







