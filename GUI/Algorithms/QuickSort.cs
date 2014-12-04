using System;
using GUI.Models;

namespace GUI.Algorithms
{
	public class QuickSort : SortingStrategy
	{
		public QuickSort () : base("Tri Rapide", Complexity.NLOGN) {}


		public override Probe doAlgorithm (DataSet dataset, int beginIndex, int endIndex)
		{
		
			if(!initialized) {
				data = dataset.getSubDataSet (beginIndex, endIndex);
				beginIndex -= beginIndex;
				endIndex -= beginIndex;
				initialized = true;
			}
			++call; 

			int pivot, i, j;


			endIndex = (endIndex > 0) ? endIndex : 0;
			endIndex = (endIndex >= data.size) ? data.size -1 : endIndex;
			pivot = data.copy(endIndex);

			i = beginIndex - 1;

			j = endIndex;



			if(beginIndex < endIndex) {

				for(;;) {

					while (data [++i] < pivot) {
						data.compare (0, 0); // increment comparisons counter
					}
					while (--j >= 0 && (data [j] > pivot) ) {
						data.compare (0, 0); // increment comparisons counter
					} 

					if(i >= j) break;
					data.exchange(i,j);
				}
				data.exchange(i, endIndex);
				doAlgorithm(null, beginIndex, i-1);
				doAlgorithm(null, i+1, endIndex);
			}

			--call; 
			if (call == 0) {
				initialized = false;
				Console.WriteLine ("Quicksort result :");
				Console.Write (data);
				return data.probe;
			} else {
				return null;
			}

		} /* public override Probe doAlgorithm () */
	} /* public class BubbleSort : SortingStrategy */ 
} /* namespace backEnd */


