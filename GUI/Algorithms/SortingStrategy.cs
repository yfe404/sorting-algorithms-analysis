using System;
using GUI.Models;

namespace GUI.Algorithms
{
	public abstract class SortingStrategy
	{
		protected DataSet data;
		protected bool initialized = false;
		protected int call = 0;

		public readonly string Name;
		public readonly Complexity AsymptoticComplexity;

		public SortingStrategy(string name, Complexity asymptoticComplexity) {
			Name = name;
			AsymptoticComplexity = asymptoticComplexity;
		}

		public abstract Probe doAlgorithm(DataSet dataset, int beginIndex, int endIndex);
	}
}

