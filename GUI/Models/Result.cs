using System;
using System.Collections.Generic;
using GUI.Models;

namespace GUI.Models
{
	public class Result
	{
		public string Algorithm;

		private Dictionary<int, Probe> probes;

		public Result (string algorithm)
		{
			Algorithm = algorithm;
			probes = new Dictionary<int, Probe> ();
		}

		public void AddProbe(int datasize, Probe probe) {
			probes.Add (datasize, probe);
		}

		public Dictionary<int, int> GetDataPoints() {
			var dataPoints = new Dictionary<int, int> ();

			foreach (var probe in probes) {
				dataPoints.Add (probe.Key, probe.Value.nbComparisons);
			}

			return dataPoints;
		}
	}
}

