using System;
using GUI.Models;

namespace GUI.Algorithms
{
	public class BubbleSortBool : SortingStrategy
	{
		public BubbleSortBool () : base("Tri Bulle Bool", Complexity.QUADRATIC) {}

		public override Probe doAlgorithm (DataSet dataset, int beginIndex, int endIndex)
		{

/* ------------- Initialization (common to all algorithms) ------------------------------*/
			if(!initialized) {
				data = dataset.getSubDataSet (beginIndex, endIndex);
				beginIndex -= beginIndex;
				endIndex -= beginIndex;
				initialized = true;
			}
			++call; 
/* -------------------------------------------------------------------------------------*/
			bool echange = false;
			int data_size = data.size-1;
			for(int i = 0; i < data_size; ++i)
			{
				for(int j = 0; j < data_size; ++j)
				{

					if(data.compare(j, j+1) > 0) {
						data.exchange (j, j + 1);
						echange=true;

					}
				}
				if(echange == false)  {
					return data.probe;
				}
				echange = false;
			}
/* -------------------------------------------------------------------------------------*/
			--call; 
			if (call == 0) {
				initialized = false;
				return data.probe;
			} else {
				return null;
			}

		} /* public override Probe doAlgorithm () */
	} /* public class BubbleSort : SortingStrategy */ 
} /* namespace backEnd */

