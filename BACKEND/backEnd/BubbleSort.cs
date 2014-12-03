using System;

namespace backEnd
{
	public class BubbleSort : SortingStrategy
	{
		public BubbleSort () : base() {}

		public override Probe doAlgorithm ()
		{
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

			Console.WriteLine ("BubbleSort result :");
			Console.Write (data);
			return data.probe;

		} /* public override Probe doAlgorithm () */
	} /* public class BubbleSort : SortingStrategy */ 
} /* namespace backEnd */




