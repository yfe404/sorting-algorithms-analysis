using System;

namespace backEnd
{
	public class BubbleSortOptimized : SortingStrategy
	{
		public BubbleSortOptimized () : base() {}

		public override Probe doAlgorithm ()
		{
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
					Console.WriteLine ("BubbleSortOptimized result : ");
					Console.Write (data);
					return data.probe;
				}
				echange = false;
			}

			Console.WriteLine ("BubbleSortOptimized result : ");
			Console.Write (data);
			return data.probe;
				
		} /* public override Probe doAlgorithm () */
	} /* public class BubbleSort : SortingStrategy */ 
} /* namespace backEnd */





