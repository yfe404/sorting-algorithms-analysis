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

		public int size {
			get { return data.Length;}
			private set{ }
		}

		public int this [int index] {
			get { return data[index];}
			set { data[index] = value;}
		}


		public DataSet (int size, InitialSort initialSort)
		{
			this.probe = new Probe ();
			this.data = DataFactory.build(size, initialSort);
		}


		private DataSet (int size)
		{
			this.probe = new Probe ();
			this.data = new int[size]; 
		}

		public override string ToString() {
			string ret = "";
				foreach (int d in data) {
					ret += d + "\n";
				}

			 return ret; 
		}

		public void exchange(int n1, int n2) {
			probe.incrNbExchanges();
			int tmp = this.copy(n1); 
			data [n1] = this.copy(n2);
			data [n2] = tmp;
			probe.incrNbCopies ();
		}

		public int copy(int itemIndex) {
			probe.incrNbCopies();
			return data[itemIndex];
		}

		public int compare(int n1, int n2) {
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

		public DataSet getSubDataSet(int beginIndex, int endIndex) {
			DataSet retDataSet = new DataSet (endIndex-beginIndex);

			for (int i = beginIndex; i < endIndex; ++i) {
				retDataSet.data [i] = this.data [i];
			}

			return retDataSet;
		}
			
	}
}

