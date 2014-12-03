using System;

namespace backEnd
{
	public class Probe
	{
		public int nbComparisons {
			get;
			set;
		}
		public int nbCopies{
			get;
			set;
		}
		public int nbExchanges{
			get;
			set;
		}
			
		public Probe ()
		{
			reset ();
		}

		public void reset() {
			this.nbCopies = 0;
			this.nbExchanges = 0;
			this.nbComparisons = 0;
		}

		public void incrNbCopies() {
			++nbCopies;
		}

		public void incrNbExchanges() {
			++nbExchanges;
		}

		public void incrNbComparisons() {
			++nbComparisons;
		}
	}
}

