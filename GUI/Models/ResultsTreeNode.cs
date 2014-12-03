using System;

namespace GUI.Models
{
	[Gtk.TreeNode (ListOnly = true)]
	public class ResultsTreeNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue (Column = 0)]
		public bool Visible;

		[Gtk.TreeNodeValue (Column = 1)]
		public string Algorithm;

		[Gtk.TreeNodeValue (Column = 2)]
		public string Dataset;

		[Gtk.TreeNodeValue (Column = 3)]
		public int Comparisons;

		[Gtk.TreeNodeValue (Column = 4)]
		public int Exchanges;

		[Gtk.TreeNodeValue (Column = 5)]
		public int Copies;

		public ResultsTreeNode (string algorithm, string dataset, int comparisons, int exchanges, int copies)
		{
			Visible = true;
			Algorithm = algorithm;
			Dataset = dataset;
			Comparisons = comparisons;
			Exchanges = exchanges;
			Copies = copies;
		}
	}
}

