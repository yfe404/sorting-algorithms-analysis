using System;
using algorithms;

namespace backEnd
{
	public class InsertionSort : SortingStrategy
	{
		public InsertionSort () : base() {}

	
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


			for(int i = 1; i < data_size; ++i){
				int v = data.copy(i);
				int j = i;

				data.compare (0, 0); // increment comparisons counter
				while(data[j-1] > v) {
					data.copy(0); // increment copy counter
					data[j] = data.copy(j-1);
					--j;
					if(j <= 0) break;
					// fin du while, on refait une comparaison pour voir si on doit repasser dans la boucle.
					data.compare (0, 0); // increment comparisons counter
				}

				data.copy(0); // increment copy counter
				data[j] = v;	

			}	




			--call; 
			if (call == 0) {
				initialized = false;
				Console.WriteLine ("Insertion sort result :");
				Console.Write (data);
				return data.probe;
			} else {
				return null;
			}

		} /* public override Probe doAlgorithm () */
	} /* public class BubbleSort : SortingStrategy */ 
} /* namespace backEnd */





