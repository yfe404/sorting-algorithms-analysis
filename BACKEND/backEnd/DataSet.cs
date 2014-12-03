using System;

namespace backEnd
{
	public class DataSet
	{
		private int [] data; 
		public Probe probe {
			get;
			private set;
		}

		public DataSet (int size, InitialSort initialSort)
		{
			this.probe = new Probe ();
			this.data = DataFactory.build(size, initialSort);
		}

		public override string ToString() {
			string ret = "";
				foreach (int d in data) {
					ret += d + "\n";
				}

			 return ret; 
		}

		private void exchange(int n1, int n2) {
			probe.incrNbExchanges();
			int tmp = this.copy(n1); 
			data [n1] = data [n2];
			data [n2] = tmp;
		}

		private int copy(int itemIndex) {
			probe.incrNbCopies();
			return data[itemIndex];
		}

		private int compare(int n1, int n2) {
			probe.incrNbComparisons();
			if (data [n1] == data [n2]) {
				return 0;
			} else if (data [n1] < data [n2]) {
				return -1;
			} else {
				return 1;
			}
		}

		public void resetProbe() {
			probe.reset();
		}
			
	}
}

