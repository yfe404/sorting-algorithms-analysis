using System;
using GUI.Models;

namespace GUI.Algorithms
{
	public class BubbleSortOptimized : SortingStrategy
	{
		public BubbleSortOptimized () : base("Tri Bulle Optimise", Complexity.QUADRATIC) {}

	
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
			int tmp = data_size;
			int posLastSwap = tmp;  /* Position du dernier échange (évite de tout reparcourir) */
			bool echange = false;

			for(int i = 0; i < data_size; ++i)
			{
				for(int j = 0; j < data_size; ++j)
				{

					if(data.compare(j, j+1) > 0) {
						data.exchange (j, j + 1);
						echange = true;
						posLastSwap = j;

					}
				}
				tmp = posLastSwap;
				if(echange == false)  {
					return data.probe;
				}
				echange = false;
			}

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





