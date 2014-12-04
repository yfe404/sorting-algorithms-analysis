using System;
using System.Linq;
using System.Collections.Generic;

using GUI.Algorithms;
using GUI.Models;

namespace GUI.Models
{
	public class Result
	{
		public SortingStrategy Algorithm;

		private Dictionary<int, Probe> probes;
		private KeyValuePair<int, Probe> largestProbe;

		public Result (SortingStrategy algorithm)
		{
			Algorithm = algorithm;
			probes = new Dictionary<int, Probe> ();
			largestProbe = new KeyValuePair<int, Probe> (0, new Probe ());
		}

		public void AddProbe(int datasize, Probe probe) {
			probes.Add (datasize, probe);

			if (datasize > largestProbe.Key) {
				largestProbe = new KeyValuePair<int, Probe> (datasize, probe);
			}
		}

		public Dictionary<int, int> GetDataPoints() {
			var dataPoints = new Dictionary<int, int> ();

			foreach (var probe in probes) {
				dataPoints.Add (probe.Key, probe.Value.nbComparisons);
			}

			return dataPoints;
		}

		public int GetSignificantComparisons() {
			return largestProbe.Value.nbComparisons;
		}

		public int GetSignificantCopies() {
			return largestProbe.Value.nbCopies;
		}

		public int GetSignificantExchanges() {
			return largestProbe.Value.nbExchanges;
		}
	}
}
	