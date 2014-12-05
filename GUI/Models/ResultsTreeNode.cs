using System;

namespace GUI.Models
{
	[Gtk.TreeNode (ListOnly = true)]
	public class ResultsTreeNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue (Column = 0)]
		public bool TheoriticalVisible;

		[Gtk.TreeNodeValue (Column = 1)]
		public bool MeasuredVisible;

		[Gtk.TreeNodeValue (Column = 2)]
		public string Algorithm;

		[Gtk.TreeNodeValue (Column = 3)]
		public string Complexity;

		[Gtk.TreeNodeValue (Column = 4)]
		public int Comparisons;

		[Gtk.TreeNodeValue (Column = 5)]
		public int Exchanges;

		[Gtk.TreeNodeValue (Column = 6)]
		public int Copies;

		public ResultsTreeNode (string algorithm, string complexity, int comparisons, int exchanges, int copies)
		{
			TheoriticalVisible = true;
			MeasuredVisible = true;
			Algorithm = algorithm;
			Complexity = complexity;
			Comparisons = comparisons;
			Exchanges = exchanges;
			Copies = copies;
		}
	}
}

